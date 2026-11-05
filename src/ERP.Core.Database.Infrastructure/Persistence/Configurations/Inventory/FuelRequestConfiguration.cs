using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory;

public class FuelRequestConfiguration : IEntityTypeConfiguration<FuelRequest>
{
    public void Configure(EntityTypeBuilder<FuelRequest> builder)
    {
        builder.ToTable("fuel_requests");
    }
}