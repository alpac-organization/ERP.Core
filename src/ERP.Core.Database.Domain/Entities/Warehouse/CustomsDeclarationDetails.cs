using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class CustomsDeclarationDetails : BaseEntity<Guid>
{
    public int Packages { get; set; }
    public string Customer { get; set; } = null!;
    public string Product { get; set; } = null!;
    public string ContainerNumber { get; set; } = null!;
    public Guid CustomsDeclarationId { get; set; }
    public virtual CustomsDeclarations CustomsDeclarations { get; set; } = null!;

}