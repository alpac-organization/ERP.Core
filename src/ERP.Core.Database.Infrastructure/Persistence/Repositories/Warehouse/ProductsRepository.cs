using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class ProductsRepository(ErpDbContext context): Repository<Products>(context), IProductsRepository
{
    public async Task<Products> InsertProduct(Products payload)
    {
        var record = await _context.Products.AddAsync(payload);
        return record.Entity;
    }
}