using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class JobPositionsConfiguration : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> builder)
        {
            builder.ToTable("job_positions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("job_position_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.WorkAreaId)
                .HasColumnName("work_area_id")
                .IsRequired();

            builder.Property(e => e.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired();

            builder.Property(e => e.JobPositionName)
                .HasColumnName("job_position_name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired(false)
                .HasMaxLength(150);

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .IsRequired(false)
                .HasDefaultValue(null)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.CostCenter)
                .WithMany(m => m.JobPositions)
                .HasForeignKey(m => m.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.WorkArea)
                .WithMany(m => m.JobPositions)
                .HasForeignKey(m => m.WorkAreaId)
                .OnDelete(DeleteBehavior.Restrict);

            #region Indices de la tabla
            
            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("IX_job_position_id");

            #endregion
        }
    }
}