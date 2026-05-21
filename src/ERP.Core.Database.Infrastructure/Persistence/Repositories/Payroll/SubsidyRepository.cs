using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class SubsidyRepository(ErpDbContext _context): Repository<Subsidy>(_context), ISubsidyRepository
    {
        public async Task<Subsidy> CreateSubsidy(Subsidy payload)
        {
            var registeredSubsidy = await _context.Subsidies.AddAsync(payload);
            return registeredSubsidy.Entity;
        }
    }
}