using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Application.Commons.Interfaces.Services
{
    public interface ICodeGenerator
    {
        public string GenerateModuleCode(string subject);

        public string GenerateUsername(string subject);

        public Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToServiceOrder();
        public Task<(bool IsSuccess, string Code)> GenerateUniqueOperationalOrderCodeAsync();

        Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToPurchaseRequest(PurchaseRequestType purchaseRequestType, Guid branchId);

        Task<(bool IsSuccess, string Code)> GenerateUniqueStorageCodeAsync(StorageEntityType entityType, Guid sectionId, CancellationToken ct = default);

        Task<(bool IsSuccess, IReadOnlyList<string> Codes)> GenerateUniqueStorageCodesAsync(StorageEntityType entityType, Guid sectionId, int count, CancellationToken ct = default);

        public string GeneratePositionCode(string lotCode, int row, int column);

        Task<(bool IsSuccess, CustomerCodesToRegister CustomerCodes)> GenerateUniqueCustomerCodesAsync(Guid companyId, int branchCount, CancellationToken ct = default);

        Task<(bool IsSuccess, string Code)> GenerateUniqueWorkAreaCodeAsync(Guid companyId, CancellationToken ct = default);

        Task<(bool IsSuccess, string Code)> GenerateUniqueCostCenterCodeAsync(Guid areaId, CancellationToken ct = default);
        Task<(bool IsSuccess, string Code)> GenerateUniqueSectionCodeAsync(Guid warehouseId, SectionType sectionType, SectionStorageType sectionStorageType, CancellationToken ct = default);
        Task<(bool IsSuccess, string Code)> GenerateUniqueReceptionEntranceCodeAsync(CancellationToken ct = default);

        Task<string> GenerateQrCodeAsync(string redirectUrl, string? logoBase64 = null, CancellationToken cancellationToken = default);
    }
}