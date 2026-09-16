
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
   public interface IRackCoordinateRepository : IRepository<RacksCoordinates>
   {
      Task<RacksCoordinates> RegisterRackCoordinate(RacksCoordinates payload);
   }
}