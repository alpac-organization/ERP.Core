using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class WarehouseAssignmentsManaguaRepository(ErpDbContext context)
    : Repository<WarehouseAssignmentsManagua>(context), IWarehouseAssignmentsManaguaRepository
{
    public async Task<WarehouseAssignmentsManagua> GetWarehouseAssignmentsManagua(WarehouseAssignmentsManagua payload)
    {
        var record = await _context.WarehouseAssignmentsManagua.AddAsync(payload);
        return record.Entity;
    }
}