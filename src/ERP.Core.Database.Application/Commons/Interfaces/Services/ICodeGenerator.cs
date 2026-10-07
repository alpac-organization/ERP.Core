using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Application.Commons.Interfaces.Services
{
    public interface ICodeGenerator
    {
        public string GenerateUsername(string subject);
        public string GenerateModuleCode(string subject);
        public string GeneratePositionCode(string lotCode, int row, int column);

        public Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToServiceOrder();
        public Task<(bool IsSuccess, string Code)> GenerateUniqueOperationalOrderCodeAsync();

        Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToPurchaseRequest(PurchaseRequestType purchaseRequestType, Guid branchId);

        Task<(bool IsSuccess, string Code)> GenerateUniquePurchaseOrderCode(Guid purchaseRequestId, CancellationToken ct = default);

        Task<(bool IsSuccess, string Code)> GenerateUniquePaymentRequestCodeAsync(
            Guid branchId,
            PaymentMethodType paymentMethodType,
            CancellationToken ct = default);

        Task<(bool IsSuccess, string Code)> GenerateUniqueStorageCodeAsync(StorageEntityType entityType, Guid sectionId, CancellationToken ct = default);

        Task<(bool IsSuccess, IReadOnlyList<string> Codes)> GenerateUniqueStorageCodesAsync(StorageEntityType entityType, Guid sectionId, int count, CancellationToken ct = default);

        Task<(bool IsSuccess, string Code)> GenerateUniqueWorkAreaCodeAsync(Guid companyId, CancellationToken ct = default);
        Task<(bool IsSuccess, string Code)> GenerateUniqueCostCenterCodeAsync(Guid areaId, CancellationToken ct = default);
        Task<(bool IsSuccess, string Code)> GenerateUniqueSectionCodeAsync(Guid warehouseId, SectionType sectionType, SectionStorageType sectionStorageType, CancellationToken ct = default);
        Task<(bool IsSuccess, string Code)> GenerateUniqueReceptionEntranceCodeAsync(CancellationToken ct = default);

        Task<(bool IsSuccess, string Code)> GenerateUniqueProductCode(Guid companyId, Guid categoryId, CancellationToken ct = default);

        Task<(string ImageUrl, string Code)> GenerateBarcodeAsync(string? logoUrl = null);
        Task<(string ImageUrl, string Code)> GenerateQrCodeAsync(string redirectUrl, string? logoUrl = null);
    }
}