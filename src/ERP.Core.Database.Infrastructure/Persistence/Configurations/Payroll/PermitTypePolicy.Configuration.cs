using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
   public class PermitTypePolicyConfiguration : IEntityTypeConfiguration<PermitTypePolicy>
   {
       public void Configure(EntityTypeBuilder<PermitTypePolicy> builder)
      {
         builder.ToTable("permission_type_policies", table =>
         {
            table.HasCheckConstraint("ck_permit_type_policies_steps",
                  "required_approval_steps IN (1, 2)");

            table.HasCheckConstraint("ck_permit_type_policies_evidence",
                    "min_evidence_count >= 0 AND max_evidence_count >= min_evidence_count");
         });

         builder.HasKey(e=> e.Id);

         builder.Property(e=>e.Id)
            .HasColumnName("perm_type_policy_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

         builder.HasIndex(e=>e.Id)
            .IsUnique()
            .HasDatabaseName("ix_permit_type_policy_id");

         builder.Property(e=>e.PermitApplicationType)
            .HasColumnName("permit_application_type")
            .HasColumnType("permit_application_type_enum")
            .IsRequired();         
         
         builder.Property(e=>e.BeneficiaryScope)
            .HasColumnName("beneficiary_scope")
            .HasColumnType("permit_beneficiary_scope_enum")
            .HasDefaultValueSql("'none'::permit_beneficiary_scope_enum")
            .IsRequired();

         builder.Property(e=>e.FamilyRelationship)
            .HasColumnName("family_relationship")
            .HasColumnType("family_relationship_enum")
            .HasDefaultValueSql("'none'::family_relationship_enum")
            .IsRequired();

         builder.Property(e=>e.IsPaid)
            .HasColumnName("is_paid");

         builder.Property(e=>e.ConsumesVacationBalance)
            .HasColumnName("consumes_vacation_balance");

         builder.Property(e=>e.RequiresEvidence)
            .HasColumnName("requires_evidence");

         builder.Property(e => e.RequiredApprovalSteps)
            .HasColumnName("required_approval_steps")
            .IsRequired(); 

         builder.Property(e => e.MinEvidenceCount)
            .HasColumnName("min_evidence_count")
            .HasDefaultValue(0) 
            .IsRequired();

         builder.Property(e=>e.MaxEvidenceCount)
            .HasColumnName("max_evidence_count")
            .HasDefaultValue(0)
            .IsRequired();

         builder.Property(e => e.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired(); 

         builder.Property(e=> e.MaxAmountDays)
            .HasColumnName("max_amount_days")
            .HasPrecision(18, 4);

         builder.HasIndex(e => new { e.PermitApplicationType, e.BeneficiaryScope, e.FamilyRelationship })
            .IsUnique()
            .HasFilter("deleted_at IS NULL")
            .HasDatabaseName("ux_permit_type_policies_rule");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

         

      }
   }
}