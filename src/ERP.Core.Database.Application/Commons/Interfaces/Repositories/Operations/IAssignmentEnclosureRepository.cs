using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

public interface IAssignmentEnclosureRepository : IRepository<AssignmentEnclosure>
{
    Task<AssignmentEnclosure> AssignEnclosure(AssignmentEnclosure payload);
}