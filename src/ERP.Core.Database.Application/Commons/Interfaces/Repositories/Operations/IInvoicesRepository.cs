using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface IInvoicesRepository : IRepository<Invoice>
    {
        Task<Invoice> RegisterInvoice(Invoice payload);
    }
}