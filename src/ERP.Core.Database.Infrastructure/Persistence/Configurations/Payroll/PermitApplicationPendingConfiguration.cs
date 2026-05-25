using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class PermitApplicationPendingConfiguration : IEntityTypeConfiguration<PermitApplicationPending>
    {
        public void Configure(EntityTypeBuilder<PermitApplicationPending> builder)
        {
            builder.ToTable("permit_applications_pending");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("permit_application_pending_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("ix_permit_application_pending_id");

            builder.Property(e => e.Type)
                .HasColumnName("permit_application_type")
                .HasColumnType("permit_application_type_enum")
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.StartTime)
                .HasColumnName("start_time")
                .IsRequired(false);

            builder.Property(e => e.EndTime)
                .HasColumnName("end_time")
                .IsRequired(false);
    
            builder.Property(e => e.AdditionalData)
                .HasColumnName("additional_data")
                .HasColumnType("jsonb");
            
            builder.Property(e => e.RequestedBy)
                .HasColumnName("requested_by")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description");


            builder.Property(e => e.StartDate)
                .HasColumnName("start_date")
                .IsRequired();

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");         

            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.PermitApplicationsPending)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}