using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class WarehouseDetailsRepository(ErpDbContext context): Repository<WarehouseDetails>(context), IWarehouseDetailsRepository
{
    public async Task<WarehouseDetails> RegisterWarehouseDetails(WarehouseDetails payload)
    {
        var record = await _context.WarehouseDetails.AddAsync(payload);
        return record.Entity;
    }
}