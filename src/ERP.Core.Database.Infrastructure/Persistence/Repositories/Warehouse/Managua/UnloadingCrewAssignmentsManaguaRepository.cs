using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class UnloadingCrewAssignmentsManaguaRepository(ErpDbContext context)
    : Repository<UnloadingCrewAssignmentsManagua>(context), IUnloadingCrewAssignmentsManaguaRepository
{
    public async Task<UnloadingCrewAssignmentsManagua> SetUnloadingCrewAssignmentsManagua(UnloadingCrewAssignmentsManagua payload)
    {
        var record = await _context.UnloadingCrewAssignmentsManagua.AddAsync(payload);
        return record.Entity;
    }
}