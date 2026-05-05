using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IAssignedTravelExpensesHistoryRepository: IRepository<AssignedTravelExpensesHistory>
    {
        Task<AssignedTravelExpensesHistory> RegisterAssignedTravelExpensesHistory(AssignedTravelExpensesHistory assignedTravelExpensesHistory); 
    }
}