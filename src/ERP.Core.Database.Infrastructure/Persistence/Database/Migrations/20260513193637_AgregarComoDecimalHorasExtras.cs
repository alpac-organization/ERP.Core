using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarComoDecimalHorasExtras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number_of_overtime",
                schema: "public",
                table: "professional_services_payrolls");

            migrationBuilder.DropColumn(
                name: "number_of_overtime",
                schema: "public",
                table: "ordinary_payrolls");

            migrationBuilder.AddColumn<decimal>(
                name: "number_overtime",
                schema: "public",
                table: "professional_services_payrolls",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "number_overtime",
                schema: "public",
                table: "ordinary_payrolls",
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
                name: "number_overtime",
                schema: "public",
                table: "professional_services_payrolls");

            migrationBuilder.DropColumn(
                name: "number_overtime",
                schema: "public",
                table: "ordinary_payrolls");

            migrationBuilder.AddColumn<int>(
                name: "number_of_overtime",
                schema: "public",
                table: "professional_services_payrolls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number_of_overtime",
                schema: "public",
                table: "ordinary_payrolls",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
