using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class WorkingInformationRepository(ErpDbContext _context): Repository<WorkingInformation>(_context), IWorkingInformationRepository
    {
        public async Task<WorkingInformation> RegisterWorkingInformation(WorkingInformation workingInformation)
        {
            var informationRegistered = await _context.WorkingInformation.AddAsync(workingInformation);
            return informationRegistered.Entity;
        }
    }
}