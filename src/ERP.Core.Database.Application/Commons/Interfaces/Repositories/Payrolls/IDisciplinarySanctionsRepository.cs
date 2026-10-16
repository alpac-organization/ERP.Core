using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
   public interface IDisciplinarySanctionsRepository : IRepository<DisciplinarySanction>
   {
      Task<DisciplinarySanction> RegisterDisciplinarySanction(DisciplinarySanction disciplinarySanction);
   }
}