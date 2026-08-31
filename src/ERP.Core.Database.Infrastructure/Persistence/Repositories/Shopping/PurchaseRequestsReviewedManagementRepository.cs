using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class PurchaseRequestsReviewedManagementRepository(ErpDbContext _context) : Repository<PurchaseRequestsReviewedManagement>(_context), IPurchaseRequestsReviewedManagementRepository
    {
        public async Task<PurchaseRequestsReviewedManagement> RegisterRequisitionManagementReview(PurchaseRequestsReviewedManagement payload)
        {
            var record = await _context.PurchaseRequestsReviewedManagements.AddAsync(payload);
            return record.Entity;
        }
    }
    
}   