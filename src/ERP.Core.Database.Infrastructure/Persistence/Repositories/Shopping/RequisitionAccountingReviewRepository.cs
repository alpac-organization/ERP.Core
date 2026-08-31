using ERP.Core.Database.Domain.Entities.Accounting;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class PurchaseRequestsReviewedAccountingRepository(ErpDbContext _context) : Repository<PurchaseRequestsReviewedAccounting>(_context), IPurchaseRequestsReviewedAccountingRepository
    {
        public async Task<PurchaseRequestsReviewedAccounting> RegisterPurchaseRequestsReviewedAccounting(PurchaseRequestsReviewedAccounting payload)
        {
            var record = await _context.PurchaseRequestsReviewedAccountings.AddAsync(payload);
            return record.Entity;
        }
    }
    
}
