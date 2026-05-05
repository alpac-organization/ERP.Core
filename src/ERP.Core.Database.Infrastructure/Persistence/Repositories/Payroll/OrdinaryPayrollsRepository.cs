using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class OrdinaryPayrollsRepository(ErpDbContext _context): Repository<OrdinaryPayroll>(_context), IOrdinaryPayrollsRepository
    {
        public async Task<OrdinaryPayroll> RegisterCollaboratorInTheOrdinaryPayroll(OrdinaryPayroll payload)
        {
            var collaboratorRegistered = await _context.OrdinaryPayrolls.AddAsync(payload);
            return collaboratorRegistered.Entity;
        }
    }
}   