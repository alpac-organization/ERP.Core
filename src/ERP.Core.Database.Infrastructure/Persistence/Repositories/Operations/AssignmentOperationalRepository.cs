using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;
using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
{
    public class AssignmentOperationalRepository(ErpDbContext context) : Repository<AssignmentOperational>(context), IAssignmentOperationalRepository
    {
        public async Task<AssignmentOperational> RegisterAssignmentOperational(AssignmentOperational payload)
        {
            await _context.AssignmentOperationals.AddAsync(payload);
            return payload;
        }
    }
}