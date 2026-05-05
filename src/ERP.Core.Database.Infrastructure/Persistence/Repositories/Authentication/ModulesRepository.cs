using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;


namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication
{
    public class ModulesRepository(ErpDbContext _context): Repository<Module>(_context), IModulesRepository
    {
        public async Task<List<Module>> ObtainActiveModulesByCompanyId(Guid CompanyId, CancellationToken cancellationToken)
        {
            return await _context.Modules
                .Where(module => module.IsActive)
                .OrderBy(module => module.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task CreateModuleAssociatedWithCompany(Module Payload, CancellationToken cancellationToken)
        {
            await _context.Modules.AddAsync(Payload, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}