using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class PurchaseRequestItemsRepository(ErpDbContext _context) : Repository<PurchaseRequestItem>(_context), IPurchaseRequestItemsRepository
    {
        public async Task<PurchaseRequestItem> RegisterPurchaseRequestItem(PurchaseRequestItem payload)
        {
            var record = await _context.PurchaseRequestItems.AddAsync(payload);
            return record.Entity;
        }
    }
    
}