namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class DucatRegistryManagua
{
    public Guid RecordEntranceManaguaId { get; set; }
    public virtual RecordEntranceManagua RecordEntrance { get; set; } = null!;

    public DateTime RegistryDate { get; set; }
    
    public DateTime EntryTime { get; set; }
    public string TrailerIdentifier { get; set; } = null!;
    public string Empresa { get; set; } = null!; 
    public string Transportista { get; set; } = null!;
    public string Aduana { get; set; } = null!;
    public string Consignee { get; set; } = null!;

    // Relación al detalle de los DUCATs desglosados
    public virtual ICollection<DucatRegistryDetailsManagua> Details { get; set; } = [];
}