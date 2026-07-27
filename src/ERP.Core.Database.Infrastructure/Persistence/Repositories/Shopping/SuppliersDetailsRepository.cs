using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class SuppliersDetailsRepository(ErpDbContext _context) : Repository<SupplierDetails>(_context), ISuppliersDetailsRepository
    {
        public async Task<SupplierDetails> RegisterSupplierDetails(SupplierDetails payload)
        {
            var record = await _context.SupplierDetails.AddAsync(payload);
            return record.Entity;
        }
    }
    
}