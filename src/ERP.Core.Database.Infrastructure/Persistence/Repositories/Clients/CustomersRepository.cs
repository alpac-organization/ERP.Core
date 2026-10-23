using ERP.Core.Database.Domain.Entities.Clients;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Clients;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Clients
{
    public class CustomersRepository(ErpDbContext context) : Repository<Customers>(context), ICustomersRepository
    {
        public async Task<Customers> RegisterCustomer(Customers payload)
        {
            await _context.Customers.AddAsync(payload);
            return payload;
        }
    }
}