using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;

public class RacksPositionsCoordinatesRepository(ErpDbContext context) : Repository<RacksPositionsCoordinates>(context), IRacksPositionsCoordinatesRepository
{
    public async Task<RacksPositionsCoordinates> RegisterRackPositionCoordinate(RacksPositionsCoordinates payload)
    {
        var record = await _context.AddAsync(payload);
        return record.Entity;
    }
}