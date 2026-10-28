using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class InventoryAreasPermissionsRepository(ErpDbContext context) : Repository<InventoryAreasPermissions>(context), IInventoryAreasPermissionsRepository
    {
        public async Task<InventoryAreasPermissions> RegisterNewPermission(InventoryAreasPermissions payload)
        {
            var record = await _context.InventoryAreasPermissions.AddAsync(payload);
            return record.Entity;
        }
    }
}