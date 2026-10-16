using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class FaultCatalogRepository(ErpDbContext _context)
        : Repository<FaultCatalog>(_context), IFaultCatalogRepository
    {
        public async Task<FaultCatalog> RegisterFaultCatalog(FaultCatalog faultCatalog)
        {
            var registered = await _context.FaultCatalogs.AddAsync(faultCatalog);
            return registered.Entity;
        }
    }
}
