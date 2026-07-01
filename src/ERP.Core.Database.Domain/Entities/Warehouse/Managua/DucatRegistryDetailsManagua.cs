using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class DucatRegistryDetailsManagua : BaseEntity<Guid>
{
    public Guid RecordEntranceManaguaId { get; set; }
    public virtual DucatRegistryManagua DucatRegistry { get; set; } = null!;

    public string DucatNumber { get; set; } = null!;
    public int PackageCount { get; set; }
    public decimal TotalWeight { get; set; }
    public string ProductDescription { get; set; } = null!;
    public string SenderName { get; set; } = null!; 
    public string DestinationAreaObservation { get; set; } = null!; 
}