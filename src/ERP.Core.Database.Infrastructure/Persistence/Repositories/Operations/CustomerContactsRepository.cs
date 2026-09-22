using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
{
    public class CustomerContactsRepository(ErpDbContext context) : Repository<CustomerContacts>(context), ICustomerContactsRepository
    {
        public async Task<CustomerContacts> RegisterCustomerContact(CustomerContacts payload)
        {
            await _context.CustomerContacts.AddAsync(payload);
            return payload;
        }
    }
}