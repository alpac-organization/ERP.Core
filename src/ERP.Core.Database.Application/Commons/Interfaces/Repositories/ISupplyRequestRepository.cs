using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories
{
    public interface ISupplyRequestRepository : IRepository<SupplyRequest>
    {
        Task<SupplyRequest> RegisterSupplyRequest(SupplyRequest payload);
    }
}