using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IRequisitionManagementReviewRepository : IRepository<RequisitionManagementReview>
    {
        Task<RequisitionManagementReview> RegisterRequisitionManagementReview(RequisitionManagementReview payload);
    }
}