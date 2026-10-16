namespace ERP.Core.Database.Domain.Enums
{
   public enum SanctionType
   {
      VerbalWarning = 1, // Amonestación Verbal
      Memorandum = 2, // Amonestación por Escrito con Copias al Expediente
      Suspension = 3, // Suspensión de Trabajo Sin Goce de Salario (Dependencia de la gravedad de la Falta)
      CommitmentLetter = 4, // Carta de Compromiso por parte del Colaborador
      Termination = 5 // Cancelacion del Contrato de trabajo en conformidad con el codigo del trabajo
   }
}