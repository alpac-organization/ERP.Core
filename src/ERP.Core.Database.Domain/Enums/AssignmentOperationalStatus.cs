namespace ERP.Core.Database.Domain.Enums
{
    public enum AssignmentOperationalStatus
    {
        None = 0,           // sin estado (proceso de asignamiento en vivo)
        Pending = 1,        // pendiente de descargar
        InProgress = 2,     // proceso de descarga en curso
        OnHold = 3,         // pausa de descarga
        Downloaded = 4      // descargado
    }
}
