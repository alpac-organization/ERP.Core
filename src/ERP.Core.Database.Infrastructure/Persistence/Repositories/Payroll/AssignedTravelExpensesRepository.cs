using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class AssignedTravelExpensesRepository(ErpDbContext _context): Repository<AssignedTravelExpenses>(_context), IAssignedTravelExpensesRepository
    {
        public async Task<AssignedTravelExpenses> RegisterAssignedTravelExpenses(AssignedTravelExpenses assigned)
        {
            var history = await _context.AssignedTravelExpenses.AddAsync(assigned);
            return history.Entity;
        }
    }
}   