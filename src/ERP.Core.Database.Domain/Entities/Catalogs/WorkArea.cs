using ERP.Core.Database.Domain.Entities.Bases;

//Areas o departamentos de la empresa
namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class WorkArea : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public int WorkAreaCode { get; set; }
        public string? Description { get; set; }
        public string? WorkAreaName { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public virtual ICollection<CostCenter> CostCenters { get; set; } = [];
    }
}