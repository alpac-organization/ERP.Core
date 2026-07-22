using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    public class Supplier : BaseEntity<Guid>
    {
        public bool IsActive { get; set; } = true;
        public string RegisterBy { get; set; } = null!;
        public string SuppliersLegalName { get; set; } = null!;
        public string? IdentificationNumber { get; set; }
        public IdentificationType? IdentificationType { get; set; }

        public ConstitutionType ConstitutionType { get; set; }

        public string? Address { get; set; }
        public string? EmailSupport { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhoneNumber { get; set; }

        public virtual ICollection<QuoteDetail> QuoteDetails {get; set;} = [];
    } 
}