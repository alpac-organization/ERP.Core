using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class CapacityRepository(ErpDbContext context): Repository<Capacity>(context), ICapacityRepository
{
    public async Task<Capacity> RegisterCapacity(Capacity payload)
    {
        var record = await _context.Capacities.AddAsync(payload);
        return record.Entity;
    }
}