using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaCordenadasCartesianas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "layout_transforms_warehouse_3D",
                schema: "public",
                columns: table => new
                {
                    layout_transform_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_x = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    position_y = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    position_z = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    rotation_y = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    section_id = table.Column<Guid>(type: "uuid", nullable: true),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lot_id = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_layout_transforms_warehouse_3D", x => x.layout_transform_id);
                    table.ForeignKey(
                        name: "FK_layout_transforms_warehouse_3D_lots_lot_id",
                        column: x => x.lot_id,
                        principalSchema: "public",
                        principalTable: "lots",
                        principalColumn: "tramo_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_layout_transforms_warehouse_3D_racks_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks",
                        principalColumn: "rack_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_layout_transforms_warehouse_3D_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ux_layout_transforms_lot_id",
                schema: "public",
                table: "layout_transforms_warehouse_3D",
                column: "lot_id",
                unique: true,
                filter: "lot_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ux_layout_transforms_rack_id",
                schema: "public",
                table: "layout_transforms_warehouse_3D",
                column: "rack_id",
                unique: true,
                filter: "rack_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ux_layout_transforms_section_id",
                schema: "public",
                table: "layout_transforms_warehouse_3D",
                column: "section_id",
                unique: true,
                filter: "section_id IS NOT NULL");

            migrationBuilder.Sql("""
            ALTER TABLE public.layout_transforms_warehouse_3D
            ADD CONSTRAINT ck_layout_transforms_warehouse_3d_single_owner
            CHECK (
            ((section_id IS NOT NULL)::int
            + (rack_id IS NOT NULL)::int
            + (lot_id IS NOT NULL)::int) = 1
            ); 
            """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "layout_transforms_warehouse_3D",
                schema: "public");
        }
    }
}
