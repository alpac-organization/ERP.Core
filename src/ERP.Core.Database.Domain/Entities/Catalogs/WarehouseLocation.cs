using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{   
    /// <summary>
    /// Esta entidad es para indicar punto de ubicación de las bodegas, mapas, departamento de ubicación etc
    /// </summary>
    public class WarehouseLocation : BaseEntity<Guid>
    {
        public bool IsActive { get; set; } = true;
        public string? LocationName { get; set; } //Almacenadora del pacifico managua, corinto
        
        /// More properties of locations, Departament, Lat, Log ... etc.

        public Guid CompanyId { get; set;  }
        public virtual Company Company { get; set; } = default!;

        public Guid WarehouseId { get; set; }
        public virtual Warehouses Warehouse { get; set; } = default!;
    }
}