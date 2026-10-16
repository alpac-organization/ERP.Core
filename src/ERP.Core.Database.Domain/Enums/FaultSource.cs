namespace ERP.Core.Database.Domain.Enums
{
   public enum FaultSource
   {
      Manual = 1, // Si la falta la registra el jefe inmediato de manera manual
      SystemEscalation = 2 // Si se registra por regla y reincidencia (3 faltas leves = 1 falta grave, 3 faltas graves = 1 falta muy grave)
   }
}