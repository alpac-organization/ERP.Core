using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
{
    public class ServicesOrdersRepository(ErpDbContext context) : Repository<ServicesOrder>(context), IServicesOrdersRepository
    {
        public async Task<ServicesOrder> RegisterServicesOrder(ServicesOrder payload)
        {
            await _context.ServicesOrders.AddAsync(payload);
            return payload;
        }
    }
}