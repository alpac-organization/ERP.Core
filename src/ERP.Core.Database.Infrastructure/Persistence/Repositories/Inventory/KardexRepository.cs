using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class KardexRepository(ErpDbContext context) : Repository<Kardex>(context), IKardexRepository
    {
        public async  Task<Kardex> RegisterKardexMovement(Kardex payload)
        {
            var record = await _context.Kardex.AddAsync(payload);
            return record.Entity;
        }
    }
}