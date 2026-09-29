using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations;

public class AssignmentEnclosureRepository(ErpDbContext _context) : Repository<AssignmentEnclosure>(_context), IAssignmentEnclosureRepository
{
    public async Task<AssignmentEnclosure> AssignEnclosure(AssignmentEnclosure payload)
    {
        await _context.Set<AssignmentEnclosure>().AddAsync(payload);
        return payload;
    }
}
