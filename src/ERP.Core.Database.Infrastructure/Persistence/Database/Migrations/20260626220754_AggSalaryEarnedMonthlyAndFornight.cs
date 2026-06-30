using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AggSalaryEarnedMonthlyAndFornight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "salary_earned_fortnight",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "salary_earned_monthly",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salary_earned_fortnight",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.DropColumn(
                name: "salary_earned_monthly",
                schema: "public",
                table: "income_tax_accrual");
        }
    }
}
