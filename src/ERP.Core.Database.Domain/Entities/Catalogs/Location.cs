using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class Location : BaseEntity<Guid>
    {
        public bool IsActive { get; set; } = true;
        public string? LocationName { get; set; } //Almacenadora del pacifico managua, corinto

        public Guid CompanyId { get; set;  }
        public virtual Company Company { get; set; } = default!;

        public virtual ICollection<Warehouses> Warehouses { get; set; } = [];
    }
}