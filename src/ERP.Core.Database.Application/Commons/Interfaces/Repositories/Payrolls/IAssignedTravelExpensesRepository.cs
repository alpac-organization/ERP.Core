using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IAssignedTravelExpensesRepository: IRepository<AssignedTravelExpenses>
    {
        Task<AssignedTravelExpenses> RegisterAssignedTravelExpenses(AssignedTravelExpenses assignedTravelExpenses); 
    }
}