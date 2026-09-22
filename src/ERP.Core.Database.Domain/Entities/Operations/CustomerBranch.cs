using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    /// <summary>
    /// Sucursal de un cliente de la empresa.
    /// </summary>
    public class CustomerBranch : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public string? BranchName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customers Customer { get; set; } = default!;

        public Guid OperationalServiceId { get; set; }
        public virtual OperationalService OperationalService { get; set; } = default!;

        //Contactos de la sucursal.
        public virtual ICollection<CustomerContacts> Contacts { get; set; } = [];

        //Informacion crediticia de la sucursal.
        public virtual ICollection<CustomerCreditInformation> CreditInformation { get; set; } = [];
    }
}