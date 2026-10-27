using ERP.Core.Database.Application.Commons.Interfaces;
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{

   public interface IPermitTypePolicyRepository : IRepository<PermitTypePolicy>
   {
      Task<PermitTypePolicy> RegisterPermitTypePolicy(PermitTypePolicy permitTypePolicy); 
   }
}