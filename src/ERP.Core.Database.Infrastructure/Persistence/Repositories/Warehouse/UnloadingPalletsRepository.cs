using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class UnloadingPalletsRepository(ErpDbContext context)
    : Repository<UnloadingPallets>(context), IUnloadingPalletsRepository
{
    public async Task<UnloadingPallets> InsertUnloadingPallet(UnloadingPallets payload)
    {
        var record = await _context.UnloadingPallets.AddAsync(payload);
        return record.Entity;
    }
}