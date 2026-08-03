using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IDucatRegistryRepository : IRepository<DucatRegistry>
{
        Task<DucatRegistry> RegisterDucatRegistry(DucatRegistry payload);
}