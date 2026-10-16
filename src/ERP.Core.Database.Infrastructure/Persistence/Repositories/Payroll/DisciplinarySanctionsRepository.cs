using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class DisciplinarySanctionsRepository(ErpDbContext _context)
        : Repository<DisciplinarySanction>(_context), IDisciplinarySanctionsRepository
    {
        public async Task<DisciplinarySanction> RegisterDisciplinarySanction(DisciplinarySanction disciplinarySanction)
        {
            var registered = await _context.DisciplinarySanctions.AddAsync(disciplinarySanction);
            return registered.Entity;
        }
    }
}
