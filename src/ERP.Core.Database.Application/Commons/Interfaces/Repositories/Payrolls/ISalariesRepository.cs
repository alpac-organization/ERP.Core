using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface ISalariesRepository : IRepository<Salary>
    {
        Task<Salary> RegisterSalary(Salary payload);
    }
}