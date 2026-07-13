using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IReceptionEntranceRepository : IRepository<ReceptionEntrance>
{
    Task<ReceptionEntrance> InsertReceptionDetails(ReceptionEntrance receptionDetails); // Corregido: InsertReceptionEntrance
}