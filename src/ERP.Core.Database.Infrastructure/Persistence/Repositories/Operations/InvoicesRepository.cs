using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
{
    public class InvoicesRepository(ErpDbContext context) : Repository<Invoice>(context), IInvoicesRepository
    {
        public async Task<Invoice> RegisterInvoice(Invoice payload)
        {
            await _context.Invoices.AddAsync(payload);
            return payload;
        }
    }
}