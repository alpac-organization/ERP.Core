using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class DiscrepanciesManaguaRepository(ErpDbContext _context) : Repository<DiscrepanciesManagua>(_context), IDiscrepanciesManaguaRepository
{
    public async Task<DiscrepanciesManagua> RegisterDiscrepanciesManagua(DiscrepanciesManagua payload)
    {
        var record = await _context.DiscrepanciesManagua.AddAsync(payload);
        return record.Entity;
    }
}