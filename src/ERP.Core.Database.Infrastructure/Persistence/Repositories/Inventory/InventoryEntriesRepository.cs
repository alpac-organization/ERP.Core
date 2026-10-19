using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class InventoryEntriesRepository(ErpDbContext _context) : Repository<InventoryEntry>(_context), IInventoryEntriesRepository
    {
        public async Task<InventoryEntry> RegisterInventoryEntry(InventoryEntry payload)
        {
            var record = await _context.InventoryEntries.AddAsync(payload);
            return record.Entity;
        }
    }
}