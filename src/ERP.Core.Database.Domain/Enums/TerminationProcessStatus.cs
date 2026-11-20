

namespace ERP.Core.Database.Domain.Enums
{
   public enum TerminationProcessStatus
   {
      /// <summary>
      /// <list type="">
      /// <item>Se cargaron tipo, motivo, fechas y evidencias del egreso.</item>
      /// <item>El colaborador sigue activo; no queda <c>Terminated</c> por este expediente.</item>
      /// <item>Puede pasar a <see cref="Closed"/> (ejecutar) o a <see cref="Cancelled"/> (anular).</item>
      /// <item>No sirve aún como base para liquidación.</item>
      /// </list>
      /// </summary>
      Pending = 1, // Se registro la baja, pero, aun no se ejecutó el cierre operativo

      /// <summary>
      /// Trámite ejecutado: cierre operativo aplicado.
      /// <list type="bullet">
      /// <item><c>collaborators.status = Terminated</c> y <c>has_been_fired = true</c>.</item>
      /// <item><c>employment_periods.departure_date</c> = fecha del expediente.</item>
      /// <item>Se cierran salario/cargo vigentes y se cancelan permisos pendientes.</item>
      /// <item>Quedan <c>ClosedBy</c> / <c>ClosedAt</c>; el colaborador no se soft-deletea.</item>
      /// <item>El expediente queda listo para una liquidación posterior.</item>
      /// </list>
      /// </summary>
      Closed = 2, // El tramite ya se ejecutó

      /// <summary>
      /// Expediente anulado o desestimado antes de cerrar.
      /// <list type="bullet">
      /// <item>No se ejecuta la baja operativa.</item>
      /// <item>El colaborador no queda <c>Terminated</c> por este expediente.</item>
      /// <item>Debe registrarse <c>CancellationReason</c>.</item>
      /// <item>El registro se conserva como historial (no se borra en operaciones normales).</item>
      /// <item>No sirve para liquidación.</item>
      /// </list>
      /// </summary>
      Cancelled = 3, // El registro de la baja se anuló, no se ejecutó la baja (Se desestimó antes de cerrar)
   }
}