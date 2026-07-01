using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class ReceptionDetailsManaguaConfiguration : IEntityTypeConfiguration<ReceptionDetailsManagua>
{
    public void Configure(EntityTypeBuilder<ReceptionDetailsManagua> builder)
    {
        builder.ToTable("reception_details_managua");
        builder.HasKey(e => e.RecordEntranceManaguaId);

        builder.Property(e => e.RecordEntranceManaguaId)
           .HasColumnName("record_entrance_id");

        builder.Property(e => e.CountryOfOrigin)
            .HasColumnName("country_of_origin")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Aduana)
            .HasColumnName("aduana")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.EntryDateTime)
            .HasColumnName("entry_date_time")
            .IsRequired();

        builder.Property(e => e.PlateNumber)
            .HasColumnName("plate_number")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.TrailerChassis)
            .HasColumnName("trailer_chassis")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.DriverLicense)
            .HasColumnName("driver_license")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.Transportista)
            .HasColumnName("transportista")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Medio)
            .HasColumnName("medium")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.DriverName)
            .HasColumnName("driver_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Consignee)
            .HasColumnName("consignee")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.SealNumber)
            .HasColumnName("seal_number")
            .HasMaxLength(50)
            .IsRequired();
    }
}