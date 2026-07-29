using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Manager.Api.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class ReceptionEntrance : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }

    public string CountryOfOrigin { get; set; } = null!;
    public string Aduana { get; set; } = null!;
    public string PlateNumber { get; set; } = null!;
    public string TrailerChassis { get; set; } = null!;
    public string DriverLicense { get; set; } = null!;
    public string Transportista { get; set; } = null!;
    public string DriverName { get; set; } = null!;
    public string SealNumber { get; set; } = null!;

    public DocumentType DocumentType { get; set; }

    public Guid TransportUnitId { get; set; }
    public virtual TransportUnit TransportUnit { get; set; } = null!;

    public DateOnly? TransportUnitExitDate { get; set; }
    public TimeOnly? TransportUnitExitTime { get; set; }

    public string? UpdatedByUserId { get; set; }
    public string? UpdatedByUserName { get; set; }
    public DateOnly? UpdatedDate { get; set; }
    public TimeOnly? UpdatedTime { get; set; }

    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
}