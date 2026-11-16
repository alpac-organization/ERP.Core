using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusAdvanceRepository : IRepository<ChristmasBonusAdvance>
    {
        Task<ChristmasBonusAdvance> RegisterChristmasBonusAdvance(ChristmasBonusAdvance bonusAdvance);

         Task<List<ChristmasBonusAdvance>> GetPaidAdvances(Guid collaboratorId,Guid christmasBonusPeriodId);
         Task<decimal> GetTotalPaidAdvances(Guid collaboratorId,Guid christmasBonusPeriodId);
    }
}