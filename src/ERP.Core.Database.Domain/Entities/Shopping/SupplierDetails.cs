using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Shopping
{
    /// <summary>
    /// Detalles generales del proveedor.
    /// </summary>
    public class SupplierDetails : BaseEntity<Guid>
    {
        public string? Address { get; set; }
        public string? EmailSupport { get; set; }

        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhoneNumber { get; set; }

        public bool IsExclusive { get; set; }
        public string?  ExclusiveBrandsOrParts { get; set; }

        public int CreditDays { get; set; }
        public bool HasCredit { get; set; }
        
        public decimal? CreditLimit { get; set; }
        public Currency? CreditCurrency { get; set; }
        public int AlertDaysBeforeDue { get; set; }
        public PaymentMethodType PreferredPaymentMethod { get; set; }
        public bool ApplyIrRetention { get; set; }
        public bool ApplyMunicipalRetention { get; set; }
        public bool IsTaxExempt { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = default!;
    } 
}