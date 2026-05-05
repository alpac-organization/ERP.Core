using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class IncomesRepository(AppDbContext _context): Repository<Income>(_context), IIncomesRepository
    {
        public async  Task<Income> RegisterIncome(Income income)
        {
            var IncomeRegistered = await _context.Incomes.AddAsync(income);
            return IncomeRegistered.Entity;
        }
    }
}   