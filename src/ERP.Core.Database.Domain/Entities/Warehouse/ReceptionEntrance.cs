using ERP.Core.Database.Domain.Entities.Bases;

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
    public string Medio { get; set; } = null!;
    public string DriverName { get; set; } = null!;
    public string SealNumber { get; set; } = null!;

    public DateOnly? MedioExitDate {get;set;}
    public TimeOnly? MedioExitTime {get;set;}

    public string? UpdatedByUserId { get; set; }
    public string? UpdatedByUserName { get; set; }
    public DateOnly? UpdatedDate { get; set; }
    public TimeOnly? UpdatedTime { get; set; }

    public virtual RecordEntrance RecordEntrance { get; set; } = null!;
}