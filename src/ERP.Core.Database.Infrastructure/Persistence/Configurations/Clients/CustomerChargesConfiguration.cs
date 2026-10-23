using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Clients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Clients;

public class CustomerChargesConfiguration : IEntityTypeConfiguration<CustomerCharges>
{
    public void Configure(EntityTypeBuilder<CustomerCharges> builder)
    {
        builder.ToTable("customer_charges");
        builder.HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id)
            .HasColumnName("customer_charges_id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(cc => cc.BranchId)
            .HasColumnName("branch_id")
            .IsRequired();

        // Espacio para los campos a revisar




        // Fin espacio para los campos a revisar

        builder.Property(cc => cc.MeasureUnitId)
            .HasColumnName("measure_unit_id")
            .IsRequired();

        builder.Property(cc => cc.Quantity)
            .HasColumnName("quantity")
            .HasPrecision(8, 2)
            .IsRequired();

        builder.Property(cc => cc.USDFeeAmount)
            .HasColumnName("usd_fee_amount")
            .HasPrecision(8, 2)
            .IsRequired();

        builder.Property(cc => cc.NIOFeeAmount)
            .HasColumnName("nio_fee_amount")
            .HasPrecision(8, 2)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");


        // relaciones
        builder.HasOne(cc => cc.Customer)
            .WithMany()
            .HasForeignKey(cc => cc.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cc => cc.Branch)
            .WithMany()
            .HasForeignKey(cc => cc.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cc => cc.UnitMeasure)
            .WithMany()
            .HasForeignKey(cc => cc.MeasureUnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}