using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Shopping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class RequestedProductsConfiguration : IEntityTypeConfiguration<RequestedProduct>
    {
        public void Configure(EntityTypeBuilder<RequestedProduct> builder)
        {
            builder.ToTable("requested_products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("requested_product_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(e => e.QuantityUnit)
                .HasColumnName("quantity_unit");

            builder.Property(e => e.UnitMeasureId)
                .HasColumnName("unit_measure_id")
                .IsRequired();

            builder.Property(e => e.Justification)
                .HasColumnName("justification")
                .IsRequired(false);

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.PurchaseRequestId)
                .HasColumnName("purchase_request_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            // Relaciones
            builder.HasOne(e => e.UnitMeasure)
                .WithMany(e => e.RequestedProducts)
                .HasForeignKey(e => e.UnitMeasureId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(e => e.Product)
                .WithMany(e => e.RequestedProducts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(e => e.PurchaseRequest)
                .WithMany(pr => pr.RequestdProducts)
                .HasForeignKey(e => e.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}