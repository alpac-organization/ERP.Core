using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class ProductStockRepository(ErpDbContext _context) : Repository<ProductStock>(_context), IProductStockRepository
    {
        public async  Task<ProductStock> RegisterProductStock(ProductStock payload)
        {
            var record = await _context.ProductStocks.AddAsync(payload);
            return record.Entity;
        }
    }
}