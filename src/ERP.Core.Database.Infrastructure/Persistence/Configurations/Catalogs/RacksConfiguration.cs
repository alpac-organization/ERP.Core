using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Entities.Catalogs;
namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class RacksConfiguration : IEntityTypeConfiguration<Racks>
{
    public void Configure(EntityTypeBuilder<Racks> builder)
    {
        builder.ToTable("racks");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("racks_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.RowNumber)
            .HasColumnName("row_number")
            .IsRequired();
       
        builder.Property(e => e.LevelNumber)
            .HasColumnName("level_number")
            .IsRequired();
        
        builder.Property(e => e.CostPerPosition)
            .HasColumnName("cost_per_position")
            .HasPrecision(12, 4)
            .IsRequired();

        builder.Property(e => e.IsAvailable)
            .HasColumnName("is_available")
            .HasDefaultValue(true);
        

         builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        // Relación 1:N con Zonas
    }
}