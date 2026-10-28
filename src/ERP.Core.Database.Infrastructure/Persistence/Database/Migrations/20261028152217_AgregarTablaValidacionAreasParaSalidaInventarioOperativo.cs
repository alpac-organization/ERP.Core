using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablaValidacionAreasParaSalidaInventarioOperativo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inventory_areas_permissions",
                schema: "public",
                columns: table => new
                {
                    inventory_areas_permission_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    work_area_id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkAreaId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_areas_permissions", x => x.inventory_areas_permission_id);
                    table.ForeignKey(
                        name: "FK_inventory_areas_permissions_work_areas_WorkAreaId1",
                        column: x => x.WorkAreaId1,
                        principalSchema: "public",
                        principalTable: "work_areas",
                        principalColumn: "work_area_id");
                    table.ForeignKey(
                        name: "FK_inventory_areas_permissions_work_areas_work_area_id",
                        column: x => x.work_area_id,
                        principalSchema: "public",
                        principalTable: "work_areas",
                        principalColumn: "work_area_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_inventory_areas_permissions_work_area_id",
                schema: "public",
                table: "inventory_areas_permissions",
                column: "work_area_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_areas_permissions_WorkAreaId1",
                schema: "public",
                table: "inventory_areas_permissions",
                column: "WorkAreaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_areas_permissions",
                schema: "public");
        }
    }
}
