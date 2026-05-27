using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class JobPositionsRepository(ErpDbContext _context): Repository<JobPosition>(_context), IJobPositionsRepository
    {
        public async Task<JobPosition> RegisterJobPosition(JobPosition payload)
        {
            var jobPositionRegistered = await _context.JobPositions.AddAsync(payload);
            return jobPositionRegistered.Entity;
        }
    }
}