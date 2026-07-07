using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IEntranceDucatsManaguaRepository : IRepository<EntranceDucatsManagua>
{
    Task<EntranceDucatsManagua> InsertEntranceDucat(EntranceDucatsManagua entranceDucats);
    Task InsertEntranceDucatsRange(IEnumerable<EntranceDucatsManagua> entranceDucats);
}