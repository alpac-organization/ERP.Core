using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IPendingDeductionBalancesRepository : IRepository<PendingDeductionBalance>
    {
        Task<List<PendingDeductionBalance>> GetUnrecoveredBalancesByCollaboratorAsync(Guid collaboratorId);
        Task<List<PendingDeductionBalance>> GetBalancesByOriginPayrollAsync(Guid payrollId);
    }
}