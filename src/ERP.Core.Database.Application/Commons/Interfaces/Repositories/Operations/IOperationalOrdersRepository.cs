using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface IOperationalOrdersRepository : IRepository<OperationalOrder>
    {
        Task<OperationalOrder> RegisterOperationalOrder(OperationalOrder payload);
        Task<OperationalOrder?> GetByDucaNumberAsync(string ducaNumber, CancellationToken ct = default);
    }
}