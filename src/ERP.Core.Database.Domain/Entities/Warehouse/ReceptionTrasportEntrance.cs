using System.Text.Json.Nodes;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class ReceptionTransportEntrance : BaseEntity<Guid>
{
    public string DriverName { get; set; } = null!;
    public string DriverLicense { get; set; } = null!;
    public string Transportista { get; set; } = null!;
    public string VehiclePlateNumber { get; set; } = null!;
    public string VehicleChassisNumber { get; set; } = null!;
    public TransportUnit TransportUnit { get; set; }
    
    public DateOnly? VehicleExitDate { get; set; }
    public TimeOnly? VehicleExitTime { get; set; }

    public DateOnly? ContainerExitDate { get; set; }
    public TimeOnly? ContainerExitTime { get; set; }

    public Guid ReceptionEntranceId { get; set; }
    public virtual ReceptionEntrance ReceptionEntrance { get; set; } = default!;
}