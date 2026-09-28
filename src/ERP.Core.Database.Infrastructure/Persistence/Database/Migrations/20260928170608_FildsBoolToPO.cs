using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FildsBoolToPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "additional_data",
                schema: "public",
                table: "operational_orders",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "has_collaborators_assigned",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "has_machinery_assigned",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "additional_data",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "has_collaborators_assigned",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "has_machinery_assigned",
                schema: "public",
                table: "operational_orders");
        }
    }
}
