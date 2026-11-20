using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class PhysicalCountLineRepository(ErpDbContext _context) : Repository<PhysicalCountLine>(_context), IPhysicalCountLineRepository
    {
        public async Task<PhysicalCountLine> RegisterPhysicalCountLine(PhysicalCountLine payload)
        {
            var record = await _context.PhysicalCountLines.AddAsync(payload);
            return record.Entity;
        }
    }
}