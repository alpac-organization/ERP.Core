using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
   public class RackCoordinateRepository(ErpDbContext _context) : Repository<RacksCoordinates>(_context), IRackCoordinateRepository
   {
      public async Task<RacksCoordinates> RegisterRackCoordinate(RacksCoordinates payload)
      {
         var record = await _context.AddAsync(payload);
         return record.Entity;
      }
   }
}