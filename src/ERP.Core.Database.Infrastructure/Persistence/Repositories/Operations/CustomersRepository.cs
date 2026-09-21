using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations
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