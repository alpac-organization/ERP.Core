using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs.Warehouse;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs.Warehouse;

public class RacksManaguaRepository(ErpDbContext _context) : Repository<RacksManagua>(_context), IRacksManaguaRepository
{
    public async Task<RacksManagua> GetRacksManagua(RacksManagua payload)
    {
        var record = await _context.RacksManagua.AddAsync(payload);
        return record.Entity;
    }
}