using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWarehouseTercerizadaRepository : IRepository<WarehouseTercerizada>
{
    Task<WarehouseTercerizada> RegisterWarehouseTercerizada(WarehouseTercerizada payload);
}