using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ServiceOrdersConfiguration : IEntityTypeConfiguration<ServiceOrders>
{
    public void Configure(EntityTypeBuilder<ServiceOrders> builder)
    {
        builder.ToTable("service_orders");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("os_id")
            .HasDefaultValue("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasIndex(e => e.Id)
            .IsUnique()
            .HasDatabaseName("ix_service_orders_id)");
        
        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();
        
        builder.Property(e => e.Observations)
            .HasColumnName("observations")
            .HasMaxLength(500);

        builder.Property(e => e.BranchId)
            .HasColumnName("branch_id")
            .IsRequired();
        
        builder.Property(e => e.CustomerId)
            .HasColumnName("customer_id")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("create_at")
            .HasDefaultValueSql("CurrentDbContext_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasIndex(e => e.Code)
            .IsUnique()
            .HasDatabaseName("ix_os_code");
        
        builder.HasOne(e => e.Branch)
            .WithMany()
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(e => e.Customer)
            .WithMany()
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}