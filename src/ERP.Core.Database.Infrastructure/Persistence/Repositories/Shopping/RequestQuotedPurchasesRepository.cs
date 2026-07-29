using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class RequestQuotedPurchasesRepository(ErpDbContext _context) : Repository<RequestQuotedPurchases>(_context), IRequestQuotedPurchasesRepository
    {
        public async Task<RequestQuotedPurchases> RegisterRequestQuotedPurchases(RequestQuotedPurchases payload)
        {
            var record = await _context.RequestQuotedPurchases.AddAsync(payload);
            return record.Entity;
        }
    }
    
}