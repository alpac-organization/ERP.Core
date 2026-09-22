using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Operations
{

    /// <summary>
    /// Entidad clientes de la empresa.
    /// </summary>
    public class Customers: BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public string? LegalName { get; set; }
        public string? CustomerCode { get; set; }
        public string? Cif { get; set; }
        public string? IdentificationNumber { get; set; }

        public CustomerType CustomerType { get; set; }
        public IdentificationType IdentificationType { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        //Operaciones activas.
        public virtual ICollection<OperationalOrder> OperationalOrders { get; set; } = [];

        //Sucursales del cliente.
        public virtual ICollection<CustomerBranch> CustomerBranches { get; set; } = [];
    }
}