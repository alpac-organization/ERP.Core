using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class PendingDeductionBalancesRepository(ErpDbContext context)
        : Repository<PendingDeductionBalance>(context), IPendingDeductionBalancesRepository
    {

        public async Task<PendingDeductionBalance> RegisterPendingDeductionBalance(PendingDeductionBalance balance)
        {
            var registerPendingBalance = await _context.PendingDeductionBalances.AddAsync(balance);
            return registerPendingBalance.Entity;
        }

        public async Task<List<PendingDeductionBalance>> GetUnrecoveredBalancesByCollaboratorAsync(Guid collaboratorId)
        {
            return await _context.PendingDeductionBalances
                .Include(x => x.OriginPayroll)
                .Where(x => x.CollaboratorId == collaboratorId && !x.IsRecovered).ToListAsync();
        }

        public async Task<List<PendingDeductionBalance>> GetBalancesByOriginPayrollAsync(Guid originPayrollId)
        {
            return await _context.PendingDeductionBalances
                .Include(x => x.Collaborator)
                .Where(x => x.OriginPayrollId == originPayrollId)
                .ToListAsync();
        }
        public async Task<List<PendingDeductionBalance>> GetBalancesByRecoveredPayrollAsync(Guid payrollId)
        {
            return await _context.PendingDeductionBalances
                .Include(x => x.Collaborator)
                .Include(x => x.OriginPayroll)
                .Where(x => x.RecoveredPayrollId == payrollId)
                .ToListAsync();
        }
    }
}