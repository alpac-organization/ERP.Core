using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
{
    public class SuppliesRepository(ErpDbContext context) : Repository<Supplies>(context), ISuppliesRepository
    {
        public async Task<Supplies> RegisterSupply(Supplies payload)
        {
            await _context.Supplies.AddAsync(payload);
            return payload;
        }
    }
}