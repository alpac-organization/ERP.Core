using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class ServiceOrder : BaseEntity<Guid>
    {

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;
    }
}