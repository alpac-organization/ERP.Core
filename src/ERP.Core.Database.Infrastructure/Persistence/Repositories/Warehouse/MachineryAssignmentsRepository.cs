using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class MachineryAssignmentsRepository(ErpDbContext _context) : Repository<MachineryAssignments>(_context), IMachineryAssignmentsRepository
{
    public async Task<MachineryAssignments> InsertMachineryAssignment(MachineryAssignments payload)
    {
        await _context.Set<MachineryAssignments>().AddAsync(payload);
        return payload;
    }
}
