using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class EntranceDucatsManaguaConfiguration : IEntityTypeConfiguration<EntranceDucatsManagua>
{
    public void Configure(EntityTypeBuilder<EntranceDucatsManagua> builder)
    {
        builder.ToTable("entrance_ducats_managua");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("entrance_ducat_id")
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_managua_id")
            .IsRequired();
        
        builder.Property(e => e.DucatNumber)
            .HasColumnName("ducat_number")
            .HasMaxLength(50)
            .IsRequired();
    }
}