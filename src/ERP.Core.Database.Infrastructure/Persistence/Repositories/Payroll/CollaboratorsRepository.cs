using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class CollaboratorsRepository(ErpDbContext _context): Repository<Collaborator>(_context), ICollaboratorsRepository
    {
        public async Task<Collaborator> RegisterCollaborator(Collaborator collaborator)
        {
            collaborator.Status = CollaboratorStatus.Active;
            collaborator.PictureUrl = null;

            var collaboratorRegistered = await _context.Collaborators.AddAsync(collaborator);
            return collaboratorRegistered.Entity;
        }
    }
}