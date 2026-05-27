using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class JobPosition : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? JobPositionName { get; set; }

        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;

        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; } = default!;
    }
}