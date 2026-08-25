using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IReassignmentMemoryItemsRepository : IRepository<ReassignmentMemoryItems>
{
    Task<ReassignmentMemoryItems> InsertReassignmentMemoryItem(ReassignmentMemoryItems memoryItem);
}