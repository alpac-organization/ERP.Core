using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface ICustomerContactsRepository : IRepository<CustomerContacts>
    {
        Task<CustomerContacts> RegisterCustomerContact(CustomerContacts payload);
    }
}