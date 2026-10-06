using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;
using ERP.Core.Database.Domain.Entities.Operations;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Operations;

public class CodesRepository(ErpDbContext context) : Repository<Codes>(context), ICodesRepository
{
    public async Task<Codes> GenerateCode(Codes payload)
    {
        await _context.Codes.AddAsync(payload);
        return payload;
    }
}