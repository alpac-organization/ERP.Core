using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class FuelRequestRepository(ErpDbContext context) : Repository<FuelRequest>(context), IFuelRequestRepository
    {
        public async Task<FuelRequest> RegisterFuelRequest(FuelRequest payload)
        {
            var record = await _context.FuelRequests.AddAsync(payload);
            return record.Entity;
        }
    }
}