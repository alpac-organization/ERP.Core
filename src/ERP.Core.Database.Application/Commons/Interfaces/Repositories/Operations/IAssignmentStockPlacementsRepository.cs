using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

public interface IAssignmentStockPlacementsRepository : IRepository<AssignmentStockPlacements>
{
    Task<AssignmentStockPlacements> AssignStockPlacement(AssignmentStockPlacements payload);
}