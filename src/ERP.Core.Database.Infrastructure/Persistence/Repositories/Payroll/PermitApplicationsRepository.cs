using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class PermitApplicationsRepository(AppDbContext _context): Repository<PermitApplication>(_context), IPermitApplicationsRepository
    {
        public async Task<PermitApplication> CreatePermitApplication(PermitApplication payload)
        {
            var vacationRequestCreated = await _context.PermitApplications.AddAsync(payload);    
            return vacationRequestCreated.Entity;
        }
    }
}   