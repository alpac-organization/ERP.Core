using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse
{
    public class Customer : BaseEntity<Guid>
    {
        public string? Cif { get; set;}

        public string? LegalName {get; set;}
        public string? PictureUrl { get; set; }

        public bool IsActive {get; set;} = true;

        public string? IdentificationNumber {get; set;}
        public IdentificationType IdentificationType { get; set; }

        public Guid CustomerTypeId {get; set;}
        public virtual CustomerType CustomerType {get; set;} = default!;

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public virtual ICollection<Products> Products { get; set; } = [];
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = [];
    }
}