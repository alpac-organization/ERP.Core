using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
{
    public class OperationalOrdersRepository(ErpDbContext context) : Repository<OperationalOrder>(context), IOperationalOrdersRepository
    {
        public async Task<OperationalOrder> RegisterOperationalOrder(OperationalOrder payload)
        {
            await _context.OperationalOrders.AddAsync(payload);
            return payload;
        }
    }
}