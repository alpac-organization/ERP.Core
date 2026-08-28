using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse
{
    public class WarehouseMachineryRepository(ErpDbContext _context) : Repository<WarehouseMachinery>(_context), IWarehouseMachineryRepository
    {
        public async Task<WarehouseMachinery> RegisterMachinery(WarehouseMachinery payload)
        {
            await _context.WarehouseMachineries.AddAsync(payload);
            return payload;
        }
    }
}