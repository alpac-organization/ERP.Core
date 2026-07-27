using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface ISuppliersDetailsRepository : IRepository<SupplierDetails>
    {
        Task<SupplierDetails> RegisterSupplierDetails(SupplierDetails payload);
    }
}