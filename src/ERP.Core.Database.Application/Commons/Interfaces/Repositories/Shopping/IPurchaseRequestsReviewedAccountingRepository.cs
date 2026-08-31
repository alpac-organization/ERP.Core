using ERP.Core.Database.Domain.Entities.Accounting;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IPurchaseRequestsReviewedAccountingRepository : IRepository<PurchaseRequestsReviewedAccounting>
    {
        Task<PurchaseRequestsReviewedAccounting> RegisterPurchaseRequestsReviewedAccounting(PurchaseRequestsReviewedAccounting payload);
    }
}
