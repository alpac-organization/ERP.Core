using ERP.Core.Database.Domain.Entities.Auth;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication
{
    public interface IUserModulesRoleRepository : IRepository<UserModuleRoles>
    {
        Task<UserModuleRoles> AssignRolesModule(UserModuleRoles entity);
    }
}