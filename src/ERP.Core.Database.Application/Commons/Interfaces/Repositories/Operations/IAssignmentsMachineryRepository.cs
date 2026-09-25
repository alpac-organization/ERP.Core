using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

public interface IAssignmentsMachineryRepository : IRepository<AssignmentsMachinery>
{
    Task<AssignmentsMachinery> AssignMachinery(AssignmentsMachinery payload);
}
