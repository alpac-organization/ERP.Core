using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IMachineryAssignmentsRepository : IRepository<MachineryAssignments>
{
    Task<MachineryAssignments> InsertMachineryAssignment(MachineryAssignments payload);
}
