using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface ICustomsBranchesRepository: IRepository<CustomsBranches>
    {
        Task<CustomsBranches> RegisterCustomBranch(CustomsBranches payload);
    }
}