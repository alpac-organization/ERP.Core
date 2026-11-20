using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IPhysicalCountLineRepository : IRepository<PhysicalCountLine>
    {
        Task<PhysicalCountLine> RegisterPhysicalCountLine(PhysicalCountLine payload);
    }
}