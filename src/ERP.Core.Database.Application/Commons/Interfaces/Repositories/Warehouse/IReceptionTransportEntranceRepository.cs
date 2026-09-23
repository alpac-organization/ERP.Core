using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IReceptionTransportEntranceRepository : IRepository<ReceptionTransportEntrance>
{
    Task<ReceptionTransportEntrance> RegisterTransport(ReceptionTransportEntrance receptionTransportEntrance);
}