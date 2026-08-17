using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class CustomsBranchesRepository(ErpDbContext _context) : Repository<CustomsBranches>(_context), ICustomsBranchesRepository
    {
        public async Task<CustomsBranches> RegisterCustomBranch(CustomsBranches payload)
        {
            var record = await _context.CustomsBranches.AddAsync(payload);
            return record.Entity;
        }
    }
}