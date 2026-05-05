using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IVacationsRepository : IRepository<Vacation>
    {
        Task<Vacation> RegisterVacationControl(Vacation payload);
    }
}