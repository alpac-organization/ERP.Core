using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class ManifestCancellationManaguaRepository(ErpDbContext _context) 
    : Repository<ManifestCancellationsManagua>(_context), IManifestCancellationsManaguaRepository
{
    public async Task<ManifestCancellationsManagua> GenerateManifestCancellationsManagua(ManifestCancellationsManagua payload)
    {
        var record = await _context.ManifestCancellationsManagua.AddAsync(payload);
        return record.Entity;
    }
}