using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class StockMovementEventsRepository(ErpDbContext context)
    : Repository<StockMovementEvents>(context), IStockMovementEventsRepository
{
    public async Task<StockMovementEvents> InsertStockMovementEvent(StockMovementEvents stockMovementEvent)
    {
        var record = await _context.StockMovementEvents.AddAsync(stockMovementEvent);
        return record.Entity;
    }
}