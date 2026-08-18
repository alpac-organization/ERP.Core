using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class DucatRegistryDetails : BaseEntity<Guid>
{
    public Guid DucatRegistryId { get; set; }
    public Guid EntranceDucatId { get; set; }
    public Guid MerchandiseId { get; set; }
    public string MerchandiseName { get; set; } = null!;
    public DucaType Type { get; set; }
    public int TotalBultos { get; set; }
    public decimal TotalWeight { get; set; }
    public string? MerchandiseDescription { get; set; }
    public string Sender { get; set; } = null!;
    public string? DestinationAreaObservation { get; set; }
    public virtual DucatRegistry DucatRegistry { get; set; } = null!;
    public virtual EntranceDucats EntranceDucat { get; set; } = null!;
    public virtual Merchandises Merchandise { get; set; } = default!;


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
