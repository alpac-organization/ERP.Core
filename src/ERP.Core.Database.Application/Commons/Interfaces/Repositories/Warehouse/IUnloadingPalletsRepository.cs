using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IUnloadingPalletsRepository : IRepository<UnloadingPallets>
{
    Task<UnloadingPallets> InsertUnloadingPallet(UnloadingPallets unloadingPallet);
}