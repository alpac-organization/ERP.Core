using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class LotsPositionsRepository(ErpDbContext _context) : Repository<LotsPositions>(_context), ILotsPositionsRepository
    {
        public async Task<LotsPositions> RegisterLotPosition(LotsPositions payload)
        {
            var record = await _context.LotsPositions.AddAsync(payload);
            return record.Entity;
        }
    }
}