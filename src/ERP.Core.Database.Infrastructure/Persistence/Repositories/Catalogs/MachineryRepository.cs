using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse
{
    public class MachineryRepository(ErpDbContext _context) : Repository<Machinery>(_context), IMachineryRepository
    {
        public async Task<Machinery> RegisterMachinery(Machinery payload)
        {
            await _context.Machineries.AddAsync(payload);
            return payload;
        }
    }
}