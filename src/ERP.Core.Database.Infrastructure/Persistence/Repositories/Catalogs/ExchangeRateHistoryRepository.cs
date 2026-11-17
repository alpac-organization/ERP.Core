using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class ExchangeRateHistoryRepository(ErpDbContext _context)
        : Repository<ExchangeRateHistory>(_context),
          IExchangeRateHistoryRepository
    {
        public async Task<ExchangeRateHistory> RegisterExchangeRateHistory(
            ExchangeRateHistory exchangeRateHistory)
        {
            var entry = await _context.ExchangeRateHistories
                .AddAsync(exchangeRateHistory);

            return entry.Entity;
        }

        public async Task<ExchangeRateHistory?> GetExchangeRateByDate(
            Currency currency,
            DateOnly date)
        {
            return await _context.ExchangeRateHistories
                .AsNoTracking()
                .Where(e =>
                    e.Currency == currency &&
                    e.EffectiveFrom <= date &&
                    (e.EffectiveTo == null || e.EffectiveTo >= date) &&
                    e.DeletedAt == null)
                .OrderByDescending(e => e.EffectiveFrom)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ExchangeRateHistory>> GetExchangeRateHistoryByCurrency(
            Currency currency)
        {
            return await _context.ExchangeRateHistories
                .AsNoTracking()
                .Where(e =>
                    e.Currency == currency &&
                    e.DeletedAt == null)
                .OrderByDescending(e => e.EffectiveFrom)
                .ToListAsync();
        }
    }
}
