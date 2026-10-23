using ERP.Core.Database.Domain.Entities.Clients;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Clients;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Clients;

public class CustomerChargesRepository(ErpDbContext context) : Repository<CustomerCharges>(context), ICustomerChargesRepository
{
    public async Task<CustomerCharges> RegisterCustomerCharge(CustomerCharges payload)
    {
        await _context.CustomerCharges.AddAsync(payload);
        return payload;
    }

}