using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class WarehouseReceiptsManaguaRepository(ErpDbContext context)
    : Repository<WarehouseReceiptsManagua>(context), IWarehouseReceiptsManaguaRepository
{
    public async Task<WarehouseReceiptsManagua> GenerateWarehouseReceiptsManagua(WarehouseReceiptsManagua payload)
    {
        var record = await _context.WarehouseReceiptsManagua.AddAsync(payload);
        return record.Entity;
    }
}