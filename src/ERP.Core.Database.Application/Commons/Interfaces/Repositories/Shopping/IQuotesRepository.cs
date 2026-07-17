using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IQuotesRepository : IRepository<Quotation>
    {
        Task<Quotation> RegisterQuotation(Quotation payload);
    }
}