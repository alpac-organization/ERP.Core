using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class UnloadingDetailsRepository(ErpDbContext context)
    : Repository<UnloadingDetails>(context), IUnloadingDetailsRepository
{
    public async Task<UnloadingDetails> InsertUnloadingDetail(UnloadingDetails payload)
    {
        var record = await _context.UnloadingDetails.AddAsync(payload);
        return record.Entity;
    }
}