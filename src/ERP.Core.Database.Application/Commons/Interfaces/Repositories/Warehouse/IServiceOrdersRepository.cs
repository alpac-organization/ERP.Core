using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse
{
    public interface IServiceOrdersRepository : IRepository<ServiceOrder>
    {
        Task<ServiceOrder> RegisterServiceOrder(ServiceOrder payload);
    }
}