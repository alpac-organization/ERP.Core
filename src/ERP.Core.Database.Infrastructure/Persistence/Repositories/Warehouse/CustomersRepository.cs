using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class CustomerRepository(ErpDbContext context): Repository<Customer>(context), ICustomerRepository
{
    public async Task<Customer> RegisterCustomer(Customer payload)
    {
        var record = await _context.Customers.AddAsync(payload);
        return record.Entity;
    }
}