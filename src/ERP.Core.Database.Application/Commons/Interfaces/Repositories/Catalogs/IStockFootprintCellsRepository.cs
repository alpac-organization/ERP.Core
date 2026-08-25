using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface IStockFootprintCellsRepository : IRepository<StockFootprintCells>
{
    Task<StockFootprintCells> InsertStockFootprintCell(StockFootprintCells stockFootprintCell);
}