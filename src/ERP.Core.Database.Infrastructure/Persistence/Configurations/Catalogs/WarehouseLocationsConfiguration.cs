using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class WarehouseLocationsConfiguration : IEntityTypeConfiguration<WarehouseLocation>
    {
        public void Configure(EntityTypeBuilder<WarehouseLocation> builder)
        {
            builder.ToTable("warehouse_locations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("location_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.LocationName)
                .HasColumnName("location_name")
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();            

            builder.Property(e => e.WarehouseId)
                .HasColumnName("warehouse_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");     

            builder.HasOne(c => c.Warehouse)
                .WithOne(s => s.WarehouseLocation)
                .HasForeignKey<WarehouseLocation>(s => s.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.Id)
                .HasDatabaseName("ix_location_id");
        }
    }
}