using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class Warehouse : IEntityTypeConfiguration<Warehouses>
{
    public void Configure(EntityTypeBuilder<Warehouses> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.CreatedAt)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(w => w.DeletedAt)
            .IsRequired(false);

        builder.Property(w => w.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(w => w.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.TotalCubicCapacity)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.TotalWeightCapacity)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasIndex(w => w.Code)
            .HasFilter("[IsActive] = 1 AND [DeletedAt] IS NULL")
            .IsUnique();

        builder.HasQueryFilter(w => w.IsActive && w.DeletedAt == null);

        builder.HasOne(w => w.Branch)
            .WithMany()
            .HasForeignKey(w => w.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.CustomerType)
            .WithMany()
            .HasForeignKey(w => w.AllowedCustomerTypeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}