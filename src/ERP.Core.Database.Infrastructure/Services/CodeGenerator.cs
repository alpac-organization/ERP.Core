using NanoidDotNet;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Infrastructure.Services
{
    public partial class CodeGenerator(IUnitOfWork _unitOfWork) : ICodeGenerator
    {
        [GeneratedRegex(@"[^a-zA-Z]")]
        private static partial Regex GenerateModuleCode();
        private readonly IUnitOfWork _unitOfWork = _unitOfWork;

        private static string GetTypeCode(PurchaseRequestType type) => type switch
        {
            PurchaseRequestType.Requisition => "REQ",
            PurchaseRequestType.Eventual    => "EVE",
            PurchaseRequestType.Monthly     => "MEN",
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

        #region Metodos Privados
        private static string GetStorageTypeCode(StorageEntityType entityType) => entityType switch
        {
            StorageEntityType.Lot => "LOT",
            StorageEntityType.Rack => "RACK",
            _ => throw new ArgumentOutOfRangeException(nameof(entityType), entityType, "Tipo de entidad de almacenamiento no soportado.")
        };

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
    }
}