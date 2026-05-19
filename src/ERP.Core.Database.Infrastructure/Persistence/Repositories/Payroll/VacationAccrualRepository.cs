using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class VacationAccrualRepository(ErpDbContext _context): Repository<VacationAccrual>(_context), IVacationAccrualRepository
    {
        public async Task<VacationAccrual> RegisterVacationAccrual(VacationAccrual payload)
        {
            var record = await _context.VacationAccruals.AddAsync(payload);
            return record.Entity;
        }
    }
}   