using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnaDeTiempoAntiguedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Antique",
                schema: "public",
                table: "ordinary_payrolls",
                newName: "antique");

            migrationBuilder.AlterColumn<decimal>(
                name: "antique",
                schema: "public",
                table: "ordinary_payrolls",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<int>(
                name: "year_antique",
                schema: "public",
                table: "ordinary_payrolls",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year_antique",
                schema: "public",
                table: "ordinary_payrolls");

            migrationBuilder.RenameColumn(
                name: "antique",
                schema: "public",
                table: "ordinary_payrolls",
                newName: "Antique");

            migrationBuilder.AlterColumn<decimal>(
                name: "Antique",
                schema: "public",
                table: "ordinary_payrolls",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
