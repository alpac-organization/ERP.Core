using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class AssignedTravelExpensesHistoryRepository(ErpDbContext _context): Repository<AssignedTravelExpensesHistory>(_context), IAssignedTravelExpensesHistoryRepository
    {
        public async Task<AssignedTravelExpensesHistory> RegisterAssignedTravelExpensesHistory(AssignedTravelExpensesHistory assigned)
        {
            var history = await _context.AssignedTravelExpensesHistories.AddAsync(assigned);
            return history.Entity;
        }
    }
}   