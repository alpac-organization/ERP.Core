using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class WarehouseTercerizadaRepository(ErpDbContext context): Repository<WarehouseTercerizada>(context), IWarehouseTercerizadaRepository
{
    public async Task<WarehouseTercerizada> RegisterWarehouseTercerizada(WarehouseTercerizada payload)
    {
        var record = await _context.WarehouseTercerizadas.AddAsync(payload);
        return record.Entity;
    }
}