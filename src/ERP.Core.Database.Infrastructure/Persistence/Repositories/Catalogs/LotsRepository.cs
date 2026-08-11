using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class LotsRepository(ErpDbContext _context) : Repository<Lots>(_context), ILotsRepository
    {
        public async Task<Lots> RegisterLot(Lots payload)
        {
            var record = await _context.Lots.AddAsync(payload);
            return record.Entity;
        }
    }
}