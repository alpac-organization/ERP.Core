using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class CostCenter : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Description { get; set; } 
        public string? CostCenterName { get; set; }

        public virtual ICollection<JobPosition> JobPositions { get; set; } = [];
    }
}