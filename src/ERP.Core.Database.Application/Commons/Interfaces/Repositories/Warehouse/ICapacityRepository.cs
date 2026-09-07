using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface ICapacityRepository : IRepository<Capacity>
{
    Task<Capacity> RegisterCapacity(Capacity payload);
}