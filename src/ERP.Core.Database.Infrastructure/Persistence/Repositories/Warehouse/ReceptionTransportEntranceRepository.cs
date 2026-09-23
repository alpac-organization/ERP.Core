using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class ReceptionTransportEntranceRepository(ErpDbContext context)
    : Repository<ReceptionTransportEntrance>(context), IReceptionTransportEntranceRepository
{
    public async Task<ReceptionTransportEntrance> RegisterTransport(ReceptionTransportEntrance receptionTransportEntrance)
    {
        var record = await _context.ReceptionTransportEntrances.AddAsync(receptionTransportEntrance);
        return record.Entity;
    }
}