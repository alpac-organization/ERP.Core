using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs
{
    public class TypesAccountingPayrollRepository(ErpDbContext _context): Repository<TypesAccountingPayroll>(_context), ITypesAccountingPayrollRepository
    {
        public async  Task<TypesAccountingPayroll> RegisterTypeAccountingPayroll(TypesAccountingPayroll payload)
        {
            var record = await _context.TypesAccountingPayrolls.AddAsync(payload);
            return record.Entity;
        }
    }
}