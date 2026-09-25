using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

public interface IAssignmentCollaboratorsRepository : IRepository<AssignmentCollaborators>
{
    Task<AssignmentCollaborators> AssignCollaborator(AssignmentCollaborators payload);
}
