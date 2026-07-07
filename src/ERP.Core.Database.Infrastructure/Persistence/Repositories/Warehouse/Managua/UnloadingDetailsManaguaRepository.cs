using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class UnloadingDetailsManaguaRepository(ErpDbContext context)
    : Repository<UnloadingDetailsManagua>(context), IUnloadingDetailsManaguaRepository
{
    public async Task<UnloadingDetailsManagua> GetUnloadingDetailsManagua(UnloadingDetailsManagua payload)
    {
        var record= await _context.UnloadingDetailsManagua.AddAsync(payload);
        return record.Entity;
    }
}