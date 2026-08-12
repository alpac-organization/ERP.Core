using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface ILotsRepository : IRepository<Lots>
{
    Task<Lots> RegisterLot(Lots payload);
}