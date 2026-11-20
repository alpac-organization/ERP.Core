using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class PhysicalCountRepository(ErpDbContext _context) : Repository<PhysicalCount>(_context), IPhysicalCountRepository
    {
        public async Task<PhysicalCount> RegisterPhysicalCount(PhysicalCount payload)
        {
            var record = await _context.PhysicalCounts.AddAsync(payload);
            return record.Entity;
        }
    }
}