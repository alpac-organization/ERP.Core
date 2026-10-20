using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class ReasonsInventoryRemovalRepository(ErpDbContext context) : Repository<ReasonsInventoryRemoval>(context), IReasonsInventoryRemovalRepository
    {
        public async Task<ReasonsInventoryRemoval> RegisterNewReasonInventoryRemoval(ReasonsInventoryRemoval payload)
        {
            var record = await _context.ReasonsInventoryRemoval.AddAsync(payload);
            return record.Entity;
        }
    }
}