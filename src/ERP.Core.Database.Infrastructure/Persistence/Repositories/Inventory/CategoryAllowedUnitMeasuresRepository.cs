using ERP.Core.Database.Domain.Entities.Inventory;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Inventory;

public class CategoryAllowedUnitMeasuresRepository(ErpDbContext context)
    : Repository<CategoryAllowedUnitMeasures>(context), ICategoryAllowedUnitMeasuresRepository
{
}