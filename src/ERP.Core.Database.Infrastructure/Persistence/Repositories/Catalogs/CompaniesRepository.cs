using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class CompaniesRepository(ErpDbContext _context): Repository<Company>(_context), ICompaniesRepository
    {
        public async Task<List<Company>> GetAvailableCompanies(CancellationToken cancellationToken)
        {
            return await _context.Companies
                .Where(company => company.IsActive == true)
                .ToListAsync(cancellationToken);
        }
    }
}