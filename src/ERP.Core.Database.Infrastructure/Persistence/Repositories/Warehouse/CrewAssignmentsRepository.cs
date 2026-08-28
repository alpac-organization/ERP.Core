using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class CrewAssignmentsRepository(ErpDbContext _context) : Repository<CrewAssignments>(_context), ICrewAssignmentsRepository
{
    public async Task<CrewAssignments> InsertCrewAssignment(CrewAssignments payload)
    {
        await _context.Set<CrewAssignments>().AddAsync(payload);
        return payload;
    }
}
