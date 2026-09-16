using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
   public class LotCoordinateRepository(ErpDbContext _context) : Repository<LotsCoordinates>(_context), ILotCoordinateRepository
   {
      public async Task<LotsCoordinates> RegisterLotCoordinate(LotsCoordinates payload)
      {
         var record = await _context.AddAsync(payload);
         return record.Entity;
      }
   }
}