using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class ChristmasBonusPeriodRepository(ErpDbContext _context)
        : Repository<ChristmasBonusPeriod>(_context), IChristmasBonusPeriodRepository
    {
        public async Task<ChristmasBonusPeriod> RegisterChristmasBonusPeriod(ChristmasBonusPeriod period)
        {
            var entry = await _context.ChristmasBonusPeriods.AddAsync(period);
            return entry.Entity;
        }

        public async Task<ChristmasBonusPeriod?> GetChristmasBonusPeriodByCompanyAndDate(
            Guid companyId,
            DateOnly date)
        {
            return await _context.ChristmasBonusPeriods
                .Where(p => p.CompanyId == companyId
                    && p.DeletedAt == null
                    && p.StartDate <= date
                    && p.EndDate >= date)
                .FirstOrDefaultAsync();
        }

        public async Task<ChristmasBonusPeriod?> GetChristmasBonusPeriodByCompanyAndEndYear(
            Guid companyId,
            int endYear)
        {
            return await _context.ChristmasBonusPeriods
                .Where(p => p.CompanyId == companyId
                    && p.EndYear == endYear
                    && p.DeletedAt == null)
                .FirstOrDefaultAsync();
        }
    }
}
