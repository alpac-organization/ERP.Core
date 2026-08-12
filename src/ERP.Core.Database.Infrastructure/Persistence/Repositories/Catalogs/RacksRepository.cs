using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class RacksRepository(ErpDbContext _context): Repository<Racks>(_context), IRacksRepository
    {
        public async Task<Racks> RegisterRack(Racks payload)
        {
            var record = await _context.Racks.AddAsync(payload);
            return record.Entity;
        }
    }
}