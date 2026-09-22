using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface ICustomerCreditInformationsRepository : IRepository<CustomerCreditInformation>
    {
        Task<CustomerCreditInformation> RegisterCreditInformation(CustomerCreditInformation payload);
    }
}