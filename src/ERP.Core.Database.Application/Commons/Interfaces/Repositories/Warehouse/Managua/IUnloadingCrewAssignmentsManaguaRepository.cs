using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IUnloadingCrewAssignmentsManaguaRepository : IRepository<UnloadingCrewAssignmentsManagua>
{
    Task<UnloadingCrewAssignmentsManagua> SetUnloadingCrewAssignmentsManagua(UnloadingCrewAssignmentsManagua crewAssignment);
}