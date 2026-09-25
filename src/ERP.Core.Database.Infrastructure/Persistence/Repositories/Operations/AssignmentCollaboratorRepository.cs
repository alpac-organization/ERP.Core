using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations;

public class AssignmentCollaboratorRepository(ErpDbContext _context) : Repository<AssignmentCollaborators>(_context), IAssignmentCollaboratorsRepository
{
    public async Task<AssignmentCollaborators> AssignCollaborator(AssignmentCollaborators payload)
    {
        await _context.Set<AssignmentCollaborators>().AddAsync(payload);
        return payload;
    }
}
