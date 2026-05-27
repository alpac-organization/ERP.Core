using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class CostCentersRepository(ErpDbContext _context): Repository<CostCenter>(_context), ICostCentersRepository
    {
        public async Task<CostCenter> RegisterCostCenter(CostCenter payload)
        {
            var costCenterRegistered = await _context.CostCenters.AddAsync(payload);
            return costCenterRegistered.Entity;
        }
    }
}