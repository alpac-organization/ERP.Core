using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
   public interface IAbsencesRepository : IRepository<Absence>
   {
      Task<Absence> RegisterAbsence(Absence absence);
   }
}
