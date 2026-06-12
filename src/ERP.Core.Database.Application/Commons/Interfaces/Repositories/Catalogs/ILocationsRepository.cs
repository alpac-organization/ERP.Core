using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface ILocationsRepository : IRepository<Location>
    {
        Task<Location> RegisterLocation(Location payload);
    }
}