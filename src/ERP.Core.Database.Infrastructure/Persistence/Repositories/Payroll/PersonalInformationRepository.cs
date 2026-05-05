using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
    public class PersonalInformationRepository(AppDbContext _context): Repository<PersonalInformation>(_context), IPersonalInformationRepository
    {
        public async Task<PersonalInformation> RegisterPersonalInformation(PersonalInformation personalInformation)
        {
            var informationRegistered = await _context.PersonalInformations.AddAsync(personalInformation);
            return informationRegistered.Entity;
        }
    }
}