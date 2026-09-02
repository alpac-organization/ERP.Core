using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class SuppliesRepository(ErpDbContext _context) : Repository<Supplies>(_context), ISuppliesRepository
    {
        public async Task<Supplies> InsertSupply(Supplies payload)
        {
            var record = await _context.Supplies.AddAsync(payload);
            return record.Entity;
        }
    }
}