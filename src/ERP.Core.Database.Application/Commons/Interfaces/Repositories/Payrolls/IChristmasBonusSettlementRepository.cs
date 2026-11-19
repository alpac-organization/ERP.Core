using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusSettlementRepository : IRepository<ChristmasBonusSettlement>
    {
        Task<ChristmasBonusSettlement> RegisterChristmasBonusSettlement(ChristmasBonusSettlement settlement);

        Task<ChristmasBonusSettlement?> GetChristmasBonusSettlementByCollaboratorAndPeriod(
            Guid collaboratorId,
            Guid christmasBonusPeriodId);
    }
}
