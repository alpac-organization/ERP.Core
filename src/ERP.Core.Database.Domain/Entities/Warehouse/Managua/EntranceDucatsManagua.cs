using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class EntranceDucatsManagua : BaseEntity<Guid>
{
    public Guid RecordEntranceManaguaId { get; set; }
    public string DucatNumber { get; set; } = null!;

    public virtual RecordEntranceManagua RecordEntrance { get; set; } = null!;
    public virtual DucatRegistryDetailsManagua? RegistryDetail {get; set;}
}