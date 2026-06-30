using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class WarehousesRepository(ErpDbContext context): Repository<Warehouses>(context), IWarehousesRepository
{
    public async Task<Warehouses> RegisterWarehouse(Warehouses payload)
    {
        var record = await _context.Warehouses.AddAsync(payload);
        return record.Entity;
    }
}