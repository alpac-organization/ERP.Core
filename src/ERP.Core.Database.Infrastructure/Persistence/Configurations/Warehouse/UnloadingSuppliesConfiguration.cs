using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class UnloadingSuppliesConfiguration : IEntityTypeConfiguration<UnloadingSupplies>
{
    public void Configure(EntityTypeBuilder<UnloadingSupplies> builder)
    {
        builder.ToTable("unloading_supplies");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnName("unloading_supplies_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.UnloadingDetailsId)
            .HasColumnName("uloading_details_id")
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasColumnName("quantity")
            .HasColumnType("numeric(10,2)")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(x => x.UnloadingDetails)
            .WithMany(x => x.UnloadingSupplies)
            .HasForeignKey(x => x.UnloadingDetailsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}