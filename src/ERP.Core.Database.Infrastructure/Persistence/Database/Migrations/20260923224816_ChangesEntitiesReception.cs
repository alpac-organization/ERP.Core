using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangesEntitiesReception : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "duca_number",
                schema: "public",
                table: "operational_orders",
                newName: "document_number");

            migrationBuilder.AddColumn<int>(
                name: "packages_count",
                schema: "public",
                table: "operational_orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "weight",
                schema: "public",
                table: "operational_orders",
                type: "numeric(8,2)",
                precision: 8,
                scale: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "packages_count",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "weight",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.RenameColumn(
                name: "document_number",
                schema: "public",
                table: "operational_orders",
                newName: "duca_number");
        }
    }
}
