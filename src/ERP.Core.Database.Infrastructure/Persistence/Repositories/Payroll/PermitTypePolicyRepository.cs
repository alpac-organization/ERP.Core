using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
   public class PermitTypePolicyRepository(ErpDbContext _context):Repository<PermitTypePolicy>(_context), IPermitTypePolicyRepository
   {
      public async Task<PermitTypePolicy> RegisterPermitTypePolicy(PermitTypePolicy payload)
      {
         var permitTypePolicy = await _context.PermitTypePolicies.AddAsync(payload);
         return permitTypePolicy.Entity;
      }
   }
}