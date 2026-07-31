using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Entities.Shopping;

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

        public virtual ICollection<User> Users { get; set; } = [];
        public virtual ICollection<CostCenter> CostCenters { get; set; } = [];
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = [];
        public virtual ICollection<WorkingInformation> WorkingInformations { get; set; } = [];
    }
}
