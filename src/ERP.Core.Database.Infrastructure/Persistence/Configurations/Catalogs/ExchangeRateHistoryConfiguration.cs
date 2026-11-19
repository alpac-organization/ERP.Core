using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class ExchangeRateHistoryConfiguration : IEntityTypeConfiguration<ExchangeRateHistory>
    {
        public void Configure(EntityTypeBuilder<ExchangeRateHistory> builder)
        {
            builder.ToTable("exchange_rate_histories", table =>
            {
                table.HasCheckConstraint(
                    "ck_exchange_rate_histories_rate",
                    "\"rate\" > 0");

                table.HasCheckConstraint(
                    "ck_exchange_rate_histories_dates",
                    "\"effective_to\" IS NULL OR \"effective_to\" >= \"effective_from\"");
            });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("exchange_rate_history_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("currency_enum")
                .IsRequired();

            builder.Property(e => e.Rate)
                .HasColumnName("rate")
                .HasPrecision(18, 6)
                .IsRequired();

            builder.Property(e => e.EffectiveFrom)
                .HasColumnName("effective_from")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.EffectiveTo)
                .HasColumnName("effective_to")
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(e => new
            {
                e.Currency,
                e.EffectiveFrom
            })
            .IsUnique()
            .HasFilter("\"deleted_at\" IS NULL")
            .HasDatabaseName(
                "ux_exchange_rate_histories_currency_effective_from");

            builder.HasIndex(e => new
            {
                e.Currency,
                e.EffectiveFrom,
                e.EffectiveTo
            })
            .HasDatabaseName(
                "ix_exchange_rate_histories_currency_dates");
        }
    }
}
