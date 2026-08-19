using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class ReceptionEntrance : BaseEntity<Guid>
{
    public Guid RecordEntranceId { get; set; }

    public string CountryOfOrigin { get; set; } = null!;

    public Guid CustomBranchId { get; set; }
    public virtual CustomsBranches CustomsBranches { get; set; } = null!;
    
    public string VehiclePlateNumber { get; set; } = null!;
    public string VehicleChassisNumber { get; set; } = null!;
    public string ContainerNumber { get; set; } = null!;
    public string DriverLicense { get; set; } = null!;
    public string Transportista { get; set; } = null!;
    public string DriverName { get; set; } = null!;
    public string SealNumber { get; set; } = null!;


    [Column(TypeName = "text[]")]
    public List<string>? EvidenceUrls { get; set; } = [];

    [Column(TypeName = "text[]")]
    public List<string>? DeletedEvidenceUrls { get; set; } = [];


    public DocumentType DocumentType { get; set; }

    public TransportUnit TransportUnit { get; set; }

    public DateOnly? VehicleExitDate { get; set; }
    public TimeOnly? VehicleExitTime { get; set; }

    public DateOnly? ContainerExitDate { get; set; }
    public TimeOnly? ContainerExitTime { get; set; }

    public string? UpdatedByUserId { get; set; }
    public string? UpdatedByUserName { get; set; }
    public DateOnly? UpdatedDate { get; set; }
    public TimeOnly? UpdatedTime { get; set; }

    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
}