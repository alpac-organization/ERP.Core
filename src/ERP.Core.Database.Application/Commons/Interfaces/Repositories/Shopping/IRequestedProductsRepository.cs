using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IRequestedProductsRepository : IRepository<RequestedProduct>
    {
        Task<RequestedProduct> RegisterRequestedProduct(RequestedProduct payload);
    }
}