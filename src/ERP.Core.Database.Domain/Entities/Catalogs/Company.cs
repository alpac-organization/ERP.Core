using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class Company : BaseEntity<Guid>
    {
        public string? Ruc { get; set; }
        public string? Code { get; set; }
        public bool IsActive { get; set; }
        public string? Alias { get; set; }
        public string? CompanieName { get; set; }

        public string? ImageUrl { get; set; }
        public string? NeutralImageUrl { get; set; }


        //Catalogos de las politicas de las empresas
        public virtual ICollection<Catalog> Catalogs { get; set; } = [];

        //Validamos todas sus sucursales
        public virtual ICollection<Branch> Branches { get; set; } = [];
        
        //Validamos sus areas de trabajo
        public virtual ICollection<WorkArea> WorkAreas { get; set; } = [];

        //Cargos de trabajo
        public virtual ICollection<JobPosition> JobPositions { get; set; } = [];

        //Validamos todos sus colaboradores
        public virtual ICollection<Collaborator> Collaborators { get; set; } = [];

        //Control de ubicación de guardas de seguridad
        public virtual ICollection<Location> Locations { get; set; } = [];

        //Clientes Propios de la empresa.
        public virtual ICollection<Customer> Customers { get; set; } = [];

        //Control de nominas contables o descriptions
        public virtual ICollection<TypesAccountingPayroll> TypesAccountingPayroll { get; set; } = [];
    }
}
