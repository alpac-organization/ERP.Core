using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class RecordEntranceRepository(ErpDbContext context)
    : Repository<RecordEntrance>(context), IRecordEntranceRepository
{
    public async Task<RecordEntrance> InsertRecordEntrance(RecordEntrance recordEntrance) 
    {
        var record = await _context.RecordEntrances.AddAsync(recordEntrance);
        return record.Entity;
    }

    public async Task<RecordEntrance?> ObtainWithDetailsById(Guid id) 
    {
        return await _context.RecordEntrances
            .Include(c => c.ReceptionEntrance)
            .Include(c => c.EntranceDucats)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}