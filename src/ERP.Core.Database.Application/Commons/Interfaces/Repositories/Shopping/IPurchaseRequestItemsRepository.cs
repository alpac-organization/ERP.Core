using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping
{
    public interface IPurchaseRequestItemsRepository : IRepository<PurchaseRequestItem>
    {
        Task<PurchaseRequestItem> RegisterPurchaseRequestItem(PurchaseRequestItem payload);
    }
}