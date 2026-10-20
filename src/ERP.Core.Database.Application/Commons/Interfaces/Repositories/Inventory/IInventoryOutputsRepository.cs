using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IInventoryOutputsRepository : IRepository<InventoryOutputs>
    {
        Task<InventoryOutputs> RegisterInventoryOutput(InventoryOutputs payload);
    }
}