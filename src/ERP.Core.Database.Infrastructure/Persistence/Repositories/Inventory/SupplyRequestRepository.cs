using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory
{
    public class SupplyRequestRepository(ErpDbContext context) : Repository<SupplyRequest>(context), ISupplyRequestRepository
    {
        public async Task<SupplyRequest> RegisterSupplyRequest(SupplyRequest payload)
        {
            var record = await _context.SupplyRequests.AddAsync(payload);
            return record.Entity;
        }
    }
}