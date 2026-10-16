using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
   public interface IFaultCatalogRepository : IRepository<FaultCatalog>
   {
      Task<FaultCatalog> RegisterFaultCatalog(FaultCatalog faultCatalog);
   }
}