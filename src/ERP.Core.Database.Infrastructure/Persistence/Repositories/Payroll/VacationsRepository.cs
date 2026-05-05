using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class VacationsRepository(AppDbContext _context): Repository<Vacation>(_context), IVacationsRepository
    {
        public async Task<Vacation> RegisterVacationControl(Vacation payload)
        {
            var vacationRegistered = await _context.Vacations.AddAsync(payload);
            return vacationRegistered.Entity;
        }
    }
}