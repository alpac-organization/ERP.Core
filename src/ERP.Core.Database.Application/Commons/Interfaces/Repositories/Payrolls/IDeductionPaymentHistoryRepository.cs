using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IDeductionPaymentHistoryRepository : IRepository<DeductionPaymentHistory>
    {
        Task<DeductionPaymentHistory> RegisterDeductionPaymentHistory(DeductionPaymentHistory deductionPaymentHistory); 
    }
}