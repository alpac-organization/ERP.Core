using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface ICustomersRepository : IRepository<Customers>
    {
        Task<Customers> RegisterCustomer(Customers payload);
    }
}