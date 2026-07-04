using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs.Warehouse;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.VisualBasic;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs.Warehouse;

public class ZonesManaguaRepository(ErpDbContext _context) : Repository<ZonesManagua>(_context), IZonesManaguaRepository
{
    public async Task<ZonesManagua> GetZonesManagua(ZonesManagua payload)
    {
        var record = await _context.ZonesManagua.AddAsync(payload);
        return record.Entity;
    }
}