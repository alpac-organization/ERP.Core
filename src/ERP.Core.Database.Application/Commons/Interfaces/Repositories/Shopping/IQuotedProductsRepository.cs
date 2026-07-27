using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IQuotedProductsRepository : IRepository<QuotedProduct>
    {
        Task<QuotedProduct> RegisterQuotedProduct(QuotedProduct payload);
    }
}