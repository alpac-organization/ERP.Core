using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWarehouseTaskOwnershipLogsRepository : IRepository<WarehouseTaskOwnershipLog>
{
    Task<WarehouseTaskOwnershipLog> InsertWarehouseTaskOwnershipLog(WarehouseTaskOwnershipLog ownershipLog);
}
