using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IIncomesRepository : IRepository<Income>
    {
        Task<Income> RegisterIncome(Income income); 
    }
}