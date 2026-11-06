using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class InventoryOutputsItemRepository(ErpDbContext _context) : Repository<InventoryOutputsItem>(_context), IInventoryOutputsItemRepository
    {
        public async Task<InventoryOutputsItem> RegisterInventoryOutputItem(InventoryOutputsItem payload)
        {
            var record = await _context.InventoryOutputsItems.AddAsync(payload);
            return record.Entity;
        }
    }
}