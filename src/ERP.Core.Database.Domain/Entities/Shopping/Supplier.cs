using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class Supplier : BaseEntity<Guid>
    {
        public bool IsActive { get; set; } = true;
        public string? ImageUrl { get; set; }
        public string? SuppliersLegalName { get; set; }
        public string? IdentificationNumber { get; set; }
        public IdentificationType? IdentificationType { get; set; }

        public string RegisterBy { get; set; } = null!;
        public ConstitutionType ConstitutionType { get; set; }

        public virtual SupplierDetails SupplierDetails { get; set; } = default!;

        public virtual ICollection<QuoteDetail> QuoteDetails {get; set;} = [];
    } 
}