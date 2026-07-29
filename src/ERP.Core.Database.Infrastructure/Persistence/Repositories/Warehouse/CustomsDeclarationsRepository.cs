using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class CustomsDeclarationsRepository(ErpDbContext context)
    : Repository<CustomsDeclarations>(context), ICustomsDeclarationsRepository
{
    public async Task<CustomsDeclarations> RegisterCustomsDeclarations(CustomsDeclarations payload)
    {
        var record = await _context.CustomsDeclarations.AddAsync(payload);
        return record.Entity;
    }
}