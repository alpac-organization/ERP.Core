using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class WorkAreasConfiguration : IEntityTypeConfiguration<WorkArea>
    {
        public void Configure(EntityTypeBuilder<WorkArea> builder)
        {
            builder.ToTable("work_areas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("work_area_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();
                
            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .HasMaxLength(100);

            builder.Property(e => e.WorkAreaName)
                .HasColumnName("work_area_name")
                .HasMaxLength(100);

            builder.Property(e => e.WorkAreaCode)
                .HasColumnName("work_area_code")
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

            builder.HasOne(c => c.Company)
                .WithMany(m => m.WorkAreas)
                .HasForeignKey(m => m.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.CostCenters)
                .WithOne(m => m.WorkArea)
                .HasForeignKey(m => m.WorkAreaId)
                .OnDelete(DeleteBehavior.Restrict);

            #region Indices de la tabla
            
            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("IX_work_area_id");
            
            #endregion
        }
    }
}