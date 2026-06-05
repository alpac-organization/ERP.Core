using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class BranchesRepository(ErpDbContext _context) : Repository<Branch>(_context), IBranchesRepository
    {
        public async Task<Branch> RegisterBranch(Branch payload)
        {
            var record = await _context.Branches.AddAsync(payload);
            return record.Entity;
        }
    }
}