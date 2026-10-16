

// Enum SanctionType: VerbalWarning = 1,  WrittenWarning = 2, Memorandum = 3, Suspension = 4, Termination = 5.
// Tipo:                                  WrittenWarning, Suspension, CommitmentLetter, ContractTermination.

namespace ERP.Core.Database.Domain.Enums
{
   public enum SanctionStatus
   {
      Applied = 1, // Sanción Aplicada
      Cancelled = 2 // Sanción Cancelada   
   }
}