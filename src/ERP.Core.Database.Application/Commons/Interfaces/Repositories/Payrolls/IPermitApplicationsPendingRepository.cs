using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IPermitApplicationsPendingRepository : IRepository<PermitApplicationPending>
    {
        Task<PermitApplicationPending> CreatePermitApplicationPending(PermitApplicationPending payload);
    }
}