namespace ERP.Core.Database.Domain.Enums
{
    /// <summary>
    /// Representa el estado de credito de un cliente.
    /// </summary>
    public enum CreditStatus
    {
        Active = 1,

        Blocked = 2,

        Suspended = 3,

        Overdue = 4
    }
}