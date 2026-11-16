using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IChristmasBonusPeriodRepository : IRepository<ChristmasBonusPeriod>
    {
        Task<ChristmasBonusPeriod> RegisterChristmasBonusPeriod(ChristmasBonusPeriod period);

        Task<ChristmasBonusPeriod?> GetChristmasBonusPeriodByCompanyAndDate(Guid companyId,DateOnly date);

        Task<ChristmasBonusPeriod?> GetChristmasBonusPeriodByCompanyAndEndYear(Guid companyId,int endYear);
    }
}