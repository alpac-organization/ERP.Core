using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface IBranchesRepository: IRepository<Branch>
    {
        Task<Branch> RegisterBranch(Branch payload);
    }
}