using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class UnloadingMachineryAssignmentsManaguaRepository(ErpDbContext context)
    : Repository<UnloadingMachineryAssignmentsManagua>(context), IUnloadingMachineryAssignmentsManaguaRepository
{
    public async Task<UnloadingMachineryAssignmentsManagua> SetUnloadingMachineryAssignmentsManagua(UnloadingMachineryAssignmentsManagua payload)
    {
        var record = await _context.UnloadingMachineryAssignmentsManagua.AddAsync(payload);
        return record.Entity;
    }
}