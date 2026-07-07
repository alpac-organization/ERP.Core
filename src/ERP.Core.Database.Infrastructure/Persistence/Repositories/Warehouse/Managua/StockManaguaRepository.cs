using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class StockManaguaRepository(ErpDbContext context) 
    : Repository<StocksManagua>(context), IStockManaguaRepository
{
    public async Task<StocksManagua> GetStocksManagua(StocksManagua payload)
    {
        var record = await _context.StocksManagua.AddAsync(payload);
        return record.Entity;
    }
}