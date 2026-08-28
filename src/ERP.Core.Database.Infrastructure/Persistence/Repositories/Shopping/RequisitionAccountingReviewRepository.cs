using ERP.Core.Database.Domain.Entities.Accounting;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class RequisitionAccountingReviewRepository(ErpDbContext _context) : Repository<RequisitionAccountingReview>(_context), IRequisitionAccountingReviewRepository
    {
        public async Task<RequisitionAccountingReview> RegisterRequisitionAccountingReview(RequisitionAccountingReview payload)
        {
            var record = await _context.RequisitionAccountingReviews.AddAsync(payload);
            return record.Entity;
        }
    }
    
}
