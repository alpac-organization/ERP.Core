using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface IRacksRepository : IRepository<Racks>
{
    Task<Racks> RegisterRack(Racks payload);
}