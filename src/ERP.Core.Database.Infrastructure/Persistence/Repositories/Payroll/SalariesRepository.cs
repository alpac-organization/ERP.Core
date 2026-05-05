using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class SalariesRepository(AppDbContext _context): Repository<Salary>(_context), ISalariesRepository
    {
        public async Task<Salary> RegisterSalary(Salary payload)
        {
            var informationRegistered = await _context.Salaries.AddAsync(payload);
            return informationRegistered.Entity;
        }
    }
}