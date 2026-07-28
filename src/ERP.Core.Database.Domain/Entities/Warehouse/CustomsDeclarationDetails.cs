using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class CustomsDeclarationDetails : BaseEntity<Guid>
{
    public int Packages { get; set; }
    public string Custmer { get; set; } = null!;
    public string Product { get; set; } = null!;

}