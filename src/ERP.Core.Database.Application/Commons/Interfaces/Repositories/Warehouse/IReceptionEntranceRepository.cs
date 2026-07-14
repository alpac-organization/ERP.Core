using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IReceptionEntranceRepository : IRepository<ReceptionEntrance>
{
    Task<ReceptionEntrance> InsertReceptionEntrance(ReceptionEntrance receptionEntrance);
}