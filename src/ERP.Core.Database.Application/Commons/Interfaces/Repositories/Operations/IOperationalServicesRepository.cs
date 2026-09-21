using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface IOperationalServicesRepository : IRepository<OperationalService>
    {
        Task<OperationalService> RegisterOperationalService(OperationalService payload);
    }
}