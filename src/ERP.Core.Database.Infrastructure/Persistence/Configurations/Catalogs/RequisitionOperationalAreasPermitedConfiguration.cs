using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class RequisitionOperationalAreasPermitedConfiguration : IEntityTypeConfiguration<RequisitionOperationalAreasPermited>
    {
        public void Configure(EntityTypeBuilder<RequisitionOperationalAreasPermited> builder)
        {
            builder.ToTable("requisition_operational_areas_permitted");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("requisition_operational_area_permitted_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.AreaId)
                .HasColumnName("area_id")
                .IsRequired();

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            builder.Property(e => e.SetByUserId)
                .HasColumnName("set_by_user_id")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.AreaName)
                .HasColumnName("area_name")
                .HasMaxLength(150);

            builder.Property(e => e.CompanyName)
                .HasColumnName("company_name")
                .HasMaxLength(150);

            builder.Property(e => e.SetByUserName)
                .HasColumnName("set_by_user_name")
                .HasMaxLength(150);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Area)
                .WithOne(e => e.RequisitionPermited)
                .HasForeignKey<RequisitionOperationalAreasPermited>(e => e.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.SetByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
