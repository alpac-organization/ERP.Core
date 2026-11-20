using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class PersonnelActionRequestItemConfiguration : IEntityTypeConfiguration<PersonnelActionRequestItem>
    {
        public void Configure(EntityTypeBuilder<PersonnelActionRequestItem> builder)
        {
            builder.ToTable("personnel_action_request_items");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("personnel_action_request_item_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.PersonnelActionRequestId)
                .HasColumnName("personnel_action_request_id")
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.SalaryId)
                .HasColumnName("salary_id");

            builder.Property(e => e.WorkPositionHistoryId)
                .HasColumnName("work_position_history_id");

            builder.Property(e => e.MemorandumUrl)
                .HasColumnName("memorandum_url");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.PersonnelActionRequest)
                .WithMany(r => r.Items)
                .HasForeignKey(e => e.PersonnelActionRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Collaborator)
                .WithMany(c => c.PersonnelActionRequestItems)
                .HasForeignKey(e => e.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Salary)
                .WithMany()
                .HasForeignKey(e => e.SalaryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.WorkPositionHistory)
                .WithMany()
                .HasForeignKey(e => e.WorkPositionHistoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
