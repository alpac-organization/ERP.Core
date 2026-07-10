using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class EntranceDucatsManagua : BaseEntity<Guid>
{
    public string DucatNumber { get; set; } = null!;    
    
    public Guid RecordEntranceManaguaId { get; set; }
    public virtual RecordEntranceManagua RecordEntrance { get; set; } = null!;

    public virtual DiscrepanciesManagua? DiscrepancyManagua { get; set; }
    public virtual DucatRegistryDetailsManagua? RegistryDetail {get; set;}
}