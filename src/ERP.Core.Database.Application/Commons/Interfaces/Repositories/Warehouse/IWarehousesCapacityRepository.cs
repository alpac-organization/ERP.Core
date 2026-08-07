using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWarehouseCapacityRepository : IRepository<WarehouseCapacity>
{
    Task<WarehouseCapacity> RegisterWarehouseCapacity(WarehouseCapacity payload);
}