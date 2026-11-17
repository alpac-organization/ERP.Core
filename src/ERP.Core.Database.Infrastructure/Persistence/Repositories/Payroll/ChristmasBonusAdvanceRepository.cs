using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class ChristmasBonusAdvanceRepository(ErpDbContext _context)
        : Repository<ChristmasBonusAdvance>(_context), IChristmasBonusAdvanceRepository
    {
        public async Task<ChristmasBonusAdvance> RegisterChristmasBonusAdvance(ChristmasBonusAdvance bonusAdvance)
        {
            var entry = await _context.ChristmasBonusAdvances.AddAsync(bonusAdvance);
            return entry.Entity;
        }

        public async Task<List<ChristmasBonusAdvance>> GetPaidAdvances(
            Guid collaboratorId,
            Guid christmasBonusPeriodId)
        {
            return await _context.ChristmasBonusAdvances
                .Where(a => a.CollaboratorId == collaboratorId
                    && a.ChristmasBonusPeriodId == christmasBonusPeriodId
                    && a.Status == ChristmasBonusAdvanceStatus.Paid
                    && a.DeletedAt == null)
                .OrderBy(a => a.PaidAt)
                .ToListAsync();
        }
    }
}
