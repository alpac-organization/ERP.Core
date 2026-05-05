using ERP.Core.Database.Domain.Entities.Auth;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication
{
    public interface IRolesRepository : IRepository<Role>
    {
        Task<Role?> ObtainModuleRoleByUserIdAndModuleId(string moduleCode, Guid userId, CancellationToken cancellationToken);
    }
}