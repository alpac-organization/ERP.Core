using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
   public class PermitTypePolicy : BaseEntity<Guid>
   {
      public PermitApplicationType PermitApplicationType {get; set;}

      public PermitBeneficiaryScope BeneficiaryScope {get; set;} = PermitBeneficiaryScope.None;

      public FamilyRelationship  FamilyRelationship {get; set;} = FamilyRelationship.None; 


      public bool ConsumesVacationBalance {get; set;}

      public Guid CompanyId {get; set;}

      public virtual Company Company {get; set;} = null!; 

      public bool RequiresEvidence {get; set;}

      public int MaxEvidenceCount {get; set;}

      public int MinEvidenceCount {get; set;} 

      public int RequiredApprovalSteps {get; set;}

      public decimal? MaxAmountDays {get; set;}

      public bool IsActive {get; set;}
   }
}