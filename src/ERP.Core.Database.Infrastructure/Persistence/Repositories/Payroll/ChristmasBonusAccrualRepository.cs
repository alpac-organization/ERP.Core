using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class ChristmasBonusAccrualRepository(ErpDbContext _context): Repository<ChristmasBonusAccrual>(_context), IChristmasBonusAccrualRepository
    {
        public async Task<ChristmasBonusAccrual> RegisterChristmasBonusAccrual(ChristmasBonusAccrual payload)
        {
            var history = await _context.ChristmasBonusAccruals.AddAsync(payload);
            return history.Entity;
        }
    }
}   