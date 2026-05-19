using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IVacationAccrualRepository : IRepository<VacationAccrual>
    {
        Task<VacationAccrual> RegisterVacationAccrual(VacationAccrual payload); 
    }
}