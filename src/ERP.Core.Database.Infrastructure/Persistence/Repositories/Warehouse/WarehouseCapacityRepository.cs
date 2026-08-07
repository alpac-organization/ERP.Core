using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class WarehouseCapacityRepository(ErpDbContext context): Repository<WarehouseCapacity>(context), IWarehouseCapacityRepository
{
    public async Task<WarehouseCapacity> RegisterWarehouseCapacity(WarehouseCapacity payload)
    {
        var record = await _context.WarehouseCapacities.AddAsync(payload);
        return record.Entity;
    }
}