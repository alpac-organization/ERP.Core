using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTablaAcumulados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accumulated_christmas_bonus",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.DropColumn(
                name: "register_date",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.AddColumn<decimal>(
                name: "FlagAccumulatedIR",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlagNumberOfFortnights",
                schema: "public",
                table: "income_tax_accrual",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FlagSalaryEarned",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagAccumulatedIR",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.DropColumn(
                name: "FlagNumberOfFortnights",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.DropColumn(
                name: "FlagSalaryEarned",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.AddColumn<decimal>(
                name: "accumulated_christmas_bonus",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "register_date",
                schema: "public",
                table: "income_tax_accrual",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
