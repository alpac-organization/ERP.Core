using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class KardexConfiguration : IEntityTypeConfiguration<Kardex>
    {
        public void Configure(EntityTypeBuilder<Kardex> builder)
        {
            builder.ToTable("kardex");

            builder.HasKey(k => k.Id);

            builder.Property(k => k.Id)
                .HasColumnName("kardex_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(k => k.kardexType)
                .HasColumnName("kardex_type")
                .HasColumnType("kardex_type_enum")
                .HasDefaultValueSql("'administrative'::kardex_type_enum")
                .HasSentinel(KardexType.Administrative)
                .IsRequired();

            builder.Property(k => k.MovementType)
                .HasColumnName("movement_type")
                .HasColumnType("kardex_movement_type_enum")
                .HasDefaultValueSql("'buys'::kardex_movement_type_enum")
                .HasSentinel(KardexMovementType.Buys)
                .IsRequired();

            builder.Property(k => k.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired();

            builder.Property(k => k.WorkAreaId)
                .HasColumnName("area_id")
                .IsRequired();

            builder.Property(k => k.Units)
                .HasColumnName("units")
                .IsRequired();

            builder.Property(k => k.UnitCost)
                .HasColumnName("unit_cost")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(k => k.TotalInput)
                .HasColumnName("total_input")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(k => k.TotalOutput)
                .HasColumnName("total_output")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(k => k.TotalUnits)
                .HasColumnName("total_units")
                .IsRequired();

            builder.Property(k => k.AverageCost)
                .HasColumnName("average_cost")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(k => k.TotalKardex)
                .HasColumnName("total_kardex")
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(k => k.TransactionDate)
                .HasColumnName("transaction_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(k => k.TransactionTime)
                .HasColumnName("transaction_time")
                .HasColumnType("time")
                .IsRequired();

            builder.Property(k => k.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(k => k.MovementByUserId)
                .HasColumnName("movement_by_user_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            // ---- Relationships ----

            builder.HasOne(k => k.CostCenter)
                .WithMany(K => K.Kardices)
                .HasForeignKey(k => k.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(k => k.Product)
                .WithMany(K => K.Kardices)
                .HasForeignKey(k => k.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(k => k.User)
                .WithMany(K => K.Kardices)
                .HasForeignKey(k => k.MovementByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(k => k.WorkArea)
                .WithMany(w => w.Kardices) // ajusta al nombre real de la colección en WorkArea
                .HasForeignKey(k => k.WorkAreaId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---- Indexes ----
            builder.HasIndex(k => k.CostCenterId)
                .HasDatabaseName("ix_kardex_cost_center_id");

            builder.HasIndex(k => k.WorkAreaId)
                .HasDatabaseName("ix_kardex_work_area_id");

            builder.HasIndex(k => k.MovementByUserId)
                .HasDatabaseName("ix_kardex_movement_by_user_id");
        }
    }
}
