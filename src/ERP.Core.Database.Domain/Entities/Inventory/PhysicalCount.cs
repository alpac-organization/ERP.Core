using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Inventory
{
    public class PhysicalCount : BaseEntity<Guid>
    {
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
        public Guid? AreaId { get; set; }
        public Guid? CostCenterId { get; set; }
        public Guid? CategoryId { get; set; }
        public PhysicalCountStatus Status { get; set; } = PhysicalCountStatus.Draft;
        public string? Notes { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? CompletedBy { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual Branch Branch { get; set; } = default!;
        public virtual Company Company { get; set; } = default!;
        public virtual WorkArea? Area { get; set; }
        public virtual CostCenter? CostCenter { get; set; }
        public virtual CategoryProducts? Category { get; set; }
        public virtual ICollection<PhysicalCountLine> Lines { get; set; } = [];
    }
}