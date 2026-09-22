using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    /// <summary>
    /// Sucursal de un cliente de la empresa.
    /// </summary>
    public class CustomerBranch : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public bool IsMainBranch { get; set; }

        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Contact { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customers Customer { get; set; } = default!;

        //Informacion crediticia de la sucursal.
        public virtual ICollection<CustomerCreditInformation> CreditInformation { get; set; } = [];
    }
}