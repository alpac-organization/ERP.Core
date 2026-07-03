namespace ERP.Core.Database.Domain.Enums
{
    public enum DeductionType
    {
        Loans = 1, // Prestamos
        AdvanceChristmasBonus = 2, //Adelanto de aguinaldo
        LateArrivals = 3, // Llegadas tardes
        SalaryAdvance = 4, // Adelato de salario
        Sanction = 5, //Sanciones
        Purisima = 6, //Celebración de la purisima
        OtherDeductions = 7,  //Otras deducciones,
        JudicialSeizures = 8, //embargo judicial
        ChildSupportGarnishment = 9 //embargo alimenticio
    }
}