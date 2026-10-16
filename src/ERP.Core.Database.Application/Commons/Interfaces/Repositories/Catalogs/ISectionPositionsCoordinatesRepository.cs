using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface ISectionPositionsCoordinatesRepository : IRepository<SectionPositionsCoordinates>
{
    Task<SectionPositionsCoordinates> RegisterSectionPositionCoordinate(SectionPositionsCoordinates payload);
}
