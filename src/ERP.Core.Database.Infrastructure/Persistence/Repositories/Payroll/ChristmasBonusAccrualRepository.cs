using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class ChristmasBonusAccrualRepository(ErpDbContext _context)
        : Repository<ChristmasBonusAccrual>(_context),
          IChristmasBonusAccrualRepository
    {
        public async Task<ChristmasBonusAccrual> RegisterChristmasBonusAccrual(
            ChristmasBonusAccrual accrual)
        {
            var entry = await _context.ChristmasBonusAccruals
                .AddAsync(accrual);

            return entry.Entity;
        }

        public async Task<ChristmasBonusAccrual?>
            GetChristmasBonusAccrualMonthly(Guid collaboratorId,Guid christmasBonusPeriodId,int year,int month)
        {
            return await _context.ChristmasBonusAccruals
                .AsNoTracking()
                .SingleOrDefaultAsync(a =>
                    a.CollaboratorId == collaboratorId &&
                    a.ChristmasBonusPeriodId == christmasBonusPeriodId &&
                    a.AccrualYear == year &&
                    a.AccrualMonth == month &&
                    a.DeletedAt == null);
        }

        public async Task<List<ChristmasBonusAccrual>>GetChristmasBonusAccrualsByPeriod(Guid collaboratorId,Guid christmasBonusPeriodId)
        {
            return await _context.ChristmasBonusAccruals
                .AsNoTracking()
                .Where(a =>
                    a.CollaboratorId == collaboratorId &&
                    a.ChristmasBonusPeriodId == christmasBonusPeriodId &&
                    a.DeletedAt == null)
                .OrderBy(a => a.AccrualYear)
                .ThenBy(a => a.AccrualMonth)
                .ToListAsync();
        }
    }
}