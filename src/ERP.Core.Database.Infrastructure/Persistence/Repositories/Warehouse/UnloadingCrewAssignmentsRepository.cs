using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse
{
    public class UnloadingCrewAssignmentsRepository(ErpDbContext _context) : Repository<UnloadingCrewAssignments>(_context), IUnloadingCrewAssignmentsRepository
    {
        public async Task<UnloadingCrewAssignments> InsertUnloadingCrewAssignments(UnloadingCrewAssignments crewAssignment)
        {
            var record = await _context.UnloadingCrewAssignments.AddAsync(crewAssignment);
            return record.Entity;
        }
    }
}