
// Enum SanctionStatus: Applied = 1, Cancelled = 2, Pending = 3.

namespace ERP.Core.Database.Domain.Enums
{
   public enum SanctionStatus
   {
      Applied = 1, // Sanción aplicada (aprobada por RRHH)
      Cancelled = 2, // Sanción cancelada / rechazada
      Pending = 3 // Sanción propuesta, pendiente de aprobación de RRHH
   }
}
