using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class HolidaysRepository(ErpDbContext _context): Repository<Holidays>(_context), IHolidaysRepository
    {
        public async  Task<Holidays> RegisterHoliday(Holidays income)
        {
            var register = await _context.Holidays.AddAsync(income);
            return register.Entity;
        }
    }
}   