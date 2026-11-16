using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusAccrualRepository : IRepository<ChristmasBonusAccrual>
    {
        Task<ChristmasBonusAccrual> RegisterChristmasBonusAccrual(ChristmasBonusAccrual accrual);

        Task<ChristmasBonusAccrual?> GetCurrentChristmasBonusAccrualMonthly(
            Guid collaboratorId,
            Guid christmasBonusPeriodId,
            int year,
            int month);

        Task<List<ChristmasBonusAccrual>> GetCurrentChristmasBonusAccrualByPeriod(
            Guid collaboratorId,
            Guid christmasBonusPeriodId);
    }
}