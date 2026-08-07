using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class MerchandisesRepository(ErpDbContext context): Repository<Merchandises>(context), IMerchandisesRepository
{
    public async Task<Merchandises> InsertMerchandise(Merchandises payload)
    {
        var record = await _context.Merchandises.AddAsync(payload);
        return record.Entity;
    }
}