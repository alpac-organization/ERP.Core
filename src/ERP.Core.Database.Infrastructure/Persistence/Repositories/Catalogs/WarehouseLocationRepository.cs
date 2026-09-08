using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class WarehouseLocationRepository(ErpDbContext _context): Repository<WarehouseLocation>(_context), IWarehouseLocationRepository
    {
        public async Task<WarehouseLocation> RegisterLocation(WarehouseLocation payload)
        {
            var record = await _context.WarehouseLocations.AddAsync(payload);
            return record.Entity;
        }
    }
}