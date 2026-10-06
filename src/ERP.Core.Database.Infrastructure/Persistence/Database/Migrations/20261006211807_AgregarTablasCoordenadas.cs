using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablasCoordenadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lots_positions_coordinates",
                schema: "public",
                columns: table => new
                {
                    coordinate_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_x = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_z = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    rotation_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    lot_position_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lots_positions_coordinates", x => x.coordinate_id);
                    table.ForeignKey(
                        name: "FK_lots_positions_coordinates_lots_positions_lot_position_id",
                        column: x => x.lot_position_id,
                        principalSchema: "public",
                        principalTable: "lots_positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rack_positions_coordinates",
                schema: "public",
                columns: table => new
                {
                    coordinate_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_x = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    position_z = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    rotation_y = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    rack_position_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rack_positions_coordinates", x => x.coordinate_id);
                    table.ForeignKey(
                        name: "FK_rack_positions_coordinates_rack_positions_rack_position_id",
                        column: x => x.rack_position_id,
                        principalSchema: "public",
                        principalTable: "rack_positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ux_lots_positions_coordinates_lot_position_id",
                schema: "public",
                table: "lots_positions_coordinates",
                column: "lot_position_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_rack_positions_coordinates_rack_position_id",
                schema: "public",
                table: "rack_positions_coordinates",
                column: "rack_position_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lots_positions_coordinates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "rack_positions_coordinates",
                schema: "public");
        }
    }
}
