using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IPhysicalCountRepository : IRepository<PhysicalCount>
    {
        Task<PhysicalCount> RegisterPhysicalCount(PhysicalCount payload);
    }
}