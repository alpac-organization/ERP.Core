using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class LocationsRepository(ErpDbContext _context): Repository<Location>(_context), ILocationsRepository
    {
        public async Task<Location> RegisterLocation(Location payload)
        {
            var record = await _context.Locations.AddAsync(payload);
            return record.Entity;
        }
    }
}