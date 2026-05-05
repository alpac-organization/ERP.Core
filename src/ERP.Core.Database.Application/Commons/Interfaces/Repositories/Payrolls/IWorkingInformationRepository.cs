using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IWorkingInformationRepository : IRepository<WorkingInformation>
    {
        Task<WorkingInformation> RegisterWorkingInformation(WorkingInformation workingInformation);
    }
}