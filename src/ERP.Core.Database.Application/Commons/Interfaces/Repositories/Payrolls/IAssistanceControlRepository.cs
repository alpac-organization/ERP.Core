using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IAssistanceControlRepository: IRepository<AssistanceControl>
    {
        Task<AssistanceControl> RegisterAssistanceControl(AssistanceControl assistanceControl); 
    }
}