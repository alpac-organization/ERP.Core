using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ChristmasBonusAdvanceConfiguration
        : IEntityTypeConfiguration<ChristmasBonusAdvance>
    {
        public void Configure(
            EntityTypeBuilder<ChristmasBonusAdvance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                .HasPrecision(18, 4);

            builder.Property(x => x.AmountInDollars)
                .HasPrecision(18, 4);

            builder.HasIndex(x => new
            {
                x.CollaboratorId,
                x.ChristmasBonusPeriodId,
                x.Status
            });


            builder.HasOne(x => x.ChristmasBonusPeriod)
                .WithMany(x => x.Advances)
                .HasForeignKey(x => x.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Collaborator)
                .WithMany(x => x.ChristmasBonusAdvances)
                .HasForeignKey(x => x.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Payroll)
                .WithMany(x => x.ChristmasBonusAdvances)
                .HasForeignKey(x => x.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.ToTable(table =>
            {
                table.HasCheckConstraint(
                    "CK_ChristmasBonusAdvance_Amount",
                    "\"Amount\" > 0");

                table.HasCheckConstraint(
                    "CK_ChristmasBonusAdvance_LocalAmount",
                    "\"AmountInLocalCurrency\" > 0");
            });
        }
    }
}