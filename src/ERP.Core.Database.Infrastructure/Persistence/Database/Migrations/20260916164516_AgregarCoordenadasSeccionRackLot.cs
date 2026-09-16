using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCoordenadasSeccionRackLot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lot_coordinates",
                schema: "public",
                columns: table => new
                {
                    coordinate_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_x = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_z = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    rotation_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    lot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lot_coordinates", x => x.coordinate_id);
                    table.ForeignKey(
                        name: "FK_lot_coordinates_lots_lot_id",
                        column: x => x.lot_id,
                        principalSchema: "public",
                        principalTable: "lots",
                        principalColumn: "tramo_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rack_coordinates",
                schema: "public",
                columns: table => new
                {
                    coordinate_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_x = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_z = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    rotation_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rack_coordinates", x => x.coordinate_id);
                    table.ForeignKey(
                        name: "FK_rack_coordinates_racks_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks",
                        principalColumn: "rack_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "section_coordinates",
                schema: "public",
                columns: table => new
                {
                    coordinate_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_x = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_z = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    rotation_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    section_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section_coordinates", x => x.coordinate_id);
                    table.ForeignKey(
                        name: "FK_section_coordinates_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ux_lot_coordinates_lot_id",
                schema: "public",
                table: "lot_coordinates",
                column: "lot_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_rack_coordinates_rack_id",
                schema: "public",
                table: "rack_coordinates",
                column: "rack_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_section_coordinates_section_id",
                schema: "public",
                table: "section_coordinates",
                column: "section_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lot_coordinates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "rack_coordinates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "section_coordinates",
                schema: "public");
        }
    }
}
