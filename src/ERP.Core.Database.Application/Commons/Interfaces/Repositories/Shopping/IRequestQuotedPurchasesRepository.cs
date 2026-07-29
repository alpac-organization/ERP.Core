using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IRequestQuotedPurchasesRepository : IRepository<RequestQuotedPurchases>
    {
        Task<RequestQuotedPurchases> RegisterRequestQuotedPurchases(RequestQuotedPurchases payload);
    }
}