namespace ERP.Core.Database.Domain.Enums
{
    
    public enum ChristmasBonusAccrualStatus
    {
        Projected = 1, //movimiento que contiene días futuros porque RR. HH cerró anticipadamente la nómina.
        Confirmed = 2, //movimiento que ya representa información confirmada.
        Superseded = 3, // estado que existia un calculo pero luego fue recalculado el aguinaldo.
        Cancelled = 4 // movimiento fue anulado.
    }
}   