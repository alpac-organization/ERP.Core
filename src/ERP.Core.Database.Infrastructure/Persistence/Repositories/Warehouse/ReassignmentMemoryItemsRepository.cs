using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class ReassignmentMemoryItemsRepository(ErpDbContext context)
    : Repository<ReassignmentMemoryItems>(context), IReassignmentMemoryItemsRepository
{
    public async Task<ReassignmentMemoryItems> InsertReassignmentMemoryItem(ReassignmentMemoryItems memoryItem)
    {
        var record = await _context.ReassignmentMemoryItems.AddAsync(memoryItem);
        return record.Entity;
    }
}