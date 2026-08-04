using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class Branch : BaseEntity<Guid>
    {
        public string? BranchCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BranchName { get; set; }
        public string? CompanyAlias { get; set; }
        public string? BranchAddress { get; set; }

        public bool IsActive { get; set; } = true;
        public bool HasWarehouse { get; set; } = false;

        public bool DoesGenerateSeniority { get; set; } = false;

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;

        //Seccionamientos de nominas.
        public virtual ICollection<User> Users { get; set; } = [];

        public virtual ICollection<Quotation> Quotes {get; set;} = [];
        public virtual ICollection<Payroll> Payrolls { get; set; } = [];
        public virtual ICollection<Warehouses> Warehouses {get; set;} = [];
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = [];
    }
}