using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class DucatRegistry : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }
    public string Empresa { get; set; } = null!; //naviera
    public string? GeneralObservations { get; set; }
    public bool IsInTransit { get; set; }

    public string? UpdatedByUserId { get; set; }
    public string? UpdatedByUserName { get; set; }
    public DateOnly? UpdatedDate { get; set; }
    public TimeOnly? UpdatedTime { get; set; }

    public string? RegisteredByUserId { get; set; }
    public string? RegisteredByUserName { get; set; }
    public DateOnly? RegisteredStartDate { get; set; }
    public DateOnly? RegisteredEndDate { get; set; }
    public TimeOnly? RegisteredStartTime { get; set; }
    public TimeOnly? RegisteredEndTime { get; set; }

    public DucaStatus Status { get; set; }



    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
    public virtual ICollection<DucatRegistryDetails> Details { get; set; } = [];
}