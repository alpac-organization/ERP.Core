using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class PurchaseRequestsRepository(ErpDbContext _context) : Repository<PurchaseRequest>(_context), IPurchaseRequestsRepository
    {
        public async Task<PurchaseRequest> RegisterPurchaseRequest(PurchaseRequest payload)
        {
            var record = await _context.PurchaseRequests.AddAsync(payload);
            return record.Entity;
        }
    }
    
}