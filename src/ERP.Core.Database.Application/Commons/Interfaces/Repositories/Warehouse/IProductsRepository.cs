using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IProductsRepository : IRepository<Products>
{
    Task<Products> InsertProduct(Products payload);
}