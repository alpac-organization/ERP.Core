namespace ERP.Core.Database.Domain.Enums
{
  public enum PaymentMethodType
    {
        ACH = 1,                 // Transferencia interbancaria ACH
        LocalTransfer = 2,       // Transferencia mismo banco
        Check = 3,               // Cheque
        Cash = 4,                // Efectivo
        InternationalWire = 5    // Transferencia Internacional
    }
}