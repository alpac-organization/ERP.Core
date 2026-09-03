using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IUnloadingPositionsReservationsRepository : IRepository<UnloadingPositionReservations>
{
    Task<UnloadingPositionReservations> InsertPositionReservation(UnloadingPositionReservations unloadingPositionReservation);
}