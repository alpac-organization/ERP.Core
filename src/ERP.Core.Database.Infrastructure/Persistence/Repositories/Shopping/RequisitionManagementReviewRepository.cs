using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class RequisitionManagementReviewRepository(ErpDbContext _context) : Repository<RequisitionManagementReview>(_context), IRequisitionManagementReviewRepository
    {
        public async Task<RequisitionManagementReview> RegisterRequisitionManagementReview(RequisitionManagementReview payload)
        {
            var record = await _context.RequisitionManagementReviews.AddAsync(payload);
            return record.Entity;
        }
    }
    
}