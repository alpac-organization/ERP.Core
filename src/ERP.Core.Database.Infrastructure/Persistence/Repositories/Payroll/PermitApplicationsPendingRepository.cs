using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class PermitApplicationsPendingRepository(ErpDbContext _context): Repository<PermitApplicationPending>(_context), IPermitApplicationsPendingRepository
    {
        public async Task<PermitApplicationPending> CreatePermitApplicationPending(PermitApplicationPending payload)
        {
            var vacationRequestCreated = await _context.PermitApplicationsPending.AddAsync(payload);    
            return vacationRequestCreated.Entity;
        }
    }
}   