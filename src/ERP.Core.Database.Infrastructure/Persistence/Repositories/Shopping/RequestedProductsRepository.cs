using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class RequestedProductsRepository(ErpDbContext _context) : Repository<RequestedProduct>(_context), IRequestedProductsRepository
    {
        public async Task<RequestedProduct> RegisterRequestedProduct(RequestedProduct payload)
        {
            var record = await _context.RequestedProducts.AddAsync(payload);
            return record.Entity;
        }
    }
    
}