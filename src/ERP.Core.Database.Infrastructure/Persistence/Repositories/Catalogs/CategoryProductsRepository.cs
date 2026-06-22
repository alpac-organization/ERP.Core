using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;

// Heredamos de tu repositorio base pasándole el ErpDbContext
public class CategoryProductsRepository(ErpDbContext context) 
    : Repository<CategoryProducts>(context), ICategoryProductsRepository
{
    public async Task<List<CategoryProducts>> GetRootCategoriesWithChildrenAsync(CancellationToken cancellationToken)
    {
        return await Entities
            .Where(c => c.ParentId == null && c.IsActive) 
            .Include(c => c.Children.Where(child => child.IsActive)) 
            .ToListAsync(cancellationToken);
    }
}