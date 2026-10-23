using ERP.Core.Database.Domain.Entities.Clients;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Clients
{
    public interface ICustomersRepository : IRepository<Customers>
    {
        Task<Customers> RegisterCustomer(Customers payload);
    }
}