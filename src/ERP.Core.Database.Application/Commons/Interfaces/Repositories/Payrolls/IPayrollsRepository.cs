namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IPayrollsRepository : IRepository<Domain.Entities.Payrolls.Payroll>
    {
        Task<Database.Domain.Entities.Payrolls.Payroll> InitializePayroll(Domain.Entities.Payrolls.Payroll payload);
    }
}