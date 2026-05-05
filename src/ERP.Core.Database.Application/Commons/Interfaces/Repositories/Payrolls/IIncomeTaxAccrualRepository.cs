using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IIncomeTaxAccrualRepository : IRepository<IncomeTaxAccrual>
    {
        Task<IncomeTaxAccrual> RegisterIncomeTaxAccrual(IncomeTaxAccrual incomeTaxAccrual); 
    }
}