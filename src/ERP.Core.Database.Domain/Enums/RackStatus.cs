namespace ERP.Core.Database.Domain.Enums;

public enum RackStatus
{
    // listo y libre para asignar mercaderia
    Available = 1,

    // Tiene mercaderia asignada actualmente
    Occupied = 2,

    /// Fuera de servicio por mantenimiento o reparacion estructural
    UnderMaintenance = 3,

    /// Inhabilitado por otra causa
    Blocked = 4
}