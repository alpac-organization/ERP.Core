using System.Text.Json.Nodes;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class ReceptionEntrance : BaseEntity<Guid>
{
    // Informacion de transporte
    public string VehiclePlateNumber { get; set; } = null!;
    public string VehicleChassisNumber { get; set; } = null!;
    public string DriverLicense { get; set; } = null!;
    public string Transportista { get; set; } = null!;
    public string DriverName { get; set; } = null!;
    public TransportUnit TransportUnit { get; set; }

    public DateOnly? VehicleExitDate { get; set; }
    public TimeOnly? VehicleExitTime { get; set; }

    public DateOnly? ContainerExitDate { get; set; }
    public TimeOnly? ContainerExitTime { get; set; }

    public JsonNode? AdditionalData { get; set; }



    // informacion de OP
    public DocumentType DocumentType { get; set; }
    public string SealNumber { get; set; } = null!;  // marchamo | precinto
    public string ContainerNumber { get; set; } = null!;
    public string CountryOfOrigin { get; set; } = null!;
    public Guid CustomBranchId { get; set; }  //aduana 
    public virtual CustomsBranches CustomsBranches { get; set; } = null!;

    public virtual ICollection<OperationalOrder> OperationalOrders { get; set; } = [];
}