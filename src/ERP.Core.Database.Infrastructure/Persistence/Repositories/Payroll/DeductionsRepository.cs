using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class DeductionsRepository(AppDbContext _context): Repository<Deduction>(_context), IDeductionsRepository
    {
        public async  Task<Deduction> RegisterDeduction(Deduction deduction)
        {
            var collaboratorRegistered = await _context.Deductions.AddAsync(deduction);
            return collaboratorRegistered.Entity;
        }
    }
}   