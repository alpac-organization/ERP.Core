using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IDucatRegistryManaguaRepository : IRepository<DucatRegistryManagua>
{
    Task<DucatRegistryManagua> RegisterDucatRegistryManagua(DucatRegistryManagua ducatRegistry);
}