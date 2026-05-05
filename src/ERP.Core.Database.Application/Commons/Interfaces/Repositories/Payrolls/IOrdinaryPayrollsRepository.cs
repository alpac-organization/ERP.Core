using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IOrdinaryPayrollsRepository : IRepository<OrdinaryPayroll>
    {
        Task<OrdinaryPayroll> RegisterCollaboratorInTheOrdinaryPayroll(OrdinaryPayroll payload);
    }
}