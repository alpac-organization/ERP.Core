using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class SectionPositionRepository(ErpDbContext _context): Repository<SectionPositions>(_context), ISectionPositionsRepository
    {
        public async Task<SectionPositions> RegisterPosition(SectionPositions payload)
        {
            var record = await _context.SectionPositions.AddAsync(payload);
            return record.Entity;
        }
    }
}