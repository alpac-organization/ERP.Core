using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWarehouseAssignmentsRepository : IRepository<WarehouseAssignments>
{
    Task<WarehouseAssignments> InsertWarehouseAssignment(WarehouseAssignments assignment);
}