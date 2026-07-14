using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class EntranceDucatsRepository(ErpDbContext context)
    : Repository<EntranceDucats>(context), IEntranceDucatsRepository
{
    public async Task<EntranceDucats> InsertEntranceDucat(EntranceDucats entranceDucats)
    {
        var record = await _context.EntranceDucats.AddAsync(entranceDucats);
        return record.Entity;
    }

    public async Task InsertEntranceDucatsRange(IEnumerable<EntranceDucats> entranceDucats)
    {
        await _context.EntranceDucats.AddRangeAsync(entranceDucats);
    }
}