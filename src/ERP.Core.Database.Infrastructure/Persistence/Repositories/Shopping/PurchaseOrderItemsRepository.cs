using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class PurchaseOrderItemsRepository(ErpDbContext _context) : Repository<PurchaseOrderItem>(_context), IPurchaseOrderItemsRepository
    {
        public async Task<PurchaseOrderItem> RegisterPurchaseOrderItem(PurchaseOrderItem payload)
        {
            var record = await _context.PurchaseOrderItems.AddAsync(payload);
            return record.Entity;
        }
    }
}
