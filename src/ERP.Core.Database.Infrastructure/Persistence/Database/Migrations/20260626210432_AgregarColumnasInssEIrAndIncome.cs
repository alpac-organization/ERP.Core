using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnasInssEIrAndIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                schema: "public",
                table: "inss_accounting_information",
                newName: "total");

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                schema: "public",
                table: "inss_accounting_information",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<decimal>(
                name: "income",
                schema: "public",
                table: "inss_accounting_information",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ir_fortnight",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ir_monthly",
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
                name: "income",
                schema: "public",
                table: "inss_accounting_information");

            migrationBuilder.DropColumn(
                name: "ir_fortnight",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.DropColumn(
                name: "ir_monthly",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.RenameColumn(
                name: "total",
                schema: "public",
                table: "inss_accounting_information",
                newName: "Total");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                schema: "public",
                table: "inss_accounting_information",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
