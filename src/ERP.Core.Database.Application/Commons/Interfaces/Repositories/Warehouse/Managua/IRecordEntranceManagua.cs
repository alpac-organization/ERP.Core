using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IRecordEntranceManaguaRepository : IRepository<RecordEntranceManagua> // Corregido: IRecordEntranceManaguaRepository
{
    Task<RecordEntranceManagua> InsertRecordEntrance(RecordEntranceManagua recordEntrance);
    Task<RecordEntranceManagua?> ObtainWithDetailsById(Guid id);
}