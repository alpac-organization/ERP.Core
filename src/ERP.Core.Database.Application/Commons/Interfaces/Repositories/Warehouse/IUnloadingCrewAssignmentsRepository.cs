using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IUnloadingCrewAssignmentsRepository : IRepository<UnloadingCrewAssignments>
{
    Task<UnloadingCrewAssignments> InsertUnloadingCrewAssignments(UnloadingCrewAssignments crewAssignment);
}