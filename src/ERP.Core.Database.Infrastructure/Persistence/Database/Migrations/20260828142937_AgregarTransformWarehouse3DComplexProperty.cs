using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTransformWarehouse3DComplexProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_x",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_y",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_z",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_rotation_y",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_x",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_y",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_z",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_rotation_y",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_x",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_y",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_z",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_rotation_y",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "layout_position_x",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "layout_position_y",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "layout_position_z",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "layout_rotation_y",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "layout_position_x",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_position_y",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_position_z",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_rotation_y",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_position_x",
                schema: "public",
                table: "lots");

            migrationBuilder.DropColumn(
                name: "layout_position_y",
                schema: "public",
                table: "lots");

            migrationBuilder.DropColumn(
                name: "layout_position_z",
                schema: "public",
                table: "lots");

            migrationBuilder.DropColumn(
                name: "layout_rotation_y",
                schema: "public",
                table: "lots");
        }
    }
}
