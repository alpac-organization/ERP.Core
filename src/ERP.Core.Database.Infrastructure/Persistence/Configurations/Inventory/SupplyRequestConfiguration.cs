using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class SupplyRequestConfiguration : IEntityTypeConfiguration<SupplyRequest>
    {
        public void Configure(EntityTypeBuilder<SupplyRequest> builder)
        {
            builder.ToTable("supply_requests");

            builder.Property(e => e.OperationalOrderId)
                .HasColumnName("operational_order_id")
                .IsRequired(false);

            #region Foreign Keys

            builder.HasOne(e => e.OperationalOrder)
                .WithMany(e => e.SupplyRequests)
                .HasForeignKey(e => e.OperationalOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.SupplyRequest)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Indexes

            builder.HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("ux_supply_requests_code")
                .HasFilter("\"deleted_at\" IS NULL");

            #endregion
        }
    }
}