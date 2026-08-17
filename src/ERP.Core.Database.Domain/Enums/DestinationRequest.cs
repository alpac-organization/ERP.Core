namespace ERP.Core.Database.Domain.Enums
{
    public enum DestinationRequest
    {
        Internal = 0,      // Uso interno de la empresa
        Client = 1,        // Para un cliente específico
        ServiceOrder = 2   // Asociado a una orden de servicio
    }
}