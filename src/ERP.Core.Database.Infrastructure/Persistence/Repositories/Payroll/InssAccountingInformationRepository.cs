using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class InssAccountingInformationRepository(ErpDbContext _context): Repository<InssAccountingInformation>(_context), IInssAccountingInformationRepository
    {
        public async Task<InssAccountingInformation> RegisterInssAccountingInformation(InssAccountingInformation income)
        {
            var record = await _context.InssAccountingInformation.AddAsync(income);
            return record.Entity;
        }
    }
}   