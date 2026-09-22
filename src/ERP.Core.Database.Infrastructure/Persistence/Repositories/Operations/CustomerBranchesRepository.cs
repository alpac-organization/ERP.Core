using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
{
    public class CustomerBranchesRepository(ErpDbContext context) : Repository<CustomerBranch>(context), ICustomerBranchesRepository
    {
        public async Task<CustomerBranch> RegisterCustomerBranch(CustomerBranch payload)
        {
            await _context.CustomerBranches.AddAsync(payload);
            return payload;
        }
    }
}