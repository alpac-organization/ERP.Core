using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class ReceptionEntranceReporitory(ErpDbContext context)
    : Repository<ReceptionEntrance>(context), IReceptionEntranceRepository
{
    public async Task<ReceptionEntrance> InsertReceptionDetails(ReceptionEntrance receptionDetails)
    {
        var record = await _context.ReceptionDetailsManagua.AddAsync(receptionDetails);
        return record.Entity;
    }
}