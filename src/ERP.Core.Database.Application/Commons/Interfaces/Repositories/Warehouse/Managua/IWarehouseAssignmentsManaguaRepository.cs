using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IWarehouseAssignmentsManaguaRepository : IRepository<WarehouseAssignmentsManagua>
{
    Task<WarehouseAssignmentsManagua> GetWarehouseAssignmentsManagua(WarehouseAssignmentsManagua warehouseAssignment);
}