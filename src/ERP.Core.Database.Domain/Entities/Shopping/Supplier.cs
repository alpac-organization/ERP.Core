using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    /// <summary>
    /// Entidad de proveedores.
    /// </summary>
    public class Supplier : BaseEntity<Guid>
    {
        public bool IsActive { get; set; } = true;
        
        public string? ImageUrl { get; set; }
        public string? SuppliersLegalName { get; set; }

        public string? IdentificationNumber { get; set; }
        public ConstitutionType ConstitutionType { get; set; }
        public IdentificationType IdentificationType { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = default!;

        public virtual SupplierDetails SupplierDetails { get; set; } = default!;

        public virtual ICollection<Quotation> Quotations { get; set; } = [];
    } 
}