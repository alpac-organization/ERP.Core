using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication
{
    public class UserModulesRoleRepository(ErpDbContext _context): Repository<UserModuleRoles>(_context), IUserModulesRoleRepository
    {
        public async Task<UserModuleRoles> AssignRolesModule(UserModuleRoles entity)
        {
            var assigSaved = await _context.UserModuleRoles.AddAsync(entity);
            return assigSaved.Entity;
        }
    }
}