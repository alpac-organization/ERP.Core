using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IProductsRepository : IRepository<Product>
{
    Task<List<Product>> GetRootProductsWithDetailsAsync(CancellationToken cancellationToken);
}