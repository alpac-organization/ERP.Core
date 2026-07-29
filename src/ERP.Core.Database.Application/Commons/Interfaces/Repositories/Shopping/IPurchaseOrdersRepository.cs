using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IPurchaseOrdersRepository : IRepository<PurchaseOrder>
    {
        Task<PurchaseOrder> RegisterPurchaseOrder(PurchaseOrder payload);
    }
}