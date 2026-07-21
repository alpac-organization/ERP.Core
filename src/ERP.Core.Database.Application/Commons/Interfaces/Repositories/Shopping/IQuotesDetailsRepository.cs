using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IQuotesDetailsRepository : IRepository<QuoteDetail>
    {
        Task<QuoteDetail> RegisterQuoteDetail(QuoteDetail payload);
    }
}