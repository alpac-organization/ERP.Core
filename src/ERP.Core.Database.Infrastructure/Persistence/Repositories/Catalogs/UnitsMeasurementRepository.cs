using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class UnitsMeasurementRepository(ErpDbContext _context): Repository<UnitMeasure>(_context), IUnitsMeasurementRepository
    {
        public async Task<UnitMeasure> RegisterUnitMeasure(UnitMeasure payload)
        {
            var record = await _context.UnitsMeasurement.AddAsync(payload);
            return record.Entity;
        }
    }
}