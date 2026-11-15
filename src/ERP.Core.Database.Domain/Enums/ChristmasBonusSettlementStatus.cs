namespace ERP.Core.Database.Domain.Enums
{
    //este enum de aqui para representar el  cálculo definitivo, no la acumulación mensual del aguinaldo. 
    public enum ChristmasBonusSettlementStatus
    {
        Calculated = 1, // la fase inicial de estar en estado calculado
        Paid = 2,
        Superseded = 3, // estado de por si fue recalculado el calculo
        Cancelled = 4,
    }
}