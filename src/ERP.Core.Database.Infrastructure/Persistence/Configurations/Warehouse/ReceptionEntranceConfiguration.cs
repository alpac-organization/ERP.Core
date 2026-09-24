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

        builder.Property(e => e.CustomBranchId)
            .HasColumnName("custom_branch_id")
            .IsRequired();

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

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.Property(e => e.AdditionalData)
            .HasColumnName("additional_data")
            .HasColumnType("jsonb")
            .IsRequired(false);

        builder.HasOne(e => e.CustomsBranches)
            .WithMany(e => e.ReceptionEntrances)
            .HasForeignKey(e => e.CustomBranchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}