using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class ReceptionDetailsManaguaConfiguration : IEntityTypeConfiguration<ReceptionDetailsManagua>
{
    public void Configure(EntityTypeBuilder<ReceptionDetailsManagua> builder)
    {
        builder.ToTable("reception_details_managua");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
           .HasColumnName("reception_details_managua_id");

        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_managua_id")
            .IsRequired();

        builder.Property(e => e.CountryOfOrigin)
            .HasColumnName("country_of_origin")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Aduana)
            .HasColumnName("aduana")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.GateEntranceTime)
            .HasColumnName("gate_entrance_time")
            .IsRequired();

        builder.Property(e => e.PlateNumber)
            .HasColumnName("plate_number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.TrailerChassis)
            .HasColumnName("trailer_chassis")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.DriverLicense)
            .HasColumnName("driver_license")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Transportista)
            .HasColumnName("transportista")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.Medio)
            .HasColumnName("medio")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.DriverName)
            .HasColumnName("driver_name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Consignee)
            .HasColumnName("consignee")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.SealNumber)
            .HasColumnName("seal_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.RecordEntrance)
            .WithOne(e => e.ReceptionDetails)
            .HasForeignKey<ReceptionDetailsManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}