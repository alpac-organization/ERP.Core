using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;

public class LotsCapacityRepository(ErpDbContext _context): Repository<LotsCapacity>(_context), ILotsCapacityRepository
{
    public async Task<LotsCapacity> RegisterLotsCapacity(LotsCapacity payload)
    {
        var record = await _context.LotsCapacities.AddAsync(payload);
        return record.Entity;
    }
}
