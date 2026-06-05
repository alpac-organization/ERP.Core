using ERP.Core.Database.Domain.Entities.Bases;

//Entidad de cargos de la empresa.
namespace ERP.Core.Database.Domain.Entities.Catalogs
{

    /// <summary>
    /// Los cargos estan asociados a una sola compañia.
    /// </summary>
    public class JobPosition : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? JobPositionName { get; set; }
        
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;
    }
}