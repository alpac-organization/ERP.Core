namespace ERP.Core.Database.Domain.Enums
{
    // aqui el status del proceso de autorización como proveedor exclusivo.
    public enum SupplierExclusiveStatus
    {
        // No solicita .
        None = 0,

        // En cola de revisión para ser autorizado como exclusivo.
        PendingReview = 1,

        // Autorizado como proveedor exclusivo.
        Approved = 2,

        // Rechazado como proveedor exclusivo.
        Rejected = 3
    }
}
