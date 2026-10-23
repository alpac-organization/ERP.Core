using ERP.Core.Database.Domain.Entities.Clients;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Clients
{
    public interface ICustomerCreditInformationsRepository : IRepository<CustomerCreditInformation>
    {
        Task<CustomerCreditInformation> RegisterCreditInformation(CustomerCreditInformation payload);
    }
}