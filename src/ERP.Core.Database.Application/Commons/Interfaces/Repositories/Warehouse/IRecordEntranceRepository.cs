using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IRecordEntranceRepository : IRepository<RecordEntrance>
{
    Task<RecordEntrance> InsertRecordEntrance(RecordEntrance recordEntrance);
    Task<RecordEntrance?> ObtainWithDetailsById(Guid id);
}