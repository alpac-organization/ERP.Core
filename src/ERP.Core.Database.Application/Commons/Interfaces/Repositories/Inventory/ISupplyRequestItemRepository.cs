using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface ISupplyRequestItemRepository : IRepository<SupplyRequestItem>
    {
        Task<SupplyRequestItem> RegisterSupplyRequestItem(SupplyRequestItem payload);
    }
}