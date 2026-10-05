using NanoidDotNet;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using QRCoder;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Application.Commons.Interfaces.AWS;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace ERP.Core.Database.Infrastructure.Services
{
    public partial class CodeGenerator(IUnitOfWork _unitOfWork, IS3StorageService _s3StorageService) : ICodeGenerator
    {
        [GeneratedRegex(@"[^a-zA-Z]")]
        private static partial Regex GenerateModuleCode();
        private readonly IUnitOfWork _unitOfWork = _unitOfWork;
        private readonly IS3StorageService _s3StorageService = _s3StorageService;

        private static string GetTypeCode(PurchaseRequestType type) => type switch
        {
            PurchaseRequestType.Requisition => "REQ",
            PurchaseRequestType.Eventual => "EVE",
            PurchaseRequestType.Monthly => "MEN",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Tipo de solicitud no soportado.")
        };

        public async Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToPurchaseRequest(PurchaseRequestType purchaseRequestType, Guid branchId)
        {
            var branch = await _unitOfWork.Branches.Entities
                .Include(b => b.Company)
                .FirstOrDefaultAsync(b => b.Id == branchId);

            if (branch == null)
            {
                return (false, string.Empty);
            }

            var typeCode = GetTypeCode(purchaseRequestType);

            var lastPurchaseRequest = await _unitOfWork.PurchaseRequests.Entities
                .Where(pr => pr.BranchId == branchId && pr.RequestType == purchaseRequestType)
                .OrderByDescending(pr => pr.CreatedAt)
                .FirstOrDefaultAsync();

            int nextSequence = 1;

            if (lastPurchaseRequest != null && !string.IsNullOrWhiteSpace(lastPurchaseRequest.Code))
            {
                int lastDashIndex = lastPurchaseRequest.Code.LastIndexOf('-');

                if (lastDashIndex > -1 && int.TryParse(lastPurchaseRequest.Code[(lastDashIndex + 1)..], out int lastSequence))
                {
                    nextSequence = lastSequence + 1;
                }
            }

            string sequenceFormatted = nextSequence.ToString().PadLeft(2, '0');
            string code = $"{branch.BranchCode?.ToUpper()}-{typeCode}-{sequenceFormatted}";

            return (true, code);
        }

        public string GenerateModuleCode(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
                return $"GEN-{GetRandomSuffix()}";

            string cleanName = GenerateModuleCode().Replace(subject.Trim().ToUpper(), "");

            string prefix = cleanName.Length >= 3
                ? cleanName[..3]
                : cleanName.PadRight(3, 'X');

            return $"{prefix}-{GetRandomSuffix()}";
        }

        public string GenerateUsername(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
                return "user.default";

            string cleanName = RemoveAccents(subject.ToLower().Trim());

            var parts = cleanName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1) return parts[0];

            string username = $"{parts[0]}.{parts[parts.Length - 1]}";

            return username;
        }

        #region Codigos de posicion para almacen
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueStorageCodeAsync(
            StorageEntityType entityType,
            Guid sectionId,
            CancellationToken ct = default)
        {
            var (isSuccess, codes) = await GenerateUniqueStorageCodesAsync(entityType, sectionId, 1, ct);

            return isSuccess ? (true, codes[0]) : (false, string.Empty);
        }

        public async Task<(bool IsSuccess, IReadOnlyList<string> Codes)> GenerateUniqueStorageCodesAsync(
            StorageEntityType entityType,
            Guid sectionId,
            int count,
            CancellationToken ct = default)
        {
            if (count <= 0)
            {
                return (false, []);
            }

            var section = await _unitOfWork.Sections.Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == sectionId && s.DeletedAt == null, ct);

            if (section is null || string.IsNullOrWhiteSpace(section.Code))
            {
                return (false, []);
            }

            var typeCode = GetStorageTypeCode(entityType);
            var pattern = $"{section.Code}-{typeCode}-";

            var existingCodes = entityType switch
            {
                StorageEntityType.Lot => await _unitOfWork.Lots.Entities
                    .AsNoTracking()
                    .Where(l => l.SectionId == sectionId && l.DeletedAt == null)
                    .Select(l => l.Code)
                    .ToListAsync(ct),
                StorageEntityType.Rack => await _unitOfWork.Racks.Entities
                    .AsNoTracking()
                    .Where(r => r.SectionId == sectionId && r.DeletedAt == null)
                    .Select(r => r.Code)
                    .ToListAsync(ct),
                _ => []
            };

            int maxSequence = existingCodes
                .Where(c => c is not null && c.StartsWith(pattern, StringComparison.OrdinalIgnoreCase))
                .Select(c => int.TryParse(c[pattern.Length..], out var sequence) ? sequence : 0)
                .DefaultIfEmpty(0)
                .Max();

            var codes = new List<string>(count);

            for (int i = 1; i <= count; i++)
            {
                string sequenceFormatted = (maxSequence + i).ToString().PadLeft(2, '0');
                codes.Add($"{pattern}{sequenceFormatted}");
            }

            return (true, codes);
        }

        public string GeneratePositionCode(string lotCode, int row, int column)
            => $"{lotCode}-F{row}C{column}";

        #endregion Codigos de posicion para almacen

        #region Codigos de secciones de almacen
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueSectionCodeAsync(
            Guid warehouseId,
            SectionType sectionType,
            SectionStorageType sectionStorageType,
            CancellationToken ct = default)
        {
            var warehouseExists = await _unitOfWork.Warehouses.Entities
                .AsNoTracking()
                .AnyAsync(w => w.Id == warehouseId && w.DeletedAt == null, ct);

            if (!warehouseExists)
            {
                return (false, string.Empty);
            }

            var prefixType = GetSectionPrefix(sectionType, sectionStorageType);

            if (prefixType is null)
            {
                return (false, string.Empty);
            }

            var prefix = $"{prefixType}-";

            var existingCodes = await _unitOfWork.Sections.Entities
                .AsNoTracking()
                .Where(s => s.WarehouseId == warehouseId && s.DeletedAt == null)
                .Select(s => s.Code)
                .ToListAsync(ct);

            int maxSequence = GetMaxSequence(prefix, existingCodes);

            return (true, $"{prefix}{maxSequence + 1:D2}");
        }

        private static string? GetSectionPrefix(SectionType sectionType, SectionStorageType sectionStorageType)
            => (sectionType, sectionStorageType) switch
            {
                (SectionType.Aisle, _) => "SP",  // Secciones de pasillos
                (SectionType.Storage, SectionStorageType.Racks) => "SR", // Secciones de Racks
                (SectionType.Storage, SectionStorageType.Lots) => "ST", // Secciones de Tramos
                _ => null
            };

        #endregion Codigos de secciones de almacen

        #region Codigos de clientes
        public async Task<(bool IsSuccess, CustomerCodesToRegister CustomerCodes)> GenerateUniqueCustomerCodesAsync(
            Guid companyId,
            int branchCount,
            CancellationToken ct = default)
        {
            if (branchCount <= 0)
            {
                return (false, default!);
            }

            var companyExists = await _unitOfWork.Companies.Entities
                .AsNoTracking()
                .AnyAsync(c => c.Id == companyId, ct);

            if (!companyExists)
            {
                return (false, default!);
            }

            var lastCustomerCodes = await _unitOfWork.Customers.Entities
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId && c.DeletedAt == null)
                .Select(c => c.CustomerCode)
                .ToListAsync(ct);

            int maxSequence = lastCustomerCodes
                .Where(code => code is not null)
                .Select(code => int.TryParse(code, out var sequence) ? sequence : 0)
                .DefaultIfEmpty(0)
                .Max();

            int nextSequence = maxSequence + 1;

            string customerCode = nextSequence.ToString().PadLeft(6, '0');

            var branchCodes = Enumerable.Range(1, branchCount)
                .Select(i => i.ToString().PadLeft(2, '0'))
                .ToList();

            string customerCif = $"{nextSequence.ToString().PadLeft(2, '0')}-{branchCodes[0]}";

            return (true, new CustomerCodesToRegister(customerCode, customerCif, branchCodes));
        }
        #endregion Codigos de clientes

        #region WorkAreas
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueWorkAreaCodeAsync(
            Guid companyId,
            CancellationToken ct = default)
        {
            var company = await _unitOfWork.Companies.Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == companyId && c.DeletedAt == null, ct);

            if (company is null || string.IsNullOrWhiteSpace(company.Code))
            {
                return (false, string.Empty);
            }

            var prefix = $"{company.Code}-";

            var existingCodes = await _unitOfWork.WorkAreas.Entities
                .AsNoTracking()
                .Where(wa => wa.CompanyId == companyId && wa.DeletedAt == null)
                .Select(wa => wa.WorkAreaCode)
                .ToListAsync(ct);

            int maxSequence = GetMaxSequence(prefix, existingCodes);

            return (true, $"{prefix}{maxSequence + 1:D2}");
        }
        #endregion WorkAreas

        #region CostCenters
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueCostCenterCodeAsync(
            Guid areaId,
            CancellationToken ct = default)
        {
            var area = await _unitOfWork.WorkAreas.Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(wa => wa.Id == areaId && wa.DeletedAt == null, ct);

            if (area is null || string.IsNullOrWhiteSpace(area.WorkAreaCode))
            {
                return (false, string.Empty);
            }

            var prefix = $"{area.WorkAreaCode}-";

            var existingCodes = await _unitOfWork.CostCenters.Entities
                .AsNoTracking()
                .Where(cc => cc.WorkAreaId == areaId && cc.DeletedAt == null)
                .Select(cc => cc.CostCenterCode)
                .ToListAsync(ct);

            int maxSequence = GetMaxSequence(prefix, existingCodes);

            return (true, $"{prefix}{maxSequence + 1:D2}");
        }
        #endregion CostCenters



        #region Operationals
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueOperationalOrderCodeAsync()
        {
            const string prefix = "PO-";

            var existingCodes = await _unitOfWork.OperationalOrders.Entities
                .AsNoTracking()
                .Where(po => po.PoCode != null && po.PoCode.StartsWith(prefix))
                .OrderByDescending(po => po.CreatedAt)
                .ThenByDescending(po => po.PoCode!.Length)
                .ThenByDescending(po => po.PoCode)
                .Select(po => po.PoCode)
                .Take(10)
                .ToListAsync();

            return BuildSequenceCode(prefix, existingCodes);
        }

        public async Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToServiceOrder()
        {
            const string prefix = "OS-";

            var existingCodes = await _unitOfWork.ServicesOrders.Entities
                .AsNoTracking()
                .Where(os => os.ServiceOrderCode != null && os.ServiceOrderCode.StartsWith(prefix))
                .OrderByDescending(os => os.CreatedAt)
                .ThenByDescending(os => os.ServiceOrderCode!.Length)
                .ThenByDescending(os => os.ServiceOrderCode)
                .Select(os => os.ServiceOrderCode)
                .Take(10)
                .ToListAsync();

            return BuildSequenceCode(prefix, existingCodes);
        }

        #endregion OperationalOrders

        #region Reception
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueReceptionEntranceCodeAsync(CancellationToken ct = default)
        {
            var existingCodes = await _unitOfWork.ReceptionEntrance.Entities
                .AsNoTracking()
                .Where(re => !string.IsNullOrEmpty(re.ReceptionCode))
                .OrderByDescending(re => re.CreatedAt)
                .ThenByDescending(re => re.ReceptionCode!.Length)
                .ThenByDescending(re => re.ReceptionCode)
                .Select(re => re.ReceptionCode)
                .Take(10)
                .ToListAsync(ct);

            return BuildSequenceCode(string.Empty, existingCodes);
        }
        #endregion Reception

        #region Metodos Privados

        private static (bool IsSuccess, string Code) BuildSequenceCode(string prefix, IEnumerable<string?> existingCodes)
            => (true, $"{prefix}{GetMaxSequence(prefix, existingCodes) + 1:D2}");
        private static string GetStorageTypeCode(StorageEntityType entityType) => entityType switch
        {
            StorageEntityType.Lot => "LOT",
            StorageEntityType.Rack => "RACK",
            _ => throw new ArgumentOutOfRangeException(nameof(entityType), entityType, "Tipo de entidad de almacenamiento no soportado.")
        };

        private static int GetMaxSequence(string prefix, IEnumerable<string?> codes)
            => codes
            .Where(c => !string.IsNullOrWhiteSpace(c) && c!.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            .Select(c => int.TryParse(c![prefix.Length..], out var sequence) ? sequence : 0)
            .DefaultIfEmpty(0)
            .Max();

        private static string GetRandomSuffix()
        {
            const string alphabet = "23456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            return Nanoid.Generate(alphabet, size: 4);
        }

        private static string RemoveAccents(string text)
        {
            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);

                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

        #endregion Metodos Privado

        public async Task<string> GenerateQrCodeAsync(string redirectUrl, string? logoBase64 = null, CancellationToken cancellationToken = default)
        {
            const int n = 33;
            var U = Math.Max(10, 630 / n);
            var Q = n * U;
            var padding = 4 * U;
            var card = Q + 2 * padding;
            const int margin = 56;
            var canvasSize = card + 2 * margin;

            using var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(redirectUrl, QRCodeGenerator.ECCLevel.H);
            var qrCode = new PngByteQRCode(qrCodeData);
            var qrBytes = qrCode.GetGraphic(20);
            
            using var qrStream = new MemoryStream(qrBytes);
            using var qrImage = await Image.LoadAsync<Rgba32>(qrStream, cancellationToken);
            
            var moduleMatrix = GetModuleMatrix(qrCodeData, n);

            using var canvas = new Image<Rgba32>(canvasSize, canvasSize);
            canvas.Mutate(ctx =>
            {
                ctx.Fill(Color.FromRgb(238, 243, 250));
            });

            var cardX = margin;
            var cardY = margin;
            var cardRect = new RectangleF(cardX, cardY, card, card);

            var shadowColor = Color.FromRgba(10, 37, 84, (byte)(255 * 0.6));
            canvas.Mutate(ctx =>
            {
                var shadowRect = new RectangleF(cardX - 12, cardY + 12, card, card);
                var shadowPath = CreateRoundedRectangle(shadowRect, 52);
                ctx.Fill(shadowColor, shadowPath);
            });

            canvas.Mutate(ctx =>
            {
                var cardPath = CreateRoundedRectangle(cardRect, 52);
                ctx.Fill(Color.White, cardPath);
            });

            var qrOriginX = cardX + padding;
            var qrOriginY = cardY + padding;

            var gradientBrush = new LinearGradientBrush(
                new PointF(qrOriginX, qrOriginY),
                new PointF(qrOriginX + Q, qrOriginY + Q),
                GradientRepetitionMode.Repeat,
                new ColorStop(0f, Color.FromRgb(0, 79, 144)),
                new ColorStop(1f, Color.FromRgb(176, 24, 28)));

            var moduleInset = 0.03f * U;
            var moduleRadius = 0.22f * U;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (!moduleMatrix[row][col]) continue;

                    bool isFinderPattern = IsInFinderPattern(row, col, n);
                    if (isFinderPattern) continue;

                    var x = qrOriginX + col * U + moduleInset;
                    var y = qrOriginY + row * U + moduleInset;
                    var size = U - 2 * moduleInset;

                    var moduleRect = new RectangleF(x, y, size, size);
                    var modulePath = CreateRoundedRectangle(moduleRect, moduleRadius);
                    canvas.Mutate(ctx => ctx.Fill(gradientBrush, modulePath));
                }
            }

            DrawFinderPattern(canvas, qrOriginX, qrOriginY, U, gradientBrush, 0, 0);
            DrawFinderPattern(canvas, qrOriginX, qrOriginY, U, gradientBrush, n - 7, 0);
            DrawFinderPattern(canvas, qrOriginX, qrOriginY, U, gradientBrush, 0, n - 7);

            var K = n % 2 == 0 ? 8 : 9;
            if ((double)K / n > 0.30) K = n % 2 == 0 ? 8 : 7;
            var k0 = (n - K) / 2;

            var plateSize = K * U;
            var plateX = qrOriginX + k0 * U;
            var plateY = qrOriginY + k0 * U;
            var plateRadius = 0.5f * U;

            var plateRect = new RectangleF(plateX, plateY, plateSize, plateSize);
            var platePath = CreateRoundedRectangle(plateRect, plateRadius);
            canvas.Mutate(ctx => ctx.Fill(Color.White, platePath));

            if (!string.IsNullOrEmpty(logoBase64))
            {
                var logoBytes = Convert.FromBase64String(logoBase64);
                using var logoStream = new MemoryStream(logoBytes);
                using var logoImage = await Image.LoadAsync<Rgba32>(logoStream, cancellationToken);

                var logoHeight = (int)(plateSize * 0.8);
                var logoWidth = (int)((double)logoImage.Width / logoImage.Height * logoHeight);
                var logoX = plateX + (plateSize - logoWidth) / 2f;
                var logoY = plateY + (plateSize - logoHeight) / 2f;

                logoImage.Mutate(ctx => ctx.Resize(new ResizeOptions
                {
                    Size = new Size(logoWidth, logoHeight),
                    Mode = ResizeMode.Max,
                    Sampler = KnownResamplers.Lanczos3
                }));

                var logoRect = new Rectangle((int)logoX, (int)logoY, logoWidth, logoHeight);
                canvas.Mutate(ctx => ctx.DrawImage(logoImage, logoRect, 1f));
            }

            using var outputStream = new MemoryStream();
            await canvas.SaveAsPngAsync(outputStream, cancellationToken);
            outputStream.Position = 0;

            var base64Image = Convert.ToBase64String(outputStream.ToArray());
            var s3Url = await _s3StorageService.UploadImageAsync("qr-codes", "generated", base64Image, cancellationToken);

            return s3Url;
        }

        private static bool[][] GetModuleMatrix(QRCodeData qrCodeData, int n)
        {
            var matrix = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new bool[n];
            }

            var modules = qrCodeData.ModuleMatrix;
            var moduleCount = modules.Count;
            var scale = Math.Max(1, moduleCount / n);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    var srcRow = row * scale;
                    var srcCol = col * scale;
                    if (srcRow < moduleCount && srcCol < moduleCount)
                    {
                        matrix[row][col] = modules[srcRow][srcCol];
                    }
                }
            }

            return matrix;
        }

        private static IPath CreateRoundedRectangle(RectangleF rect, float radius)
        {
            var path = new PathBuilder();
            var x = rect.X;
            var y = rect.Y;
            var w = rect.Width;
            var h = rect.Height;
            var r = Math.Min(radius, Math.Min(w, h) / 2);

            path.StartFigure();
            path.AddLine(new PointF(x + r, y), new PointF(x + w - r, y));
            path.AddArc(new RectangleF(x + w - r * 2, y, r * 2, r * 2), 270f, 90f, 1f);
            path.AddLine(new PointF(x + w, y + r), new PointF(x + w, y + h - r));
            path.AddArc(new RectangleF(x + w - r * 2, y + h - r * 2, r * 2, r * 2), 0f, 90f, 1f);
            path.AddLine(new PointF(x + w - r, y + h), new PointF(x + r, y + h));
            path.AddArc(new RectangleF(x, y + h - r * 2, r * 2, r * 2), 90f, 90f, 1f);
            path.AddLine(new PointF(x, y + h - r), new PointF(x, y + r));
            path.AddArc(new RectangleF(x, y, r * 2, r * 2), 180f, 90f, 1f);
            path.CloseFigure();

            return path.Build();
        }

        private static bool IsInFinderPattern(int row, int col, int n)
        {
            return (row < 7 && col < 7) ||
                   (row < 7 && col >= n - 7) ||
                   (row >= n - 7 && col < 7);
        }

        private static void DrawFinderPattern(Image<Rgba32> canvas, float qrOriginX, float qrOriginY, int U, LinearGradientBrush gradient, int startRow, int startCol)
        {
            var eyeX = qrOriginX + startCol * U;
            var eyeY = qrOriginY + startRow * U;
            var eyeSize = 7 * U;

            var outerRadius = 1.2f * U;
            var outerRect = new RectangleF(eyeX, eyeY, eyeSize, eyeSize);
            var outerPath = CreateRoundedRectangle(outerRect, outerRadius);
            canvas.Mutate(ctx => ctx.Fill(gradient, outerPath));

            var holeInset = 1 * U;
            var holeSize = 5 * U;
            var holeRadius = 0.7f * U;
            var holeRect = new RectangleF(eyeX + holeInset, eyeY + holeInset, holeSize, holeSize);
            var holePath = CreateRoundedRectangle(holeRect, holeRadius);
            canvas.Mutate(ctx => ctx.Fill(Color.White, holePath));

            var centerInset = 2 * U;
            var centerSize = 3 * U;
            var centerRadius = 0.5f * U;
            var centerRect = new RectangleF(eyeX + centerInset, eyeY + centerInset, centerSize, centerSize);
            var centerPath = CreateRoundedRectangle(centerRect, centerRadius);
            canvas.Mutate(ctx => ctx.Fill(gradient, centerPath));
        }
    }
}