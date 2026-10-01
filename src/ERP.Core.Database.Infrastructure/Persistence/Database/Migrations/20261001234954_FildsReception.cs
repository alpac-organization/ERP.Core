using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FildsReception : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "consignee",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sender",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "shipping_company",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "consignee",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "sender",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "shipping_company",
                schema: "public",
                table: "operational_orders");
        }
    }
}
