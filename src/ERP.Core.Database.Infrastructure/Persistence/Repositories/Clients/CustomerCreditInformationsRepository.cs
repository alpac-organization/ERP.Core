using ERP.Core.Database.Domain.Entities.Clients;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Clients;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Clients
{
    public class CustomerCreditInformationsRepository(ErpDbContext context) : Repository<CustomerCreditInformation>(context), ICustomerCreditInformationsRepository
    {
        public async Task<CustomerCreditInformation> RegisterCreditInformation(CustomerCreditInformation payload)
        {
            await _context.CustomerCreditInformations.AddAsync(payload);
            return payload;
        }
    }
}