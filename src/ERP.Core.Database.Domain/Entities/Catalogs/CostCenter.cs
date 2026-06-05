using ERP.Core.Database.Domain.Entities.Bases;

//Centros de costos de las areas de trabajo
namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class CostCenter : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Description { get; set; } 
        public string? CostCenterName { get; set; }

        public int CoilCode { get; set; }
        public int CostCenterCode { get; set; }

        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;
    }
}