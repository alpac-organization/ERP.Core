using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class RecordsTravelExpensePaymentsRepository(ErpDbContext _context): Repository<RecordsTravelExpensePayments>(_context), IRecordsTravelExpensePaymentsRepository
    {
        public async Task<RecordsTravelExpensePayments> RegisterRecordsTravelExpensePayment(RecordsTravelExpensePayments payload)
        {
            var register = await _context.RecordsTravelExpensePayments.AddAsync(payload);
            return register.Entity;
        }
    }
}   