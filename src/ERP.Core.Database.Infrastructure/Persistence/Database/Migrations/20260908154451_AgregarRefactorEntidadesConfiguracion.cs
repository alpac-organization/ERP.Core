using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRefactorEntidadesConfiguracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maximum_height",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "maximum_height",
                schema: "public",
                table: "rack_capacities");

            migrationBuilder.DropColumn(
                name: "maximum_height",
                schema: "public",
                table: "lots_capacities");

            migrationBuilder.RenameColumn(
                name: "minimum_height",
                schema: "public",
                table: "section_capacities",
                newName: "unused_space_m2");

            migrationBuilder.RenameColumn(
                name: "minimum_height",
                schema: "public",
                table: "rack_capacities",
                newName: "unused_space_m2");

            migrationBuilder.RenameColumn(
                name: "minimum_height",
                schema: "public",
                table: "lots_capacities",
                newName: "unused_space_m2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unused_space_m2",
                schema: "public",
                table: "section_capacities",
                newName: "minimum_height");

            migrationBuilder.RenameColumn(
                name: "unused_space_m2",
                schema: "public",
                table: "rack_capacities",
                newName: "minimum_height");

            migrationBuilder.RenameColumn(
                name: "unused_space_m2",
                schema: "public",
                table: "lots_capacities",
                newName: "minimum_height");

            migrationBuilder.AddColumn<decimal>(
                name: "maximum_height",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "maximum_height",
                schema: "public",
                table: "rack_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "maximum_height",
                schema: "public",
                table: "lots_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);
        }
    }
}
