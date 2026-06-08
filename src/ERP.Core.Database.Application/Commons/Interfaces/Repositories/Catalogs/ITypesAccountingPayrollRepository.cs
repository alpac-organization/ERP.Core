using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface ITypesAccountingPayrollRepository: IRepository<TypesAccountingPayroll>
    {
        Task<TypesAccountingPayroll> RegisterTypeAccountingPayroll(TypesAccountingPayroll payload); 
    }
}