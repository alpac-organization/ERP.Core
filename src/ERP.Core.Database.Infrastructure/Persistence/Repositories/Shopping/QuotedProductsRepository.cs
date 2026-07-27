using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class QuotedProductsRepository(ErpDbContext _context) : Repository<QuotedProduct>(_context), IQuotedProductsRepository
    {
        public async Task<QuotedProduct> RegisterQuotedProduct(QuotedProduct payload)
        {
            var record = await _context.QuotedProducts.AddAsync(payload);
            return record.Entity;
        }
    }
    
}