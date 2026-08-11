namespace ERP.Core.Database.Domain.Enums;

public enum RackUsageProfile
{
    ///Racks de flujo activo: mercaderia con movimiento constante (entra y sale)
    ActiveFlow = 1,

    /// Racks de flujo estatico: carga en espera, sin rotacion regular
    /// ej: mercaderia en abandono, etc.
    StaticHold = 2
}