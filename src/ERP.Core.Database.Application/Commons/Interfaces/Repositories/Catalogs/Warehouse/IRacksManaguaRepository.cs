using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs.Warehouse;

public interface IRacksManaguaRepository : IRepository<RacksManagua>
{
    Task<RacksManagua> GetRacksManagua(RacksManagua racks);
}