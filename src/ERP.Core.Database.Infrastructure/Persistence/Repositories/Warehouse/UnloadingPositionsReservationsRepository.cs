using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class UnloadingPositionReservationsRepository(ErpDbContext context)
    : Repository<UnloadingPositionReservations>(context), IUnloadingPositionsReservationsRepository
{
    public async Task<UnloadingPositionReservations> InsertPositionReservation(UnloadingPositionReservations payload)
    {
        var record = await _context.UnloadingPositionReservations.AddAsync(payload);
        return record.Entity;
    }
}