using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Shopping
{
    public class SupplierPaymentMethodRepository(ErpDbContext context) : Repository<SupplierPaymentMethod>(context), ISupplierPaymentMethodRepository
    {
    }
}