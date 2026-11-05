using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IFuelRequestRepository : IRepository<FuelRequest>
    {
        Task<FuelRequest> RegisterFuelRequest(FuelRequest payload);
    }
}