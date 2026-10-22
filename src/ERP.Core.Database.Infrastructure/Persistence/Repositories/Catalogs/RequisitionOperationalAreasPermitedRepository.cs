using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class RequisitionOperationalAreasPermitedRepository(ErpDbContext _context) : Repository<RequisitionOperationalAreasPermited>(_context), IRequisitionOperationalAreasPermitedRepository
    {
        public async Task<RequisitionOperationalAreasPermited> RegisterRequisitionOperationalAreasPermited(RequisitionOperationalAreasPermited payload)
        {
            var registered = await _context.RequisitionOperationalAreasPermits.AddAsync(payload);
            return registered.Entity;
        }
    }
}
