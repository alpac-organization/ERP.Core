using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class QuotesRepository(ErpDbContext _context) : Repository<Quotation>(_context), IQuotesRepository
    {
        public async Task<Quotation> RegisterQuotation(Quotation payload)
        {
            var record = await _context.Quotations.AddAsync(payload);
            return record.Entity;
        }
    }
    
}