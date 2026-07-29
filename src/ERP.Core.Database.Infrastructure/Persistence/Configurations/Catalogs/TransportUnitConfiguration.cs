using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class TransportUnitConfiguration : IEntityTypeConfiguration<TransportUnit>
{
    public void Configure(EntityTypeBuilder<TransportUnit> builder)
    {
        builder.ToTable("transport_unit");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("transport_unit_id");
        
        builder.Property(e => e.Name)
            .HasColumnName("name")
            .IsRequired();
        
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

    }
}