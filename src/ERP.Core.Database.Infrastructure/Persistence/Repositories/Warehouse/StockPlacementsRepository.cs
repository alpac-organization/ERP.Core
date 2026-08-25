using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class StockPlacementsRepository(ErpDbContext context)
    : Repository<StockPlacements>(context), IStockPlacementsRepository
{
    public async Task<StockPlacements> InsertStockPlacement(StockPlacements stockPlacement)
    {
        var record = await _context.StockPlacements.AddAsync(stockPlacement);
        return record.Entity;
    }
}