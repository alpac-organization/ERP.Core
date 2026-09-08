using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface IWarehouseLocationRepository : IRepository<WarehouseLocation>
    {
        Task<WarehouseLocation> RegisterLocation(WarehouseLocation payload);
    }
}