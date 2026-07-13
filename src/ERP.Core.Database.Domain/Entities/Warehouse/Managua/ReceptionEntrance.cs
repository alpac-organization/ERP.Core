using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class ReceptionEntrance : BaseEntity<Guid>
{
    public Guid RecordEntranceManaguaId { get; set; }
    
    public string CountryOfOrigin { get; set; } = null!;
    public string Aduana { get; set; } = null!;
    public DateTime GateEntranceTime { get; set; }
    public string PlateNumber { get; set; } = null!;
    public string TrailerChassis { get; set; } = null!;
    public string DriverLicense { get; set; } = null!;
    public string Transportista { get; set; } = null!;
    public string Medio { get; set; } = null!;
    public string DriverName { get; set; } = null!;
    public string Consignee { get; set; } = null!;
    public string SealNumber { get; set; } = null!;


    public virtual RecordEntranceManagua RecordEntrance { get; set; } = null!;
}