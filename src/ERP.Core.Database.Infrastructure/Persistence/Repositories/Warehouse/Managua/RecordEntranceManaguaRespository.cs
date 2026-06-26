using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class RecordEntranceManaguaRepository(ErpDbContext context)
    : Repository<RecordEntranceManagua>(context), IRecordEntranceManaguaRepository
{
    public async Task<RecordEntranceManagua> InsertRecordEntrance(RecordEntranceManagua recordEntrance) 
    {
        var record = await _context.RecordEntrancesManagua.AddAsync(recordEntrance);
        return record.Entity;
    }

    public async Task<RecordEntranceManagua?> ObtainWithDetailsById(Guid id) 
    {
        return await _context.RecordEntrancesManagua
            .Include(c => c.ReceptionDetails)
            .Include(c => c.EntranceDucats)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}