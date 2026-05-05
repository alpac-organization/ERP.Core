using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class WorkPositionsHistoryRepository(ErpDbContext _context): Repository<WorkPositionHistory>(_context), IWorkPositionsHistoryRepository
    {
        public async Task<WorkPositionHistory> RegisterHistory(WorkPositionHistory history)
        {
            var informationRegistered = await _context.WorkPositionHistories.AddAsync(history);
            return informationRegistered.Entity;
        }
    }
}