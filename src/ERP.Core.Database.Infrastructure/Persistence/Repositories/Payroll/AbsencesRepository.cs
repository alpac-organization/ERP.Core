using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class AbsencesRepository(ErpDbContext _context)
        : Repository<Absence>(_context), IAbsencesRepository
    {
        public async Task<Absence> RegisterAbsence(Absence absence)
        {
            var registered = await _context.Absences.AddAsync(absence);
            return registered.Entity;
        }
    }
}
