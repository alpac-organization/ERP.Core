using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface ICustomerBranchesRepository : IRepository<CustomerBranch>
    {
        Task<CustomerBranch> RegisterCustomerBranch(CustomerBranch payload);
    }
}