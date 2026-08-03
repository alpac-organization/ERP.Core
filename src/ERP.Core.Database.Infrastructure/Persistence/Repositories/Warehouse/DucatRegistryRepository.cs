using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class DucatRegistryRepository(ErpDbContext context)
    : Repository<DucatRegistry>(context), IDucatRegistryRepository
{
    public async Task<DucatRegistry> RegisterDucatRegistry(DucatRegistry payload)
    {
        var record = await _context.DucatRegistries.AddAsync(payload);
        return record.Entity;
    }
}
