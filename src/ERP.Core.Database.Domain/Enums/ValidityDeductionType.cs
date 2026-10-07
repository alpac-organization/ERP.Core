namespace ERP.Core.Database.Domain.Enums
{
    public enum TaxType
    {
        Inss = 1,
        InssPatronal = 2,
        ExchangeRate = 3,
        Inatec = 4,
        InssPatronal2 = 5,
        Iva = 6, // Impuesto al valor agregado para suppliers en modulo de compras 
        Imi = 7, // Impuesto municipal para suppliers en modulo de compras 
        Ir = 8, // Impuesto sobre la renta para suppliers en modulo de compras  
        IrSupplierInternation = 9, // Impuesto sobre la renta para suppliers internacionales en modulo de compras 
    }
}