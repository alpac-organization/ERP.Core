using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface ICategoryProductsRepository : IRepository<CategoryProducts>
{
    Task<CategoryProducts> CreateCategoryProduct(CategoryProducts payload);
}