using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWarehouseTasksRepository : IRepository<WarehouseTask>
{
    Task<WarehouseTask> InsertWarehouseTask(WarehouseTask task);
}
