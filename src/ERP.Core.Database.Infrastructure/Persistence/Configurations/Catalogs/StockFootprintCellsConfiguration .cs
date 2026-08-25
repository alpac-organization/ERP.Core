using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class StockFootprintCellsConfiguration : IEntityTypeConfiguration<StockFootprintCells>
{
    public void Configure(EntityTypeBuilder<StockFootprintCells> builder)
    {
        builder.ToTable("stock_footprint_cells");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("stock_footprint_cell_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.StockId)
            .HasColumnName("stock_id")
            .IsRequired();

        builder.Property(e => e.RowOffset)
            .HasColumnName("row_offset")
            .IsRequired();

        builder.Property(e => e.ColumnOffset)
            .HasColumnName("column_offset")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.Stock)
            .WithMany()
            .HasForeignKey(e => e.StockId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.StockId)
            .HasDatabaseName("ix_stock_footprint_cells_stock_id");

        builder.HasIndex(e => new { e.StockId, e.RowOffset, e.ColumnOffset })
            .IsUnique()
            .HasDatabaseName("ix_stock_footprint_cells_stock_id_offsets");
    }
}