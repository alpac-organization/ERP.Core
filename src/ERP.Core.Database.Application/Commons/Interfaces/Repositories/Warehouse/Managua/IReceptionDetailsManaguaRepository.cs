using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IReceptionDetailsManaguaRepository : IRepository<ReceptionDetailsManagua>
{
    Task<ReceptionDetailsManagua> InsertReceptionDetails(ReceptionDetailsManagua receptionDetails); // Corregido: InsertReceptionDetails
}