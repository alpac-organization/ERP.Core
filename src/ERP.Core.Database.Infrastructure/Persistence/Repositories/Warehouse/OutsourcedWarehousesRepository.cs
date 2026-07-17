using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class OutsourcedWarehousesRepository(ErpDbContext context): Repository<OutsourcedWarehouse>(context), IOutsourcedWarehousesRepository
{
    public async Task<OutsourcedWarehouse> RegisterOutsourcedWarehouse(OutsourcedWarehouse payload)
    {
        var record = await _context.OutsourcedWarehouses.AddAsync(payload);
        return record.Entity;
    }
}