using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;

public class RackCapacityRepository(ErpDbContext _context): Repository<RackCapacity>(_context), IRackCapacityRepository
{
    public async Task<RackCapacity> RegisterRackCapacity(RackCapacity payload)
    {
        var record = await _context.RackCapacities.AddAsync(payload);
        return record.Entity;
    }
}
