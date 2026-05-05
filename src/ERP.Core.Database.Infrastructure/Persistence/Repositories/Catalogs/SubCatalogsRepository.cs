using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class SubCatalogsRepository(ErpDbContext _context) : Repository<SubCatalog>(_context), ISubCatalogsRepository
    {
        public async Task<List<SubCatalog>> GetSubCatalogsByCatalogId(int CatalogId, CancellationToken cancellationToken)
        {
            return await _context.SubCatalogs
                .Where(sc => sc.CatalogId == CatalogId && sc.IsActive)
                .OrderBy(src => src.CatalogName)
                .ToListAsync(cancellationToken);
        }
    }
}