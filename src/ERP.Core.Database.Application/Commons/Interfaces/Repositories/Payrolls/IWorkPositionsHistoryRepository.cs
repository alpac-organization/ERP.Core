using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IWorkPositionsHistoryRepository : IRepository<WorkPositionHistory>
    {
        Task<WorkPositionHistory> RegisterHistory(WorkPositionHistory workingInformation);
    }
}