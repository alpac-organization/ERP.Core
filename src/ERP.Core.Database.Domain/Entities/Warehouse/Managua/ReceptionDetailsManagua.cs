namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class ReceptionDetailsManagua
{
    public Guid RecordEntranceManaguaId { get; set; }
    public virtual RecordEntranceManagua RecordEntrance { get; set; } = null!;

    public string CountryOfOrigin { get; set; } = null!;
    public string Aduana { get; set; } = null!;
    public DateTime EntryDateTime { get; set; } = DateTime.UtcNow;
    public string PlateNumber { get; set; } = null!;
    public string TrailerChassis { get; set; } = null!;
    public string DriverLicense { get; set; } = null!;
    public string Transportista { get; set; } = null!;
    public string Medio { get; set; } = null!;
    public string DriverName { get; set; } = null!;
    public string Consignee { get; set; } = null!;
    public string SealNumber { get; set; } = null!;
}