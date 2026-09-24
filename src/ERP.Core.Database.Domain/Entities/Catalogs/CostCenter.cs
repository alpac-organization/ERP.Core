using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Entities.Shopping;

//Centros de costos de las areas de trabajo
namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class CostCenter : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Description { get; set; } 
        public string? CostCenterName { get; set; }

        public int CoilCode { get; set; }
        public string CostCenterCode { get; set; } = null!;

        public Guid WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;
        
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = [];
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = [];
        public virtual ICollection<WorkingInformation> WorkingInformations { get; set; } = [];
    }
}