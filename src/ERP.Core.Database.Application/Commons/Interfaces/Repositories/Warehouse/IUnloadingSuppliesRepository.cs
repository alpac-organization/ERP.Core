using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IUnloadingSuppliesRepository : IRepository<UnloadingSupplies>
{
    Task<UnloadingSupplies> InsertUnloadingSupplie(UnloadingSupplies unloadingSupplie);
}