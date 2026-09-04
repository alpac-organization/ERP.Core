using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWarehouseTaskEventsRepository : IRepository<WarehouseTaskEvent>
{
    Task<WarehouseTaskEvent> InsertWarehouseTaskEvent(WarehouseTaskEvent taskEvent);
}
