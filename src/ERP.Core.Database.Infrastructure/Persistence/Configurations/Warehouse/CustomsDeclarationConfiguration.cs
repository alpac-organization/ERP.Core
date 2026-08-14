using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class CustomsDeclarationConfiguration : IEntityTypeConfiguration<CustomsDeclarations>
{
    public void Configure(EntityTypeBuilder<CustomsDeclarations> builder)
    {
        builder.ToTable("customs_declarations");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("customs_declaration_id");

        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.CustomsDeclarationNumber)
            .HasColumnName("number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.RecordEntrance)
            .WithOne(e => e.CustomsDeclarations)
            .HasForeignKey<CustomsDeclarations>(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.ServiceOrderId)
            .HasColumnName("service_order_id")
            .IsRequired(false);

        builder.Property(e => e.ServiceOrderCode)
            .HasColumnName("service_order_code")
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("duca_status_enum")
            .HasDefaultValue(DucaStatus.Pending);

        builder.HasOne(d => d.ServiceOrder)
            .WithOne(so => so.CustomsDeclarations)
            .HasForeignKey<CustomsDeclarations>(d => d.ServiceOrderId)   // 👈 debe ser CustomsDeclarations, no EntranceDucats
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);


    }
}