using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWarehousesRepository : IRepository<Warehouses>
{
    Task<Warehouses> RegisterWarehouse(Warehouses payload);
}