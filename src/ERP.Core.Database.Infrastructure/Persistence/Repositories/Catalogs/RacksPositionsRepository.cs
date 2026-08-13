using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class RackPositionsRepository(ErpDbContext _context): Repository<RackPositions>(_context), IRackPositionsRepository
    {
        public async Task<RackPositions> RegisterRackPosition(RackPositions payload)
        {
            var record = await _context.RackPositions.AddAsync(payload);
            return record.Entity;
        }
    }
}