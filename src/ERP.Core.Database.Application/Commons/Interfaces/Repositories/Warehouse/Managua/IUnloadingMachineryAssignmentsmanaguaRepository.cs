using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IUnloadingMachineryAssignmentsManaguaRepository : IRepository<UnloadingMachineryAssignmentsManagua>
{
    Task<UnloadingMachineryAssignmentsManagua> SetUnloadingMachineryAssignmentsManagua(UnloadingMachineryAssignmentsManagua machineryAssignment);
}