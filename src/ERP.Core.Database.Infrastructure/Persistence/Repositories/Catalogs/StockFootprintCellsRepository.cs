using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;

public class StockFootprintCellsRepository(ErpDbContext context)
    : Repository<StockFootprintCells>(context), IStockFootprintCellsRepository
{
    public async Task<StockFootprintCells> InsertStockFootprintCell(StockFootprintCells stockFootprintCell)
    {
        var record = await _context.StockFootprintCells.AddAsync(stockFootprintCell);
        return record.Entity;
    }
}