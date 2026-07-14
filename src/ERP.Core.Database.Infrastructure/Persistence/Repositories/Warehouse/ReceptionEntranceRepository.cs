using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class ReceptionEntranceReporitory(ErpDbContext context)
    : Repository<ReceptionEntrance>(context), IReceptionEntranceRepository
{
    public async Task<ReceptionEntrance> InsertReceptionEntrance(ReceptionEntrance receptionEntrance)
    {
        var record = await _context.ReceptionEntrances.AddAsync(receptionEntrance);
        return record.Entity;
    }
}