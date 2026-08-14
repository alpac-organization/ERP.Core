using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse
{
    public class UnloadingDetailsRepository(ErpDbContext _context) : Repository<UnloadingDetails>(_context), IUnloadingDetailsRepository
    {
        public async Task<UnloadingDetails> InsertUnloadingDetails(UnloadingDetails unloadingDetails)
        {
            var record = await _context.UnloadingDetails.AddAsync(unloadingDetails);
            return record.Entity;
        }
    }
}