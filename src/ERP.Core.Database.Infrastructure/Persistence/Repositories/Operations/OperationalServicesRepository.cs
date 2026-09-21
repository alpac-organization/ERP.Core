using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
{
    public class OperationalServicesRepository(ErpDbContext context) : Repository<OperationalService>(context), IOperationalServicesRepository
    {
        public async Task<OperationalService> RegisterOperationalService(OperationalService payload)
        {
            await _context.OperationalServices.AddAsync(payload);
            return payload;
        }
    }
}