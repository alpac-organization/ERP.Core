using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class QuotesDetailsRepository(ErpDbContext _context) : Repository<QuoteDetail>(_context), IQuotesDetailsRepository
    {
        public async Task<QuoteDetail> RegisterQuoteDetail(QuoteDetail payload)
        {
            var record = await _context.QuotesDetails.AddAsync(payload);
            return record.Entity;
        }
    }
    
}