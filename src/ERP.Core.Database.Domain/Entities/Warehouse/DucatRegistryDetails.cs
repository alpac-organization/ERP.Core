using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class DucatRegistryDetails : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }
    public Guid EntranceDucatId { get; set; }
    public Guid ProductId { get; set; }
    public int TotalBultos { get; set; }
    public decimal TotalWeight { get; set; }
    public string? ProductDescription { get; set; }
    public string Remitente { get; set; } = null!;
    public string? DestinationAreaObservation { get; set; }
    public virtual DucatRegistry DucatRegistry { get; set; } = null!;
    public virtual EntranceDucats EntranceDucat { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;


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

}
