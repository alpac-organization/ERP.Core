using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class DucatRegistryDetailsManaguaRepository(ErpDbContext _context) : Repository<DucatRegistryDetailsManagua>(_context), IDucatRegistryDetailsManaguaRepository
{
    public async Task<DucatRegistryDetailsManagua> RegisterDucatRegistryDetailsManagua(DucatRegistryDetailsManagua payload)
    {
        var record = await _context.DucatRegistryDetailsManagua.AddAsync(payload);
        return record.Entity;
    }
}