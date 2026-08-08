using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class WarehouseRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_racks_sections_section_id",
                schema: "public",
                table: "racks");

            migrationBuilder.DropIndex(
                name: "ix_warehouse_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "max_height",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "min_height",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "net_storage_area",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "parking_spaces_count",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "rampas_count",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "total_area",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "total_cubic_capacity",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "unusable_area",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "max_height_metres",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "max_weight_kg",
                schema: "public",
                table: "racks");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_branch_id",
                schema: "public",
                table: "warehouses",
                newName: "ix_warehouses_branch_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                newName: "ix_warehouses_parent_wareouse_id");

            migrationBuilder.RenameColumn(
                name: "section_id",
                schema: "public",
                table: "racks",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_racks_section_id",
                schema: "public",
                table: "racks",
                newName: "IX_racks_WarehouseId");

            migrationBuilder.AlterColumn<int>(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses",
                type: "warehouse_type_enum",
                nullable: false,
                defaultValueSql: "'fiscal'::warehouse_type_enum",
                oldClrType: typeof(int),
                oldType: "warehouse_type_enum");

            migrationBuilder.AddColumn<Guid>(
                name: "SectionsId",
                schema: "public",
                table: "racks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "warehouse_capacities",
                schema: "public",
                columns: table => new
                {
                    warehouse_capacity_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_area_m2 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    usable_area_m2 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    unusable_area_m2 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_max_polines = table.Column<int>(type: "integer", nullable: false),
                    current_polines_stored = table.Column<int>(type: "integer", nullable: false),
                    last_calculated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_capacities", x => x.warehouse_capacity_id);
                    table.ForeignKey(
                        name: "FK_warehouse_capacities_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_details",
                schema: "public",
                columns: table => new
                {
                    warehouse_details_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    width_metres = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    length_metres = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ramps_count = table.Column<int>(type: "integer", nullable: true),
                    parking_spaces_count = table.Column<int>(type: "integer", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_details", x => x.warehouse_details_id);
                    table.ForeignKey(
                        name: "FK_warehouse_details_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_warehouses_code",
                schema: "public",
                table: "warehouses",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_racks_SectionsId",
                schema: "public",
                table: "racks",
                column: "SectionsId");

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_capacities_warehouse_id",
                schema: "public",
                table: "warehouse_capacities",
                column: "warehouse_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_deatils_warehouse_id",
                schema: "public",
                table: "warehouse_details",
                column: "warehouse_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_racks_sections_SectionsId",
                schema: "public",
                table: "racks",
                column: "SectionsId",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id");

            migrationBuilder.AddForeignKey(
                name: "FK_racks_warehouses_WarehouseId",
                schema: "public",
                table: "racks",
                column: "WarehouseId",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_racks_sections_SectionsId",
                schema: "public",
                table: "racks");

            migrationBuilder.DropForeignKey(
                name: "FK_racks_warehouses_WarehouseId",
                schema: "public",
                table: "racks");

            migrationBuilder.DropTable(
                name: "warehouse_capacities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_details",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_warehouses_code",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropIndex(
                name: "IX_racks_SectionsId",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "SectionsId",
                schema: "public",
                table: "racks");

            migrationBuilder.RenameIndex(
                name: "ix_warehouses_branch_id",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_branch_id");

            migrationBuilder.RenameIndex(
                name: "ix_warehouses_parent_wareouse_id",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_parent_warehouse_id");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                schema: "public",
                table: "racks",
                newName: "section_id");

            migrationBuilder.RenameIndex(
                name: "IX_racks_WarehouseId",
                schema: "public",
                table: "racks",
                newName: "IX_racks_section_id");

            migrationBuilder.AlterColumn<int>(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses",
                type: "warehouse_type_enum",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "warehouse_type_enum",
                oldDefaultValueSql: "'fiscal'::warehouse_type_enum");

            migrationBuilder.AddColumn<decimal>(
                name: "max_height",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "min_height",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "net_storage_area",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "parking_spaces_count",
                schema: "public",
                table: "warehouses",
                type: "numeric(5,1)",
                precision: 5,
                scale: 1,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "rampas_count",
                schema: "public",
                table: "warehouses",
                type: "numeric(5,1)",
                precision: 5,
                scale: 1,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "total_area",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "total_cubic_capacity",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "unusable_area",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "max_height_metres",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "max_weight_kg",
                schema: "public",
                table: "racks",
                type: "numeric(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_id",
                schema: "public",
                table: "warehouses",
                column: "warehouse_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_racks_sections_section_id",
                schema: "public",
                table: "racks",
                column: "section_id",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
