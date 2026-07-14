using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class DucatRegistry : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }

    public DateTime RegistryDate { get; set; }
    public string TrailerIdentifier { get; set; } = null!;
    public string Empresa { get; set; } = null!; //naviera
    public string RegisteredByUserId { get; set; } = null!;
    public string? GeneralObservations { get; set; }
    public bool IsInTransit { get; set; }

    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
    public virtual ICollection<DucatRegistryDetails> Details { get; set; } = [];
}