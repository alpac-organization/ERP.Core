using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class ServicesOrdersRequisitionsRepository(ErpDbContext context) : Repository<ServiceOrderRequistions>(context), IServicesOrdersRequisitionsRepository 
    {
        public async Task<ServiceOrderRequistions> RegisterServicesOrderRequisitions(ServiceOrderRequistions payload)
        {
            await _context.ServiceOrderRequistions.AddAsync(payload);
            return payload;
        }
    }
}   