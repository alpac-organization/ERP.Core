using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusAccrualRepository : IRepository<ChristmasBonusAccrual>
    {
        Task<ChristmasBonusAccrual> RegisterChristmasBonusAccrual(ChristmasBonusAccrual deduction); 
    }
}