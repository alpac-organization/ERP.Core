using NanoidDotNet;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

using ERP.Core.Database.Application.Commons.Interfaces.Services;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using ERP.Core.Database.Domain.Enums;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

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
            PurchaseRequestType.Eventual => "ENV",
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

        #region Metodo para generar codigo producto
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueProductCode(
            Guid companyId, CancellationToken ct
        )
        {
            var company = await _unitOfWork.Companies.Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == companyId && c.DeletedAt == null, ct);

            if (company is null || string.IsNullOrWhiteSpace(company.Code))
            {
                return (false, string.Empty);
            }

            var prefix = $"{company.Code}-";

            var existingCodes = await _unitOfWork.Products.Entities
                .AsNoTracking()
                .Where(p => p.Code != null && p.Code.StartsWith(prefix))
                .Select(p => p.Code)
                .ToListAsync(ct);

            int maxSequence = GetMaxSequence(prefix, existingCodes);
            return (true, $"{prefix}{maxSequence + 1:D3}");
        }
        #endregion Products
    }
}