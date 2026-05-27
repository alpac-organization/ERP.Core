using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class CostCentersConfiguration : IEntityTypeConfiguration<CostCenter>
    {
        public void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            builder.ToTable("cost_centers");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("cost_center_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.CostCenterName)
                .HasColumnName("cost_center_name")
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(150);

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasMany(c => c.JobPositions)
                .WithOne(m => m.CostCenter)
                .HasForeignKey(m => m.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            #region Indices de la tabla
            
            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("IX_cost_center_id");

            builder.HasIndex(e => e.WorkAreaId)
                .IsUnique()
                .HasDatabaseName("IX_cc_work_area_id");
                
            #endregion
        }
    }
}