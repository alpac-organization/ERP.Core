using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class ReassignmentSessionsRepository(ErpDbContext context)
    : Repository<ReassignmentSessions>(context), IReassignmentSessionsRepository
{
    public async Task<ReassignmentSessions> InsertReassignmentSession(ReassignmentSessions reassignmentSession)
    {
        var record = await _context.ReassignmentSessions.AddAsync(reassignmentSession);
        return record.Entity;
    }
}