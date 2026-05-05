using ERP.Core.Database.Domain.Entities.Payrolls;


namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IPermitApplicationsRepository : IRepository<PermitApplication>
    {
        Task<PermitApplication> CreatePermitApplication(PermitApplication payload);
    }
}