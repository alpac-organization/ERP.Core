using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class SectionCapacityRepository(ErpDbContext _context): Repository<SectionCapacity>(_context), ISectionCapacityRepository
    {
        public async Task<SectionCapacity> RegisterSectionCapacity(SectionCapacity payload)
        {
            var record = await _context.SectionCapacities.AddAsync(payload);
            return record.Entity;
        }
    }
}