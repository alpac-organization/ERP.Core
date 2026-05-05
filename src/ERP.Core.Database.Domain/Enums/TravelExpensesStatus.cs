namespace ERP.Core.Database.Domain.Enums
{
    public enum TravelExpensesStatus
    {
        /// <summary>
        /// El proceso está actualmente activo o en desarrollo.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// El periodo ha sido cerrado y no se admiten más cambios.
        /// </summary>
        PeriodEnded = 2
    }
}