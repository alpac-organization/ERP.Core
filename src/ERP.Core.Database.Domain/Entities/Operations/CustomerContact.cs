using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Operations
{
    /// <summary>
    /// Contacto de una sucursal de cliente.
    /// </summary>
    public class CustomerContacts : BaseEntity<Guid>
    {
        public string? ContactName { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }

        public Guid BranchId { get; set; }
        public virtual CustomerBranch Branch { get; set; } = default!;
    }
}