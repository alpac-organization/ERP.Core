using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class CustomsDeclarationDetailsRepository(ErpDbContext context)
    : Repository<CustomsDeclarationDetails>(context), ICustomsDeclarationDetailsRepository
{
    public async Task<CustomsDeclarationDetails> RegisterCustomsDeclarationDetails(CustomsDeclarationDetails payload)
    {
        var record = await _context.CustomsDeclarationDetails.AddAsync(payload);
        return record.Entity;
    }
}
