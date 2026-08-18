using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class ShippingComapaniesRepository(ErpDbContext _context) : Repository<ShippingCompanies>(_context), IShippingComapaniesRepository
    {
        public async Task<ShippingCompanies> RegisterShippingCompany(ShippingCompanies payload)
        {
            var record = await _context.ShippingCompanies.AddAsync(payload);
            return record.Entity;
        }
    }
}