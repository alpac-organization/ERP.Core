using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IStockRepository : IRepository<Stocks>
{
    Task<Stocks> InsertStock(Stocks stock);
}