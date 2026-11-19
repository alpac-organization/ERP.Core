namespace ERP.Core.Database.Domain.Enums
{
    //Aqui se esta definiendo los posibles estados de un período anual de aguinaldo.
    public enum ChristmasBonusPeriodStatus
    {
        Active = 1, //período está actualmente acumulando aguinaldo.
        Completed = 2, //período terminó, pero todavía podría estar pendiente de el pago completo.
        Settled = 3 //período ya fue liquidado.
    }
}