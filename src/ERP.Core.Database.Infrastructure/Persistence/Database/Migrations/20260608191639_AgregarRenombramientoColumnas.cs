using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRenombramientoColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinalBalance",
                schema: "public",
                table: "vacations_accruals",
                newName: "final_balance");

            migrationBuilder.RenameColumn(
                name: "BeginningBalance",
                schema: "public",
                table: "vacations_accruals",
                newName: "beginning_balance");

            migrationBuilder.AlterColumn<decimal>(
                name: "final_balance",
                schema: "public",
                table: "vacations_accruals",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "beginning_balance",
                schema: "public",
                table: "vacations_accruals",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "final_balance",
                schema: "public",
                table: "vacations_accruals",
                newName: "FinalBalance");

            migrationBuilder.RenameColumn(
                name: "beginning_balance",
                schema: "public",
                table: "vacations_accruals",
                newName: "BeginningBalance");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalBalance",
                schema: "public",
                table: "vacations_accruals",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "BeginningBalance",
                schema: "public",
                table: "vacations_accruals",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
