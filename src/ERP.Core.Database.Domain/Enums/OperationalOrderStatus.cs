namespace ERP.Core.Database.Domain.Enums
{
    public enum OperationalOrderStatus
    {
        Completed = 1,          // documentacion completada
        PendingDocument = 2,    // pendiente de llenar los detalles
        Assignment = 3          // enviado a asignacion    
    }
}