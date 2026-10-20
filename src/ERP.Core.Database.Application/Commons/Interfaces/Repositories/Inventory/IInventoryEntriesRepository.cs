using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IInventoryEntriesRepository : IRepository<InventoryEntry>
    {
        Task<InventoryEntry> RegisterInventoryEntry(InventoryEntry payload);
    }
}