using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class ProfessionalServicesPayrollsRepository(ErpDbContext _context): Repository<ProfessionalServicesPayroll>(_context), IProfessionalServicesPayrollsRepository
    {
        public async Task<ProfessionalServicesPayroll> RegisterCollaboratorInTheProfessionalServicesPayroll(ProfessionalServicesPayroll professionalServicesPayroll)
        {
            var informationRegistered = await _context.ProfessionalServicesPayrolls.AddAsync(professionalServicesPayroll);
            return informationRegistered.Entity;
        }
    }
}