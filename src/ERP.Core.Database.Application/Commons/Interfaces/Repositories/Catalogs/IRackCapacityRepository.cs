using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface IRackCapacityRepository : IRepository<RackCapacity>
{
    Task<RackCapacity> RegisterRackCapacity(RackCapacity payload);
}
