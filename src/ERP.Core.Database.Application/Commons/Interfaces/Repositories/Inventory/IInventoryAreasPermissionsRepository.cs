using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IInventoryAreasPermissionsRepository : IRepository<InventoryAreasPermissions>
    {
        public Task<InventoryAreasPermissions> RegisterNewPermission(InventoryAreasPermissions payload);
    }
}