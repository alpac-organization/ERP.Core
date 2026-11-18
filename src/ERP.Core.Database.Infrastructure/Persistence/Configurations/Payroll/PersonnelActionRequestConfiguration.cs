using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class PersonnelActionRequestConfiguration : IEntityTypeConfiguration<PersonnelActionRequest>
    {
        public void Configure(EntityTypeBuilder<PersonnelActionRequest> builder)
        {
            builder.ToTable("personnel_action_requests");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("personnel_action_request_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.RequestCode)
                .HasColumnName("request_code")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(e => e.RequestCode)
                .IsUnique();

            builder.Property(e => e.Scope)
                .HasColumnName("scope")
                .HasColumnType("personnel_action_scope_enum")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("personnel_action_status_enum")
                .IsRequired();

            builder.Property(e => e.EffectiveDate)
                .HasColumnName("effective_date")
                .IsRequired();

            builder.Property(e => e.Justification)
                .HasColumnName("justification")
                .IsRequired();

            builder.Property(e => e.AttachmentUrl)
                .HasColumnName("attachment_url");

            builder.Property(e => e.RequestedByUserId)
                .HasColumnName("requested_by_user_id")
                .IsRequired();

            builder.Property(e => e.RequestedAt)
                .HasColumnName("requested_at")
                .IsRequired();

            builder.Property(e => e.ReviewedByManagementUserId)
                .HasColumnName("reviewed_by_management_user_id");

            builder.Property(e => e.ReviewedByManagementAt)
                .HasColumnName("reviewed_by_management_at");

            builder.Property(e => e.ManagementNotes)
                .HasColumnName("management_notes");

            builder.Property(e => e.AppliedByUserId)
                .HasColumnName("applied_by_user_id");

            builder.Property(e => e.AppliedAt)
                .HasColumnName("applied_at");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasMany(e => e.Items)
                .WithOne(i => i.PersonnelActionRequest)
                .HasForeignKey(i => i.PersonnelActionRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
