using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class WarehouseTasksRepository(ErpDbContext context)
    : Repository<WarehouseTask>(context), IWarehouseTasksRepository
{
    public async Task<WarehouseTask> InsertWarehouseTask(WarehouseTask task)
    {
        var record = await _context.WarehouseTasks.AddAsync(task);
        return record.Entity;
    }
}
