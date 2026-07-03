using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IDucatRegistryDetailsManaguaRepository : IRepository<DucatRegistryDetailsManagua>
{
    Task<DucatRegistryDetailsManagua> RegisterDucatRegistryDetailsManagua(DucatRegistryDetailsManagua ducatRegistryDetails);
}