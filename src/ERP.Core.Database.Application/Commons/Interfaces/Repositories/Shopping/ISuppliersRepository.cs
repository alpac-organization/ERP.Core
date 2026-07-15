using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface ISuppliersRepository : IRepository<Supplier>
    {
        Task<Supplier> RegisterSupplier(Supplier payload);
    }
}