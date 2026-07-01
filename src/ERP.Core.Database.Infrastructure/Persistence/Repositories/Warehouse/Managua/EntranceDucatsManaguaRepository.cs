using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class EntranceDucatsManaguaRepository(ErpDbContext context)
    : Repository<EntranceDucatsManagua>(context), IEntranceDucatsManaguaRepository
{
    public async Task<EntranceDucatsManagua> InsertEntranceDucat(EntranceDucatsManagua entranceDucats)
    {
        var record = await _context.EntranceDucatsManagua.AddAsync(entranceDucats);
        return record.Entity;
    }

    public async Task InsertEntranceDucatsRange(IEnumerable<EntranceDucatsManagua> entranceDucats)
    {
        await _context.EntranceDucatsManagua.AddRangeAsync(entranceDucats);
    }
}