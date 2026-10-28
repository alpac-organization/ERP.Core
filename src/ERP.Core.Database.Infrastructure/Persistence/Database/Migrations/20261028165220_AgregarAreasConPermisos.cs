using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarAreasConPermisos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_areas_permissions_work_areas_WorkAreaId1",
                schema: "public",
                table: "inventory_areas_permissions");

            migrationBuilder.DropIndex(
                name: "IX_inventory_areas_permissions_WorkAreaId1",
                schema: "public",
                table: "inventory_areas_permissions");

            migrationBuilder.DropColumn(
                name: "WorkAreaId1",
                schema: "public",
                table: "inventory_areas_permissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkAreaId1",
                schema: "public",
                table: "inventory_areas_permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_areas_permissions_WorkAreaId1",
                schema: "public",
                table: "inventory_areas_permissions",
                column: "WorkAreaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_areas_permissions_work_areas_WorkAreaId1",
                schema: "public",
                table: "inventory_areas_permissions",
                column: "WorkAreaId1",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id");
        }
    }
}
