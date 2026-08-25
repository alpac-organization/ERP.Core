using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IStockPlacementsRepository : IRepository<StockPlacements>
{
    Task<StockPlacements> InsertStockPlacement(StockPlacements stockPlacement);
}