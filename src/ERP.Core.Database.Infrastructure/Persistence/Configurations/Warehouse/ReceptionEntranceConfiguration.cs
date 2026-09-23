using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ReceptionEntranceConfiguration : IEntityTypeConfiguration<ReceptionEntrance>
{
    public void Configure(EntityTypeBuilder<ReceptionEntrance> builder)
    {
        builder.ToTable("reception_entrance");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
           .HasColumnName("reception_entrance_id");

        builder.Property(e => e.SealNumber)
            .HasColumnName("seal_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.ContainerNumber)
            .HasColumnName("container_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.CountryOfOrigin)
            .HasColumnName("country_of_origin")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.DocumentType)
            .HasColumnName("document_type")
            .HasColumnType("document_type_enum")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.CustomsBranches)
            .WithMany()
            .HasForeignKey(e => e.CustomBranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ReceptionTransport)
            .WithOne()
            .HasForeignKey<ReceptionTransportEntrance>(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}