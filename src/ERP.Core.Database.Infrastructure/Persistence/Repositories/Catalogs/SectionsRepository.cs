using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class SectionsRepository(ErpDbContext _context): Repository<Sections>(_context), ISectionsRepository
    {
        public async Task<Sections> RegisterSection(Sections payload)
        {
            var record = await _context.Sections.AddAsync(payload);
            return record.Entity;
        }
    }
}