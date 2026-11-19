namespace ERP.Core.Database.Domain.Enums
{
   public enum TerminationType
   {
      VoluntaryResignation = 1, // Renuncia Voluntaria
      MutualAgreement = 2, // Mutuo Acuerdo, cuando las dos partes (empresa y colaborador) aceptan terminar el contrato, ejemplo: "Damos por terminada la relacion laboral el 30 de noviembre..."
      JustifiedDismissal = 3, // Despido por causa justificada
      UnjustifiedDismissal = 4, // Despido sin causa justificada
      ContractExpiration = 5, // Vencimiento de contrato determinado
      WorkCompletion = 6, // Conclusion de obra o servicio (Hasta terminar un trabajo especifico, sin fecha determinada)
      EmployeeDeath = 7, // Fallecimiento de colaborador
      Retirement = 8, // Jubilación
   }
}