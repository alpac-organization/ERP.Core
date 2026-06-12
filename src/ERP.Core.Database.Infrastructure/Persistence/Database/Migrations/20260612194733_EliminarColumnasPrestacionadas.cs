using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EliminarColumnasPrestacionadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bonus",
                schema: "public",
                table: "professional_services_payrolls");

            migrationBuilder.DropColumn(
                name: "commissions",
                schema: "public",
                table: "professional_services_payrolls");

            migrationBuilder.DropColumn(
                name: "number_overtime",
                schema: "public",
                table: "professional_services_payrolls");

            migrationBuilder.DropColumn(
                name: "overtimes",
                schema: "public",
                table: "professional_services_payrolls");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "bonus",
                schema: "public",
                table: "professional_services_payrolls",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "commissions",
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
                table: "professional_services_payrolls",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "overtimes",
                schema: "public",
                table: "professional_services_payrolls",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
