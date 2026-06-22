using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class ProductsRepository(ErpDbContext context) 
    : Repository<Product>(context), IProductsRepository
{
    public async Task<List<Product>> GetRootProductsWithDetailsAsync(CancellationToken ct)
    {
        return await Entities
            .Where(p => p.ParentId == null && p.IsActive)
            .Include(p => p.Customer) 
            .Include(p => p.CategoryProducts) 
            .Include(p => p.Children.Where(c => c.IsActive))
            .ToListAsync(ct);
    }
}