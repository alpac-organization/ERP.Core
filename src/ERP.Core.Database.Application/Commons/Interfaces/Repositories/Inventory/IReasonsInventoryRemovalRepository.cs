using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IReasonsInventoryRemovalRepository : IRepository<ReasonsInventoryRemoval>
    {
        public Task<ReasonsInventoryRemoval> RegisterNewReasonInventoryRemoval(ReasonsInventoryRemoval payload);
    }
}