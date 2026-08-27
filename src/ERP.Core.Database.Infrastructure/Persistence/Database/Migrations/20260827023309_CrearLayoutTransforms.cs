using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CrearLayoutTransforms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "layout_transforms",
                schema: "public",
                columns: table => new
                {
                    layout_transform_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_x = table.Column<decimal>(type: "numeric(10,0)", precision: 10, scale: 0, nullable: false, defaultValue: 0m),
                    position_y = table.Column<decimal>(type: "numeric(10,0)", precision: 10, scale: 0, nullable: false, defaultValue: 0m),
                    position_z = table.Column<decimal>(type: "numeric(10,0)", precision: 10, scale: 0, nullable: false, defaultValue: 0m),
                    RotationY = table.Column<decimal>(type: "numeric", nullable: false),
                    section_id = table.Column<Guid>(type: "uuid", nullable: true),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lot_id = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_layout_transforms", x => x.layout_transform_id);
                    table.ForeignKey(
                        name: "FK_layout_transforms_lots_lot_id",
                        column: x => x.lot_id,
                        principalSchema: "public",
                        principalTable: "lots",
                        principalColumn: "tramo_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_layout_transforms_racks_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks",
                        principalColumn: "rack_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_layout_transforms_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ux_layout_transforms_lot_id",
                schema: "public",
                table: "layout_transforms",
                column: "lot_id",
                unique: true,
                filter: "lot_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ux_layout_transforms_rack_id",
                schema: "public",
                table: "layout_transforms",
                column: "rack_id",
                unique: true,
                filter: "rack_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ux_layout_transforms_section_id",
                schema: "public",
                table: "layout_transforms",
                column: "section_id",
                unique: true,
                filter: "section_id IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "layout_transforms",
                schema: "public");
        }
    }
}
