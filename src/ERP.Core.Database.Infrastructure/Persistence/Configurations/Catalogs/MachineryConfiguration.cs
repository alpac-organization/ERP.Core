using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class MachineryConfiguration : IEntityTypeConfiguration<Machinery>
{
    public void Configure(EntityTypeBuilder<Machinery> builder)
    {
        builder.ToTable("machineries");
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
            .HasColumnName("machinery_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(w => w.BranchId)
            .HasColumnName("branch_id")
            .IsRequired();

        builder.Property(w => w.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(w => w.SerialNumber)
            .HasColumnName("serial_number")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.Brand)
            .HasColumnName("brand")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.Model)
            .HasColumnName("model")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.Year)
            .HasColumnName("year")
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(w => w.Type)
            .HasColumnName("type")
            .HasColumnType("machinery_type_enum")
            .HasDefaultValueSql("'forklift'::machinery_type_enum")
            .IsRequired();

        builder.Property(w => w.Status)
            .HasColumnName("status")
            .HasColumnType("machinery_status_enum")
            .HasDefaultValueSql("'available'::machinery_status_enum")
            .IsRequired();

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(w => w.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(w => w.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);
        
        
        builder.Property(w => w.Color)
            .HasColumnName("color")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.HasOne(e => e.Branch)
            .WithMany(s => s.Machinery)
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}