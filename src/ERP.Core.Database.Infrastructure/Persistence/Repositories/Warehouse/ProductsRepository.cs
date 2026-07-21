using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class ProductsRepository(ErpDbContext context): Repository<Product>(context), IProductsRepository
{
    public async Task<Product> InsertProduct(Product payload)
    {
        var record = await _context.Products.AddAsync(payload);
        return record.Entity;
    }
}