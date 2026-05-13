using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class DeductionPaymentHistoryRepository(ErpDbContext _context): Repository<DeductionPaymentHistory>(_context), IDeductionPaymentHistoryRepository
    {
        public async  Task<DeductionPaymentHistory> RegisterDeductionPaymentHistory(DeductionPaymentHistory deduction)
        {
            var Registered = await _context.DeductionPaymentHistories.AddAsync(deduction);
            return Registered.Entity;
        }
    }
}   