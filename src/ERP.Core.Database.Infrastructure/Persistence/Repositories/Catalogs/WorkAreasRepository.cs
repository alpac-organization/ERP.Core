using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class WorkAreasRepository(ErpDbContext _context): Repository<WorkArea>(_context), IWorkAreasRepository
    {
        public async Task<WorkArea> RegisterWorkArea(WorkArea payload)
        {
            var workAreaRegistered = await _context.WorkAreas.AddAsync(payload);
            return workAreaRegistered.Entity;
        }
    }
}