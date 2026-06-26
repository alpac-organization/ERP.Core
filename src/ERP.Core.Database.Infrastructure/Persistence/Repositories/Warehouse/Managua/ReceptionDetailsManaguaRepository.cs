using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class ReceptionDetailsManaguaReporitory(ErpDbContext context)
    : Repository<ReceptionDetailsManagua>(context), IReceptionDetailsManaguaRepository
{
    public async Task<ReceptionDetailsManagua> InsertReceptionDetails(ReceptionDetailsManagua receptionDetails)
    {
        var record = await _context.ReceptionDetailsManagua.AddAsync(receptionDetails);
        return record.Entity;
    }
}