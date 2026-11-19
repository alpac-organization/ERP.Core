using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class ChristmasBonusSettlementRepository(ErpDbContext _context)
        : Repository<ChristmasBonusSettlement>(_context), IChristmasBonusSettlementRepository
    {
        public async Task<ChristmasBonusSettlement> RegisterChristmasBonusSettlement(
            ChristmasBonusSettlement settlement)
        {
            var entry = await _context.ChristmasBonusSettlements.AddAsync(settlement);
            return entry.Entity;
        }

        public async Task<ChristmasBonusSettlement?> GetChristmasBonusSettlementByCollaboratorAndPeriod(
            Guid collaboratorId,
            Guid christmasBonusPeriodId)
        {
            return await _context.ChristmasBonusSettlements
                .Where(s => s.CollaboratorId == collaboratorId
                    && s.ChristmasBonusPeriodId == christmasBonusPeriodId
                    && s.DeletedAt == null)
                .FirstOrDefaultAsync();
        }
    }
}
