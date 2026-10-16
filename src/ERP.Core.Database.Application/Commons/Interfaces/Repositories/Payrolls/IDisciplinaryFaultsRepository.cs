using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
   public interface IDisciplinaryFaultsRepository: IRepository<DisciplinaryFault>
   {
      Task<DisciplinaryFault> RegisterDisciplinaryFault(DisciplinaryFault disciplinaryFault);
   }
}