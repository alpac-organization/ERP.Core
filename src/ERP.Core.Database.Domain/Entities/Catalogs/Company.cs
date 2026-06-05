using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;

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
    }
}
