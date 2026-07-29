using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class PurchaseOrdersRepository(ErpDbContext _context) : Repository<PurchaseOrder>(_context), IPurchaseOrdersRepository
    {
        public async Task<PurchaseOrder> RegisterPurchaseOrder(PurchaseOrder payload)
        {
            var record = await _context.PurchaseOrders.AddAsync(payload);
            return record.Entity;
        }
    }
    
}