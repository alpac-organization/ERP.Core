using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class Location : BaseEntity<Guid>
    {
        public string? LocationName { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;
        

        public Guid AssistanceControlId { get; set; }
        public virtual AssistanceControl AssistanceControl { get; set; } = default!;
    }
}