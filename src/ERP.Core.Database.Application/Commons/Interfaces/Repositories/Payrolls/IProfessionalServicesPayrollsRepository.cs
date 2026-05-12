using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IProfessionalServicesPayrollsRepository : IRepository<ProfessionalServicesPayroll>
    {
        Task<ProfessionalServicesPayroll> RegisterCollaboratorInTheProfessionalServicesPayroll(ProfessionalServicesPayroll payload);
    }
}