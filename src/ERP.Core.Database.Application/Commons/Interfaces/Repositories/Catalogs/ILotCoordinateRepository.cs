
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
   public interface ILotCoordinateRepository : IRepository<LotsCoordinates>
   {
      Task<LotsCoordinates> RegisterLotCoordinate(LotsCoordinates payload);
   }
}