using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface ILotsCapacityRepository : IRepository<LotsCapacity>
{
    Task<LotsCapacity> RegisterLotsCapacity(LotsCapacity payload);
}
