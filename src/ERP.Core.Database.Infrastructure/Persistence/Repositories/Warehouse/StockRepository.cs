using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class StockRepository(ErpDbContext context)
    : Repository<Stocks>(context), IStockRepository
{
    public async Task<Stocks> InsertStock(Stocks payload)
    {
        var record = await _context.Stocks.AddAsync(payload);
        return record.Entity;
    }
}