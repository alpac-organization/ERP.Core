using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class InventoryOutputsConfiguration : IEntityTypeConfiguration<InventoryOutputs>
    {
        public void Configure(EntityTypeBuilder<InventoryOutputs> builder)
        {
            builder.ToTable("inventory_outputs");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("inventory_output_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(50);

        #region Foreign Keys

            builder.HasOne(e => e.WorkArea)
                .WithMany(e => e.InventoryOutputs)
                .HasForeignKey(e => e.WorkAreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Branch)
                .WithMany(e => e.InventoryOutputs)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

        #endregion Foreign Keys

        }
    }
}