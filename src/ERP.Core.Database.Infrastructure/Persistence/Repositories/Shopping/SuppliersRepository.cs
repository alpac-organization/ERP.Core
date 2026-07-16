using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class SuppliersRepository(ErpDbContext _context) : Repository<Supplier>(_context), ISuppliersRepository
    {
        public async Task<Supplier> RegisterSupplier(Supplier collaborator)
        {
            var record = await _context.Suppliers.AddAsync(collaborator);
            return record.Entity;
        }
    }
    
}