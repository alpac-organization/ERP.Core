using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class InventoryOutputsRepository(ErpDbContext _context) : Repository<InventoryOutputs>(_context), IInventoryOutputsRepository
    {
        public async Task<InventoryOutputs> RegisterInventoryOutput(InventoryOutputs payload)
        {
            var record = await _context.InventoryOutputs.AddAsync(payload);
            return record.Entity;
        }
    }
}