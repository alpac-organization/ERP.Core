using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenombraTablaAcumulados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlagSalaryEarned",
                schema: "public",
                table: "income_tax_accrual",
                newName: "flag_salary_earned");

            migrationBuilder.RenameColumn(
                name: "FlagNumberOfFortnights",
                schema: "public",
                table: "income_tax_accrual",
                newName: "flag_number_of_fortnights");

            migrationBuilder.RenameColumn(
                name: "FlagAccumulatedIR",
                schema: "public",
                table: "income_tax_accrual",
                newName: "flag_accumulated_ir");

            migrationBuilder.RenameColumn(
                name: "AccumulatedSeniority",
                schema: "public",
                table: "income_tax_accrual",
                newName: "accumulated_seniority");

            migrationBuilder.AlterColumn<decimal>(
                name: "flag_salary_earned",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "flag_number_of_fortnights",
                schema: "public",
                table: "income_tax_accrual",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "flag_accumulated_ir",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "accumulated_seniority",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "flag_salary_earned",
                schema: "public",
                table: "income_tax_accrual",
                newName: "FlagSalaryEarned");

            migrationBuilder.RenameColumn(
                name: "flag_number_of_fortnights",
                schema: "public",
                table: "income_tax_accrual",
                newName: "FlagNumberOfFortnights");

            migrationBuilder.RenameColumn(
                name: "flag_accumulated_ir",
                schema: "public",
                table: "income_tax_accrual",
                newName: "FlagAccumulatedIR");

            migrationBuilder.RenameColumn(
                name: "accumulated_seniority",
                schema: "public",
                table: "income_tax_accrual",
                newName: "AccumulatedSeniority");

            migrationBuilder.AlterColumn<decimal>(
                name: "FlagSalaryEarned",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "FlagNumberOfFortnights",
                schema: "public",
                table: "income_tax_accrual",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "FlagAccumulatedIR",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "AccumulatedSeniority",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
