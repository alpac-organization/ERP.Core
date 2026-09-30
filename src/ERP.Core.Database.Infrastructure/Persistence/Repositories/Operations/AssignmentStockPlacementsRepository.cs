using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations;

public class AssignmentStockPlacementsRepository(ErpDbContext context)
    : Repository<AssignmentStockPlacements>(context), IAssignmentStockPlacementsRepository
{
    public async Task<AssignmentStockPlacements> AssignStockPlacement(AssignmentStockPlacements payload)
    {
        var record = await _context.AssignmentStockPlacements.AddAsync(payload);
        return record.Entity;
    }
}