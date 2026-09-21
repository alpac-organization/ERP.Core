using ERP.Core.Database.Domain.Entities.Operations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class ServicesOrderConfiguration : IEntityTypeConfiguration<ServicesOrder>
    {
        public void Configure(EntityTypeBuilder<ServicesOrder> builder)
        {
            builder.ToTable("services_orders");

            builder.HasKey(so => so.Id);

            builder.Property(so => so.Id)
                .HasColumnName("services_order_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(so => so.ServiceOrderCode)
                .HasColumnName("service_order_code")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(so => so.OperationalServiceId)
                .HasColumnName("operational_service_id")
                .IsRequired();

            builder.Property(so => so.OperationalOrderId)
                .HasColumnName("operational_order_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(so => so.OperationalService)
                .WithMany(os => os.ServicesOrders)
                .HasForeignKey(so => so.OperationalServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(so => so.OperationalOrder)
                .WithMany(o => o.ServicesOrders)
                .HasForeignKey(so => so.OperationalOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(so => so.ServiceOrderCode)
                .HasDatabaseName("ix_services_orders_service_order_code")
                .IsUnique();

            builder.HasIndex(so => so.OperationalServiceId)
                .HasDatabaseName("ix_services_orders_operational_service_id");

            builder.HasIndex(so => so.OperationalOrderId)
                .HasDatabaseName("ix_services_orders_operational_order_id");
        }
    }
}
