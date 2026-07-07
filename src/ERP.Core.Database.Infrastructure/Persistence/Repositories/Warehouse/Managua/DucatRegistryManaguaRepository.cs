using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class DucatRegistryManaguaRepository(ErpDbContext context)
    : Repository<DucatRegistryManagua>(context), IDucatRegistryManaguaRepository
{
    public async Task<DucatRegistryManagua> RegisterDucatRegistryManagua(DucatRegistryManagua payload)
    {
        var record = await _context.DucatRegistryManagua.AddAsync(payload);
        return record.Entity;
    }
}