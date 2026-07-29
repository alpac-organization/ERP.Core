using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface ITransportUnitRepository : IRepository<TransportUnit>
{
        Task<TransportUnit> RegisterTransportUnit(TransportUnit payload);
}