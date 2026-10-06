using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;

public class LotsPositionsCoordinatesRepository(ErpDbContext context) : Repository<LotsPositionsCoordinates>(context), ILotsPositionsCoordinatesRepository
{
    public async Task<LotsPositionsCoordinates> RegisterLotPositionCoordinate(LotsPositionsCoordinates payload)
    {
        var record = await _context.AddAsync(payload);
        return record.Entity;
    }
}