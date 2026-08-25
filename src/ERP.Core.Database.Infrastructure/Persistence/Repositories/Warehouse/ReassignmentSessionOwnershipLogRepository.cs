using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class ReassignmentSessionOwnershipLogRepository(ErpDbContext context)
    : Repository<ReassignmentSessionOwnershipLog>(context), IReassignmentSessionOwnershipLogRepository
{
    public async Task<ReassignmentSessionOwnershipLog> InsertReassignmentSessionOwnershipLog(ReassignmentSessionOwnershipLog ownershipLog)
    {
        var record = await _context.ReassignmentSessionOwnershipLogs.AddAsync(ownershipLog);
        return record.Entity;
    }
}