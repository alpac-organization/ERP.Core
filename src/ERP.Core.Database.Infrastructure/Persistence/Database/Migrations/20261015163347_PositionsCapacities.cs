using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class PositionsCapacities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "consignee",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.AddColumn<decimal>(
                name: "area_m2",
                schema: "public",
                table: "section_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "length",
                schema: "public",
                table: "section_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "width",
                schema: "public",
                table: "section_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "area_m2",
                schema: "public",
                table: "rack_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "length",
                schema: "public",
                table: "rack_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "width",
                schema: "public",
                table: "rack_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "has_consignees",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_in_transit",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "area_m2",
                schema: "public",
                table: "lots_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "length",
                schema: "public",
                table: "lots_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "width",
                schema: "public",
                table: "lots_positions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "has_outsourced_crew",
                schema: "public",
                table: "assignment_operational",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "has_outsourced_machinery",
                schema: "public",
                table: "assignment_operational",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "outsourced_crew_count",
                schema: "public",
                table: "assignment_operational",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outsourced_machinery_supplier",
                schema: "public",
                table: "assignment_operational",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "section_positions_coordinates",
                schema: "public",
                columns: table => new
                {
                    coordinate_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_x = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_z = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    rotation_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    section_position_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section_positions_coordinates", x => x.coordinate_id);
                    table.ForeignKey(
                        name: "FK_section_positions_coordinates_section_positions_section_pos~",
                        column: x => x.section_position_id,
                        principalSchema: "public",
                        principalTable: "section_positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_section_positions_coordinates_section_position_id",
                schema: "public",
                table: "section_positions_coordinates",
                column: "section_position_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "section_positions_coordinates",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "area_m2",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "length",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "width",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "area_m2",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "length",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "width",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "has_consignees",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "is_in_transit",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "area_m2",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "length",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "width",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "has_outsourced_crew",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "has_outsourced_machinery",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "outsourced_crew_count",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "outsourced_machinery_supplier",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.AddColumn<string>(
                name: "consignee",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: true);
        }
    }
}
