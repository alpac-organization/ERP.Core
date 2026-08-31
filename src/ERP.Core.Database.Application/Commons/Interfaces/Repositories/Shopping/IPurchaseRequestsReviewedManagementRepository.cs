using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IPurchaseRequestsReviewedManagementRepository : IRepository<PurchaseRequestsReviewedManagement>
    {
        Task<PurchaseRequestsReviewedManagement> RegisterRequisitionManagementReview(PurchaseRequestsReviewedManagement payload);
    }
}