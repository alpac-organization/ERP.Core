using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class DisciplinaryFaultsRepository(ErpDbContext _context)
        : Repository<DisciplinaryFault>(_context), IDisciplinaryFaultsRepository
    {
        public async Task<DisciplinaryFault> RegisterDisciplinaryFault(DisciplinaryFault disciplinaryFault)
        {
            var registered = await _context.DisciplinaryFaults.AddAsync(disciplinaryFault);
            return registered.Entity;
        }
    }
}
