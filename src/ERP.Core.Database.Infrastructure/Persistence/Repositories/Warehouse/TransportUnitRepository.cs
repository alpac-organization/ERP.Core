using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class TransportUnitRepository(ErpDbContext context)
    : Repository<TransportUnit>(context), ITransportUnitRepository
{
    public async Task<TransportUnit> RegisterTransportUnit(TransportUnit payload)
    {
        var record = await _context.TransportUnits.AddAsync(payload);
        return record.Entity;
    }
}
