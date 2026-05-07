using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface ISubsidyRepository: IRepository<Subsidy>
    {
        Task<Subsidy> CreateSubsidy(Subsidy payload);
    }
}