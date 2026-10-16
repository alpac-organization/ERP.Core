using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;

public class SectionPositionsCoordinatesRepository(ErpDbContext context) : Repository<SectionPositionsCoordinates>(context), ISectionPositionsCoordinatesRepository
{
    public async Task<SectionPositionsCoordinates> RegisterSectionPositionCoordinate(SectionPositionsCoordinates payload)
    {
        var record = await _context.AddAsync(payload);
        return record.Entity;
    }
}
