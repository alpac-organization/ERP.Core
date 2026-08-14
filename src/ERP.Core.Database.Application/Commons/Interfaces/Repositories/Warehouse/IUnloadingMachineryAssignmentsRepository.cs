using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IUnloadingMachineryAssignmentsRepository : IRepository<UnloadingMachineryAssignments>
{
    Task<UnloadingMachineryAssignments> InsertUnloadingMachineryAssignments(UnloadingMachineryAssignments machineryAssignment);
}