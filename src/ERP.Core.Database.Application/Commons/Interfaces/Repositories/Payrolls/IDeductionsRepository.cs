using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IDeductionsRepository : IRepository<Deduction>
    {
        Task<Deduction> RegisterDeduction(Deduction deduction); 
    }
}