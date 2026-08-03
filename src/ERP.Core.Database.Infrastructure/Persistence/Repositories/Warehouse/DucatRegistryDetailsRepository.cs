using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class DucatRegistryDetailsRepository(ErpDbContext context)
    : Repository<DucatRegistryDetails>(context), IDucatRegistryDetailsRepository
{
    public async Task<DucatRegistryDetails> RegisterDucatRegistryDetails(DucatRegistryDetails payload)
    {
        var record = await _context.DucatRegistryDetails.AddAsync(payload);
        return record.Entity;
    }
}
