using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IStockMovementEventsRepository : IRepository<StockMovementEvents>
{
    Task<StockMovementEvents> InsertStockMovementEvent(StockMovementEvents stockMovementEvent);
}