using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IInventoryOutputsItemRepository : IRepository<InventoryOutputsItem>
    {
        Task<InventoryOutputsItem> RegisterInventoryOutputItem(InventoryOutputsItem payload);
    }
}