namespace ERP.Core.Database.Domain.Enums
{
   public enum AbsenceStatus
   {
      Pending = 1,   // Registrada por el jefe inmediato, en bandeja de RRHH
      Applied = 2,   // Aplicada por RRHH (se descuenta en nómina y genera falta disciplinaria)
      Cancelled = 3  // Cancelada por RRHH (por negociación externa: permiso, vacación o corrección)
   }
}
