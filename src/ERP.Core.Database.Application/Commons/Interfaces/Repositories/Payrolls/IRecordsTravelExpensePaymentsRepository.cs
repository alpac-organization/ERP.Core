using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IRecordsTravelExpensePaymentsRepository : IRepository<RecordsTravelExpensePayments>
    {
        Task<RecordsTravelExpensePayments> RegisterRecordsTravelExpensePayment(RecordsTravelExpensePayments payload); 
    }
}