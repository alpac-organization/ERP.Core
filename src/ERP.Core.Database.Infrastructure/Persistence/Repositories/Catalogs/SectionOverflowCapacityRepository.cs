using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class SectionOverflowCapacityRepository(ErpDbContext _context): Repository<SectionOverflowCapacity>(_context), ISectionOverflowCapacityRepository
    {
        public async Task<SectionOverflowCapacity> RegisterSectionOverflowCapacity(SectionOverflowCapacity payload)
        {
            var record = await _context.SectionOverflowCapacities.AddAsync(payload);
            return record.Entity;
        }
    }
}