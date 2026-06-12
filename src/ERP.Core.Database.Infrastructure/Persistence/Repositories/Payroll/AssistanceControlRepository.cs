using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class AssistanceControlRepository(ErpDbContext _context): Repository<AssistanceControl>(_context), IAssistanceControlRepository
    {
        public async Task<AssistanceControl> RegisterAssistanceControl(AssistanceControl assigned)
        {
            var record = await _context.AssistanceControls.AddAsync(assigned);
            return record.Entity;
        }
    }
}   