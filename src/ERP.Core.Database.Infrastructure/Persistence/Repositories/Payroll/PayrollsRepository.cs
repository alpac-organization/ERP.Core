using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class PayrollsRepository(ErpDbContext _context): Repository<Domain.Entities.Payrolls.Payroll>(_context), IPayrollsRepository
    {
        public async  Task<Domain.Entities.Payrolls.Payroll> InitializePayroll(Domain.Entities.Payrolls.Payroll payroll)
        {
            var collaboratorRegistered = await _context.Payrolls.AddAsync(payroll);
            return collaboratorRegistered.Entity;
        }
    }
}   