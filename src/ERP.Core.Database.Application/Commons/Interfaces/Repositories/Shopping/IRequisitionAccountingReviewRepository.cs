using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IRequisitionAccountingReviewRepository : IRepository<RequisitionAccountingReview>
    {
        Task<RequisitionAccountingReview> RegisterRequisitionAccountingReview(RequisitionAccountingReview payload);
    }
}
