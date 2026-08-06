using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class MerchandisesConfiguration : IEntityTypeConfiguration<Merchandises>
{
    public void Configure(EntityTypeBuilder<Merchandises> builder)
    {
        builder.ToTable("merchandise");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("merchandise_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(e => e.MerchandiseName)
            .HasColumnName("merchandise_name")
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired(false);
        
        builder.Property(e => e.CategoryId)
            .HasColumnName("category_id")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");
            
        builder.HasOne(p => p.Category)
            .WithMany(r => r.Merchandises)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}