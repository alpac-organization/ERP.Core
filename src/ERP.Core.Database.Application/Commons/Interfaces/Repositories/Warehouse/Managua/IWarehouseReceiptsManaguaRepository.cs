using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IWarehouseReceiptsManaguaRepository : IRepository<WarehouseReceiptsManagua>
{
    Task<WarehouseReceiptsManagua> GenerateWarehouseReceiptsManagua(WarehouseReceiptsManagua warehouseReceipts);
}