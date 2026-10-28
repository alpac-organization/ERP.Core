using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class SupplyRequestItemRepository(ErpDbContext context) : Repository<SupplyRequestItem>(context), ISupplyRequestItemRepository
    {
        public async Task<SupplyRequestItem> RegisterSupplyRequestItem(SupplyRequestItem payload)
        {
            var record = await _context.SupplyRequestItems.AddAsync(payload);
            return record.Entity;
        }
    }
}