using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface IRacksPositionsCoordinatesRepository : IRepository<RacksPositionsCoordinates>
{
    Task<RacksPositionsCoordinates> RegisterRackPositionCoordinate(RacksPositionsCoordinates payload);
}