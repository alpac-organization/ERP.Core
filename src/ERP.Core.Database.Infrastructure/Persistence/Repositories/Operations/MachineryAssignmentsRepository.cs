using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations;

public class AssignmentMachineryRepository(ErpDbContext _context) : Repository<AssignmentsMachinery>(_context), IAssignmentsMachineryRepository
{
    public async Task<AssignmentsMachinery> AssignMachinery(AssignmentsMachinery payload)
    {
        await _context.Set<AssignmentsMachinery>().AddAsync(payload);
        return payload;
    }
}
