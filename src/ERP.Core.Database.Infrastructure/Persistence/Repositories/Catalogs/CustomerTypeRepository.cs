using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;
public class CustomerTyperpository(ErpDbContext context)
    : Repository<CustomerType>(context), ICustomerTypeRepository
{
    public async Task<CustomerType> RegisterCustomerType(CustomerType payload)
    {
        var record = await _context.CustomersTypes.AddAsync(payload);
        return record.Entity;
    }
}