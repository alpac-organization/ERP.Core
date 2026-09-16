

using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
   public class SectionCoordinatesRepository(ErpDbContext _context) : Repository<SectionCoordinates>(_context), ISectionCoordinatesRepository
   {
      public async Task<SectionCoordinates> RegisterSectionCoordinates(SectionCoordinates payload)
      {
         var record = await _context.AddAsync(payload);
         return record.Entity;
      }
   }
}