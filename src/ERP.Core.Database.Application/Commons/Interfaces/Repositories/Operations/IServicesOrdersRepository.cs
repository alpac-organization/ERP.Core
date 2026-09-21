using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface IServicesOrdersRepository : IRepository<ServicesOrder>
    {
        Task<ServicesOrder> RegisterServicesOrder(ServicesOrder payload);
    }
}