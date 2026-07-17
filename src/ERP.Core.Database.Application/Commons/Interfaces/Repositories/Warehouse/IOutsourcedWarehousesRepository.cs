using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IOutsourcedWarehousesRepository : IRepository<OutsourcedWarehouse>
{
    Task<OutsourcedWarehouse> RegisterOutsourcedWarehouse(OutsourcedWarehouse payload);
}