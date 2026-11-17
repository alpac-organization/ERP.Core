using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface IExchangeRateHistoryRepository : IRepository<ExchangeRateHistory>
    {
        Task<ExchangeRateHistory> RegisterExchangeRateHistory(ExchangeRateHistory exchangeRateHistory);

        Task<ExchangeRateHistory?> GetExchangeRateByDate(Currency currency, DateOnly date);

        Task<List<ExchangeRateHistory>> GetExchangeRateHistoryByCurrency(Currency currency);
    }
}
