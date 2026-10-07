using NanoidDotNet;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using QRCoder;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Fonts;

using ERP.Core.Database.Application.Commons.Options;
using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Application.Commons.Interfaces.AWS;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;
using ZXing;
using ZXing.Common;

namespace ERP.Core.Database.Infrastructure.Services
{
    public partial class CodeGenerator(IUnitOfWork _unitOfWork, IS3StorageService _s3StorageService, IHttpClientFactory _httpClientFactory) : ICodeGenerator
    {
        [GeneratedRegex(@"[^a-zA-Z]")]
        private static partial Regex GenerateModuleCode();
        private readonly IUnitOfWork _unitOfWork = _unitOfWork;
        private readonly IS3StorageService _s3StorageService = _s3StorageService;
        private readonly IHttpClientFactory _httpClientFactory = _httpClientFactory;

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
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == branchId);

            if (branch is null || string.IsNullOrWhiteSpace(branch.BranchCode))
            {
                return (false, string.Empty);
            }

            var typeCode = GetTypeCode(purchaseRequestType);
            var prefix = $"{branch.BranchCode.ToUpper()}-{typeCode}-";

            var existingCodes = await _unitOfWork.PurchaseRequests.Entities
                .AsNoTracking()
                .Where(pr => pr.BranchId == branchId
                    && pr.RequestType == purchaseRequestType
                    && pr.Code != null
                    && pr.Code.StartsWith(prefix))
                .Select(pr => pr.Code)
                .ToListAsync();

            int maxSequence = GetMaxSequence(prefix, existingCodes);

            return (true, $"{prefix}{maxSequence + 1:D2}");
        }

        public async Task<(bool IsSuccess, string Code)> GenerateUniquePurchaseOrderCode(
            Guid purchaseRequestId,
            CancellationToken ct = default)
        {
            var request = await _unitOfWork.PurchaseRequests.Entities
                .AsNoTracking()
                .Include(pr => pr.Branch)
                .FirstOrDefaultAsync(pr => pr.Id == purchaseRequestId, ct);

            if (request?.Branch is null || string.IsNullOrWhiteSpace(request.Branch.BranchCode))
            {
                return (false, string.Empty);
            }

            var prefix = $"{request.Branch.BranchCode.ToUpper()}-OC-";

            var existingCodes = await _unitOfWork.PurchaseOrders.Entities
                .AsNoTracking()
                .Where(po => po.PurchaseRequest.BranchId == request.BranchId
                    && po.Code != null
                    && po.Code.StartsWith(prefix))
                .Select(po => po.Code)
                .ToListAsync(ct);

            int maxSequence = GetMaxSequence(prefix, existingCodes);

            return (true, $"{prefix}{maxSequence + 1:D2}");
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

        #region Metodo para generar codigo producto
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueProductCode(
            Guid companyId, Guid categoryId , CancellationToken ct
        )
        {
            var company = await _unitOfWork.Companies.Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == companyId && c.DeletedAt == null, ct);

            if (company is null || string.IsNullOrWhiteSpace(company.Code))
            {
                return (false, string.Empty);
            }
            var category = await _unitOfWork.CategoryProducts.Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(c=>c.Id == categoryId && c.DeletedAt == null, ct);
            
            if(category is null || string.IsNullOrWhiteSpace(category.Code))
            { 
                return (false, string.Empty);
            }

            var prefix = $"{company.Code}-{category.Code}-";

            var existingCodes = await _unitOfWork.Products.Entities
                .AsNoTracking()
                .Where(p => p.Code != null && p.Code.StartsWith(prefix))
                .Select(p => p.Code)
                .ToListAsync(ct);

            int maxSequence = GetMaxSequence(prefix, existingCodes);
            return (true, $"{prefix}{maxSequence + 1:D3}");
        }
        #endregion Products

        #region Generar codigo QR
        private const int PaperWidthPx = 576;
        private const int SideMargin   = 12;
        private const string DefaultUrl = "https://web-alpac.onrender.com";

        private static readonly Color BgColor   = Color.FromRgb(238, 243, 250);
        private static readonly Color NavyColor = Color.FromRgb(10, 37, 84);
        private static readonly Color BlueColor = Color.FromRgb(0, 79, 144);
        private static readonly Color RedColor  = Color.FromRgb(176, 24, 28);

        public async Task<(string ImageUrl, string Code)> GenerateQrCodeAsync(string? redirectUrl = null, string? logoUrl = null)
        {
            redirectUrl = string.IsNullOrWhiteSpace(redirectUrl) ? DefaultUrl : redirectUrl;

            var code = GenerateUniqueCode();
            var content = AppendCode(redirectUrl, code);
            
            var logoBytes = await ResolveLogoBytesAsync(logoUrl, default);

            var png = RenderQrPng(content, logoBytes);

            var imageUrl = await _s3StorageService.UploadImageAsync("qr-codes", "generated", Convert.ToBase64String(png), default);

            return (imageUrl, code);
        }

        private static string GenerateUniqueCode(int length = 8)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return string.Create(length, chars, (span, alphabet) =>
            {
                for (int i = 0; i < span.Length; i++)
                    span[i] = alphabet[System.Security.Cryptography.RandomNumberGenerator.GetInt32(alphabet.Length)];
            });
        }

        private static string AppendCode(string url, string code)
        {
            var sep = url.Contains('?') ? "&" : "?";
            return $"{url}{sep}code={Uri.EscapeDataString(code)}";
        }

        #region Transformar logo en Base64
        private async Task<byte[]?> ResolveLogoBytesAsync(string? logo, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(logo)) return null;

            try
            {
                logo = logo.Trim();

                // data:image/png;base64,AAAA...
                if (logo.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
                {
                    var comma = logo.IndexOf(',');
                    return comma < 0 ? null : Convert.FromBase64String(logo[(comma + 1)..]);
                }

                // URL http(s)
                if (Uri.TryCreate(logo, UriKind.Absolute, out var uri) &&
                    (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp))
                {
                    using var http = _httpClientFactory.CreateClient();
                    http.Timeout = TimeSpan.FromSeconds(5);
                    return await http.GetByteArrayAsync(uri, ct);
                }

                // base64 a secas
                return Convert.FromBase64String(logo);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Carga Imagen de logo
        private static Image<Rgba32>? TryLoadLogo(byte[]? bytes)
        {
            if (bytes is null || bytes.Length == 0) return null;

            try
            {
                var img = Image.Load<Rgba32>(bytes);
                TrimWhiteMargin(img);
                return img;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private static void TrimWhiteMargin(Image<Rgba32> img)
        {
            int minX = img.Width, minY = img.Height, maxX = -1, maxY = -1;

            img.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    var row = accessor.GetRowSpan(y);
                    for (int x = 0; x < row.Length; x++)
                    {
                        var p = row[x];
                        if (p.A > 10 && (p.R < 235 || p.G < 235 || p.B < 235))
                        {
                            if (x < minX) minX = x;
                            if (x > maxX) maxX = x;
                            if (y < minY) minY = y;
                            if (y > maxY) maxY = y;
                        }
                    }
                }
            });

            if (maxX >= minX && maxY >= minY)
            {
                img.Mutate(c => c.Crop(new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1)));
            }
        }

        #region Renderiza imagen png del qr
        public static byte[] RenderQrPng(string content, byte[]? logoBytes = null)
        {
            using var generator = new QRCodeGenerator();
            using var qrData = generator.CreateQrCode(content, QRCodeGenerator.ECCLevel.H);

            var matrix = ReadMatrix(qrData, out int n);

            using var logo = TryLoadLogo(logoBytes);
            bool hasLogo   = logo is not null;

            // Configuración del ancho del qr y dimenciones
            int top     = 0;
            int bottom  = 0;
            int width   = PaperWidthPx;
            int U       = Math.Max(1, (width - 2 * SideMargin) / (n + 8));
            int Q       = n * U;
            int padding = 4 * U;
            int card    = Q + 2 * padding;
            int margin  = (width - card) / 2;
            int cardY   = SideMargin + top;
            int height  = cardY + card + 20 + bottom;
            int originX = margin + padding;
            int originY = cardY + padding;
            float radius = 2.5f * U;

            // Zona libre cuadrada del logo (solo si hay logo)
            int K = 0, k0 = 0;
            if (hasLogo)
            {
                K = (int)Math.Round(n * 0.27);
                if (K % 2 != n % 2) K++;
                while ((double)K / n > 0.30) K -= 2;
                k0 = (n - K) / 2;
            }

            // Un único degradado diagonal para todo el QR
            var gradient = new LinearGradientBrush(
                new PointF(originX, originY),
                new PointF(originX + Q, originY + Q),
                GradientRepetitionMode.None,
                new ColorStop(0f, BlueColor),
                new ColorStop(1f, RedColor));
            
            using var canvas = new Image<Rgba32>(width, height);
            canvas.Mutate(ctx => ctx.Fill(BgColor));

            // Sombra de la tarjeta
            using (var shadow = new Image<Rgba32>(width, height))
            {
                shadow.Mutate(ctx =>
                {
                    ctx.Fill(Color.FromRgba(10, 37, 84, 60), RoundedRect(margin, cardY + 6, card, card, radius));
                    ctx.GaussianBlur(5f);
                });
                canvas.Mutate(ctx => ctx.DrawImage(shadow, 1f));
            }

            canvas.Mutate(ctx =>
            {
                // Tarjeta blanca
                ctx.Fill(Color.White, RoundedRect(margin, cardY, card, card, radius));

                // Módulos de datos
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (!matrix[row][col] || IsInFinderPattern(row, col, n)) continue;
                        if (hasLogo && row >= k0 && row < k0 + K && col >= k0 && col < k0 + K) continue;

                        float inset = U * 0.03f;
                        ctx.Fill(gradient, RoundedRect(
                            originX + col * U + inset,
                            originY + row * U + inset,
                            U - 2 * inset,
                            U - 2 * inset,
                            U * 0.22f));
                    }
                }

                DrawEye(ctx, gradient, originX, originY, U);
                DrawEye(ctx, gradient, originX + (n - 7) * U, originY, U);
                DrawEye(ctx, gradient, originX, originY + (n - 7) * U, U);

                if (hasLogo)
                {
                    int plate = K * U;
                    ctx.Fill(Color.White, RoundedRect(originX + k0 * U, originY + k0 * U, plate, plate, U * 0.5f));
                }
            });

            // Logo centrado: 80% del lado de la placa
            if (hasLogo)
            {
                int plate = K * U;
                int maxSide = (int)(plate * 0.8);
                double scale = Math.Min((double)maxSide / logo!.Width, (double)maxSide / logo.Height);
                int lw = Math.Max(1, (int)Math.Round(logo.Width * scale));
                int lh = Math.Max(1, (int)Math.Round(logo.Height * scale));
                logo.Mutate(ctx => ctx.Resize(lw, lh, KnownResamplers.Lanczos3));

                int lx = originX + k0 * U + (plate - lw) / 2;
                int ly = originY + k0 * U + (plate - lh) / 2;
                canvas.Mutate(ctx => ctx.DrawImage(logo, new Point(lx, ly), 1f));
            }

            using var ms = new MemoryStream();
            canvas.SaveAsPng(ms);
            return ms.ToArray();
        }
        #endregion

        private static bool[][] ReadMatrix(QRCodeData data, out int n)
        {
            n = 17 + 4 * data.Version;
            var modules = data.ModuleMatrix;
            int offset = (modules.Count - n) / 2;

            var result = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new bool[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = modules[i + offset][j + offset];
                }
            }
            return result;
        }

        private static bool IsInFinderPattern(int row, int col, int n) =>
            (row < 7 && col < 7) ||
            (row < 7 && col >= n - 7) ||
            (row >= n - 7 && col < 7);

        // Ojo: anillo exterior 7x7, hueco blanco 5x5, centro 3x3
        private static void DrawEye(IImageProcessingContext ctx, Brush brush, int x, int y, int U)
        {
            ctx.Fill(brush, RoundedRect(x, y, 7 * U, 7 * U, 1.2f * U));
            ctx.Fill(Color.White, RoundedRect(x + U, y + U, 5 * U, 5 * U, 0.7f * U));
            ctx.Fill(brush, RoundedRect(x + 2 * U, y + 2 * U, 3 * U, 3 * U, 0.5f * U));
        }

        // Rectángulo con esquinas redondeadas.
        // AddArc(rect, rotación, ángulo inicial, barrido)
        private static IPath RoundedRect(float x, float y, float w, float h, float r)
        {
            r = Math.Min(r, Math.Min(w, h) / 2);

            var pb = new PathBuilder();
            pb.AddLine(x + r, y, x + w - r, y);
            pb.AddArc(new RectangleF(x + w - 2 * r, y, 2 * r, 2 * r), 0, 270, 90);
            pb.AddLine(x + w, y + r, x + w, y + h - r);
            pb.AddArc(new RectangleF(x + w - 2 * r, y + h - 2 * r, 2 * r, 2 * r), 0, 0, 90);
            pb.AddLine(x + w - r, y + h, x + r, y + h);
            pb.AddArc(new RectangleF(x, y + h - 2 * r, 2 * r, 2 * r), 0, 90, 90);
            pb.AddLine(x, y + h - r, x, y + r);
            pb.AddArc(new RectangleF(x, y, 2 * r, 2 * r), 0, 180, 90);
            pb.CloseFigure();
            return pb.Build();
        }

        private static void DrawHeader(IImageProcessingContext ctx, int width, int height, string text)
        {
            ctx.Fill(NavyColor, new RectangularPolygon(0, 0, width, height));

            var options = new RichTextOptions(GetFont(height * 0.38f))
            {
                Origin = new PointF(width / 2f, height / 2f),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            ctx.DrawText(options, text, Color.White);
        }

        private static Font GetFont(float size)
        {
            FontFamily family;
            if (SystemFonts.TryGet("Arial", out var arial)) family = arial;
            else if (SystemFonts.TryGet("DejaVu Sans", out var dejavu)) family = dejavu;
            else family = SystemFonts.Collection.Families.First();

            return family.CreateFont(size, FontStyle.Bold);
        }

        #endregion

        #region Generar codigo de barra
        private const int BarcodeLength        = 13;
        private const int BarcodeHeight        = 130;
        private const int BarcodeCardPadding   = 24;
        private const int BarcodeLogoHeight    = 52;
        private const string BarcodeAlphabet   = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

        public async Task<(string ImageUrl, string Code)> GenerateBarcodeAsync(string? logoUrl = null)
        {
            var code = GenerateUniqueBarcodeValue();
 
            var logoBytes = await ResolveLogoBytesAsync(logoUrl, default);
            var png = RenderBarcodePng(code, logoBytes);
 
            var imageUrl = await _s3StorageService.UploadImageAsync("barcodes", "generated", Convert.ToBase64String(png), default);
 
            return (imageUrl, code);
        }
 
        private static string GenerateUniqueBarcodeValue(int length = BarcodeLength)
        {
            return string.Create(length, BarcodeAlphabet, (span, alphabet) =>
            {
                for (int i = 0; i < span.Length; i++)
                    span[i] = alphabet[System.Security.Cryptography.RandomNumberGenerator.GetInt32(alphabet.Length)];
            });
        }
 
        #region Renderiza imagen png del codigo de barras
        public static byte[] RenderBarcodePng(string code, byte[]? logoBytes = null)
        {
            var hints = new Dictionary<EncodeHintType, object> { { EncodeHintType.MARGIN, 0 } };
            BitMatrix matrix = new MultiFormatWriter().encode(code, BarcodeFormat.CODE_128, 0, 1, hints);
            int modules = matrix.Width;
 
            using var logo = TryLoadLogo(logoBytes);
            bool hasLogo = logo is not null;

            //Configuración de las dimenciones, codigo de barra
            int width       = PaperWidthPx;
            int card        = width - 2 * SideMargin;
            int cardX       = SideMargin;
            int cardY       = SideMargin;
            int available   = card - 2 * BarcodeCardPadding;
            int moduleW     = Math.Max(1, available / modules);
            int barcodeW    = modules * moduleW;
            int barcodeX    = (width - barcodeW) / 2;
 
            int logoBlock   = hasLogo ? BarcodeLogoHeight + 16 : 0;
            int barcodeY    = cardY + BarcodeCardPadding + logoBlock;
            int textY       = barcodeY + BarcodeHeight + 14;
            int textHeight  = 42;
            int pillY       = textY + textHeight + 14;
            const int pillW = 100, pillH = 10;
            int cardH       = pillY + pillH + BarcodeCardPadding - cardY;
            int height      = cardY + cardH + SideMargin;
            float radius    = 28f;
 
            var gradient = new LinearGradientBrush(
                new PointF(barcodeX, 0),
                new PointF(barcodeX + barcodeW, 0),
                GradientRepetitionMode.None,
                new ColorStop(0f, BlueColor),
                new ColorStop(1f, RedColor)
            );
 
            using var canvas = new Image<Rgba32>(width, height);
            canvas.Mutate(ctx => ctx.Fill(BgColor));
 
            // Sombra de la tarjeta
            using (var shadow = new Image<Rgba32>(width, height))
            {
                shadow.Mutate(ctx =>
                {
                    ctx.Fill(Color.FromRgba(10, 37, 84, 60), RoundedRect(cardX, cardY + 6, card, cardH, radius));
                    ctx.GaussianBlur(5f);
                });
                canvas.Mutate(ctx => ctx.DrawImage(shadow, 1f));
            }
 
            canvas.Mutate(ctx =>
            {
                // Tarjeta blanca
                ctx.Fill(Color.White, RoundedRect(cardX, cardY, card, cardH, radius));
 
                int i = 0;
                while (i < modules)
                {
                    if (!matrix[i, 0]) { i++; continue; }
                    int start = i;
                    while (i < modules && matrix[i, 0]) i++;
 
                    ctx.Fill(gradient, new RectangularPolygon(
                        barcodeX + start * moduleW,
                        barcodeY,
                        (i - start) * moduleW,
                        BarcodeHeight));
                }
 
                // Código en texto, centrado
                var textOptions = new RichTextOptions(GetFont(34f))
                {
                    Origin = new PointF(width / 2f, textY),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top
                };
                ctx.DrawText(textOptions, code, NavyColor);
 
                ctx.Fill(Color.FromRgb(224, 43, 39),
                    RoundedRect((width - pillW) / 2f, pillY, pillW, pillH, pillH / 2f));
            });
 
            // Logo centrado arriba de las barras
            if (hasLogo)
            {
                double scale = (double)BarcodeLogoHeight / logo!.Height;
                int lw = Math.Max(1, (int)Math.Round(logo.Width * scale));
                logo.Mutate(ctx => ctx.Resize(lw, BarcodeLogoHeight, KnownResamplers.Lanczos3));
 
                int lx = (width - lw) / 2;
                int ly = cardY + BarcodeCardPadding;
                canvas.Mutate(ctx => ctx.DrawImage(logo, new Point(lx, ly), 1f));
            }
 
            using var ms = new MemoryStream();
            canvas.SaveAsPng(ms);
            return ms.ToArray();
        }
        #endregion
 
        #endregion
    }
}