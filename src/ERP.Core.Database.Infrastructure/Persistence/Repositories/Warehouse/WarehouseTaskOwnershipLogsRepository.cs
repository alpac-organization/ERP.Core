using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class WarehouseTaskOwnershipLogsRepository(ErpDbContext context)
    : Repository<WarehouseTaskOwnershipLog>(context), IWarehouseTaskOwnershipLogsRepository
{
    public async Task<WarehouseTaskOwnershipLog> InsertWarehouseTaskOwnershipLog(WarehouseTaskOwnershipLog ownershipLog)
    {
        var record = await _context.WarehouseTaskOwnershipLogs.AddAsync(ownershipLog);
        return record.Entity;
    }
}
