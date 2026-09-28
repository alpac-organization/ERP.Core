using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IServicesOrdersRequisitionsRepository : IRepository<ServiceOrderRequistions>
    {
        Task<ServiceOrderRequistions> RegisterServicesOrderRequisitions(ServiceOrderRequistions payload);
    }
}