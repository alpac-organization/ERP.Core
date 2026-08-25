using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IReassignmentSessionOwnershipLogRepository : IRepository<ReassignmentSessionOwnershipLog>
{
    Task<ReassignmentSessionOwnershipLog> InsertReassignmentSessionOwnershipLog(ReassignmentSessionOwnershipLog ownershipLog);
}