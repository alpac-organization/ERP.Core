using ERP.Core.Database.Domain.Entities.Clients;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Clients;

public interface ICustomerChargesRepository : IRepository<CustomerCharges>
{
    Task<CustomerCharges> RegisterCustomerCharge(CustomerCharges payload);
}