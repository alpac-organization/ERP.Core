namespace ERP.Core.Database.Domain.Enums
{
   public enum FaultStatus
   {
      Open = 1, // Pendiente a sanción
      SanctionApplied = 2, // Sanción aplicada
      Prescribed = 3, // Venció el mes sin sanción
      Cancelled = 4 // Cancelación de la falta (Anulación)
   }
}