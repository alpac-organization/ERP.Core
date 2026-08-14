using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse
{
    public class WarehouseAssignmentsRepository(ErpDbContext _context) : Repository<WarehouseAssignments>(_context), IWarehouseAssignmentsRepository
    {
    }
}