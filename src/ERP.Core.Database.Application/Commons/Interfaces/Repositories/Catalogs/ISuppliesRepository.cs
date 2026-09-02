using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface ISuppliesRepository : IRepository<Supplies>
{
    Task<Supplies> InsertSupply(Supplies supply);
}