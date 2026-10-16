using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory
{
    public interface IKardexRepository : IRepository<Kardex>
    {
        public Task<Kardex> RegisterKardexMovement(Kardex payload);
    }
}