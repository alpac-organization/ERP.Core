using QRCoder;
using NanoidDotNet;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Application.Commons.Interfaces.AWS;

using ZXing;
using ZXing.Common;
using SkiaSharp;

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

        private static string GetPaymentMethodTypeCode(PaymentMethodType type) => type switch
        {
            PaymentMethodType.ACH => "ACH",
            PaymentMethodType.LocalTransfer => "LOCAL",
            PaymentMethodType.Check => "CHECK",
            PaymentMethodType.Cash => "CASH",
            PaymentMethodType.InternationalWire => "INTERNATIONAL",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Tipo de método de pago no soportado.")
        };

        public async Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToPurchaseRequest(PurchaseRequestType purchaseRequestType, Guid branchId)
        {
            var branch = await _unitOfWork.Branches.Entities
                .AsNoTracking()
                .Include(b => b.Company)
                .FirstOrDefaultAsync(b => b.Id == branchId);

            if (branch is null
                || string.IsNullOrWhiteSpace(branch.BranchCode)
                || string.IsNullOrWhiteSpace(branch.Company?.Code))
            {
                return (false, string.Empty);
            }

            var typeCode = GetTypeCode(purchaseRequestType);
            var prefix = $"{branch.Company.Code.ToUpper()}-{branch.BranchCode.ToUpper()}-{typeCode}-";

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
                    .ThenInclude(b => b.Company)
                .FirstOrDefaultAsync(pr => pr.Id == purchaseRequestId, ct);

            if (request?.Branch is null
                || string.IsNullOrWhiteSpace(request.Branch.BranchCode)
                || string.IsNullOrWhiteSpace(request.Branch.Company?.Code))
            {
                return (false, string.Empty);
            }

            var prefix = $"{request.Branch.Company.Code.ToUpper()}-{request.Branch.BranchCode.ToUpper()}-OC-";

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

        public async Task<(bool IsSuccess, string Code)> GenerateUniquePaymentRequestCodeAsync(
            Guid branchId,
            PaymentMethodType paymentMethodType,
            CancellationToken ct = default)
        {
            var branch = await _unitOfWork.Branches.Entities
                .AsNoTracking()
                .Include(b => b.Company)
                .FirstOrDefaultAsync(b => b.Id == branchId, ct);

            if (branch is null
                || string.IsNullOrWhiteSpace(branch.BranchCode)
                || string.IsNullOrWhiteSpace(branch.Company?.Code))
            {
                return (false, string.Empty);
            }

            var methodCode = GetPaymentMethodTypeCode(paymentMethodType);
            var prefix = $"{branch.Company.Code.ToUpper()}-{branch.BranchCode.ToUpper()}-{methodCode}-";

            return (true, $"{prefix}01");
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

        private static readonly SKColor BgColor   = new SKColor(238, 243, 250);
        private static readonly SKColor NavyColor = new SKColor(10, 37, 84);
        private static readonly SKColor BlueColor = new SKColor(0, 79, 144);
        private static readonly SKColor RedColor  = new SKColor(176, 24, 28);

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
        private static SKBitmap? TryLoadLogo(byte[]? bytes)
        {
            if (bytes is null || bytes.Length == 0) return null;

            try
            {
                var img = SKBitmap.Decode(bytes);
                if (img is null) return null;
                return TrimWhiteMargin(img);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        // Devuelve el bitmap recortado (o el mismo si no hay nada que recortar)
        private static SKBitmap TrimWhiteMargin(SKBitmap img)
        {
            int w = img.Width, h = img.Height;
            int minX = w, minY = h, maxX = -1, maxY = -1;

            var pixels = img.Pixels; // SKColor sin premultiplicar

            for (int y = 0; y < h; y++)
            {
                int offset = y * w;
                for (int x = 0; x < w; x++)
                {
                    var p = pixels[offset + x];
                    if (p.Alpha > 10 && (p.Red < 235 || p.Green < 235 || p.Blue < 235))
                    {
                        if (x < minX) minX = x;
                        if (x > maxX) maxX = x;
                        if (y < minY) minY = y;
                        if (y > maxY) maxY = y;
                    }
                }
            }

            if (maxX >= minX && maxY >= minY)
            {
                var rect = new SKRectI(minX, minY, maxX + 1, maxY + 1);
                using var subset = new SKBitmap();
                if (img.ExtractSubset(subset, rect))
                {
                    var cropped = subset.Copy();
                    img.Dispose();
                    return cropped;
                }
            }

            return img;
        }

        // Redimensiona el logo con buena calidad (reduce con mipmaps, amplía con cúbico)
        private static SKBitmap ResizeLogo(SKBitmap src, int lw, int lh)
        {
            var info = new SKImageInfo(lw, lh, src.ColorType, src.AlphaType);
            var sampling = (lw > src.Width || lh > src.Height)
                ? new SKSamplingOptions(SKCubicResampler.CatmullRom)
                : new SKSamplingOptions(SKFilterMode.Linear, SKMipmapMode.Linear);

            return src.Resize(info, sampling) ?? src.Copy();
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
            using var shader = SKShader.CreateLinearGradient(
                new SKPoint(originX, originY),
                new SKPoint(originX + Q, originY + Q),
                new[] { BlueColor, RedColor },
                new[] { 0f, 1f },
                SKShaderTileMode.Clamp);
            using var gradient = new SKPaint { Shader = shader, IsAntialias = true };

            using var white = new SKPaint { Color = SKColors.White, IsAntialias = true };

            using var surface = SKSurface.Create(new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Premul));
            var canvas = surface.Canvas;
            canvas.Clear(BgColor);

            // Sombra de la tarjeta
            using (var blur = SKImageFilter.CreateBlur(5f, 5f))
            using (var shadowPaint = new SKPaint { Color = new SKColor(10, 37, 84, 60), IsAntialias = true, ImageFilter = blur })
            {
                canvas.DrawRoundRect(RoundedRect(margin, cardY + 6, card, card, radius), shadowPaint);
            }

            // Tarjeta blanca
            canvas.DrawRoundRect(RoundedRect(margin, cardY, card, card, radius), white);

            // Módulos de datos
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (!matrix[row][col] || IsInFinderPattern(row, col, n)) continue;
                    if (hasLogo && row >= k0 && row < k0 + K && col >= k0 && col < k0 + K) continue;

                    float inset = U * 0.03f;
                    canvas.DrawRoundRect(RoundedRect(
                        originX + col * U + inset,
                        originY + row * U + inset,
                        U - 2 * inset,
                        U - 2 * inset,
                        U * 0.22f), gradient);
                }
            }

            DrawEye(canvas, gradient, originX, originY, U);
            DrawEye(canvas, gradient, originX + (n - 7) * U, originY, U);
            DrawEye(canvas, gradient, originX, originY + (n - 7) * U, U);

            if (hasLogo)
            {
                int plate = K * U;
                canvas.DrawRoundRect(RoundedRect(originX + k0 * U, originY + k0 * U, plate, plate, U * 0.5f), white);
            }

            // Logo centrado: 80% del lado de la placa
            if (hasLogo)
            {
                int plate = K * U;
                int maxSide = (int)(plate * 0.8);
                double scale = Math.Min((double)maxSide / logo!.Width, (double)maxSide / logo.Height);
                int lw = Math.Max(1, (int)Math.Round(logo.Width * scale));
                int lh = Math.Max(1, (int)Math.Round(logo.Height * scale));

                using var resized = ResizeLogo(logo, lw, lh);

                int lx = originX + k0 * U + (plate - lw) / 2;
                int ly = originY + k0 * U + (plate - lh) / 2;

                using var logoImage = SKImage.FromBitmap(resized);
                canvas.DrawImage(logoImage, lx, ly, new SKSamplingOptions(SKFilterMode.Linear, SKMipmapMode.None), null);
            }

            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
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
        private static void DrawEye(SKCanvas canvas, SKPaint brush, int x, int y, int U)
        {
            using var white = new SKPaint { Color = SKColors.White, IsAntialias = true };

            canvas.DrawRoundRect(RoundedRect(x, y, 7 * U, 7 * U, 1.2f * U), brush);
            canvas.DrawRoundRect(RoundedRect(x + U, y + U, 5 * U, 5 * U, 0.7f * U), white);
            canvas.DrawRoundRect(RoundedRect(x + 2 * U, y + 2 * U, 3 * U, 3 * U, 0.5f * U), brush);
        }

        // Rectángulo con esquinas redondeadas.
        private static SKRoundRect RoundedRect(float x, float y, float w, float h, float r)
        {
            r = Math.Min(r, Math.Min(w, h) / 2);
            return new SKRoundRect(new SKRect(x, y, x + w, y + h), r, r);
        }

        private static void DrawHeader(SKCanvas canvas, int width, int height, string text)
        {
            using var bg = new SKPaint { Color = NavyColor };
            canvas.DrawRect(new SKRect(0, 0, width, height), bg);

            using var typeface = GetTypeface();
            using var font = new SKFont(typeface, height * 0.38f) { Edging = SKFontEdging.SubpixelAntialias, Subpixel = true };
            using var paint = new SKPaint { Color = SKColors.White, IsAntialias = true };

            var m = font.Metrics;
            float baseline = height / 2f - (m.Ascent + m.Descent) / 2f; // centrado vertical
            canvas.DrawText(text, width / 2f, baseline, SKTextAlign.Center, font, paint);
        }

        private static SKTypeface GetTypeface()
        {
            var bold = SKFontStyle.Bold;

            var arial = SKTypeface.FromFamilyName("Arial", bold);
            if (arial is not null && arial.FamilyName.Equals("Arial", StringComparison.OrdinalIgnoreCase))
                return arial;

            var dejavu = SKTypeface.FromFamilyName("DejaVu Sans", bold);
            if (dejavu is not null && dejavu.FamilyName.Equals("DejaVu Sans", StringComparison.OrdinalIgnoreCase))
                return dejavu;

            return SKTypeface.FromFamilyName(null, bold) ?? SKTypeface.Default;
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

            using var shader = SKShader.CreateLinearGradient(
                new SKPoint(barcodeX, 0),
                new SKPoint(barcodeX + barcodeW, 0),
                new[] { BlueColor, RedColor },
                new[] { 0f, 1f },
                SKShaderTileMode.Clamp);
            using var gradient = new SKPaint { Shader = shader, IsAntialias = true };

            using var white = new SKPaint { Color = SKColors.White, IsAntialias = true };

            using var surface = SKSurface.Create(new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Premul));
            var canvas = surface.Canvas;
            canvas.Clear(BgColor);

            // Sombra de la tarjeta
            using (var blur = SKImageFilter.CreateBlur(5f, 5f))
            using (var shadowPaint = new SKPaint { Color = new SKColor(10, 37, 84, 60), IsAntialias = true, ImageFilter = blur })
            {
                canvas.DrawRoundRect(RoundedRect(cardX, cardY + 6, card, cardH, radius), shadowPaint);
            }

            // Tarjeta blanca
            canvas.DrawRoundRect(RoundedRect(cardX, cardY, card, cardH, radius), white);

            int i = 0;
            while (i < modules)
            {
                if (!matrix[i, 0]) { i++; continue; }
                int start = i;
                while (i < modules && matrix[i, 0]) i++;

                canvas.DrawRect(new SKRect(
                    barcodeX + start * moduleW,
                    barcodeY,
                    barcodeX + i * moduleW,
                    barcodeY + BarcodeHeight), gradient);
            }

            // Código en texto, centrado (borde superior en textY)
            using (var typeface = GetTypeface())
            using (var font = new SKFont(typeface, 34f) { Edging = SKFontEdging.SubpixelAntialias, Subpixel = true })
            using (var textPaint = new SKPaint { Color = NavyColor, IsAntialias = true })
            {
                float baseline = textY - font.Metrics.Ascent; // Ascent es negativo
                canvas.DrawText(code, width / 2f, baseline, SKTextAlign.Center, font, textPaint);
            }

            using (var pill = new SKPaint { Color = new SKColor(224, 43, 39), IsAntialias = true })
            {
                canvas.DrawRoundRect(RoundedRect((width - pillW) / 2f, pillY, pillW, pillH, pillH / 2f), pill);
            }

            // Logo centrado arriba de las barras
            if (hasLogo)
            {
                double scale = (double)BarcodeLogoHeight / logo!.Height;
                int lw = Math.Max(1, (int)Math.Round(logo.Width * scale));

                using var resized = ResizeLogo(logo, lw, BarcodeLogoHeight);

                int lx = (width - lw) / 2;
                int ly = cardY + BarcodeCardPadding;
                
                using var logoImage = SKImage.FromBitmap(resized);
                canvas.DrawImage(logoImage, lx, ly, new SKSamplingOptions(SKFilterMode.Linear, SKMipmapMode.None), null);
            }

            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }
        #endregion

        #endregion
    }
}