using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IMerchandisesRepository : IRepository<Merchandises>
{
    Task<Merchandises> InsertMerchandise(Merchandises payload);
}