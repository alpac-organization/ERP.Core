namespace ERP.Core.Database.Domain.Enums
{
    public enum PayrollType
    {
        None = 0,
        Ordinary = 1,
        Provided = 2,
        ProfessionalServices = 3,
        ChristmasBonus = 4 // separando responsabilidad pago de nomina de pago aguinaldo
    }
}