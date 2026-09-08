using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarLimpiaDeTablasLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_companies_company_id",
                schema: "public",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "FK_locations_warehouses_WarehouseId",
                schema: "public",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locations",
                schema: "public",
                table: "locations");

            migrationBuilder.RenameTable(
                name: "locations",
                schema: "public",
                newName: "warehouse_locations",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                schema: "public",
                table: "warehouse_locations",
                newName: "warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_locations_WarehouseId",
                schema: "public",
                table: "warehouse_locations",
                newName: "IX_warehouse_locations_warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_locations_company_id",
                schema: "public",
                table: "warehouse_locations",
                newName: "IX_warehouse_locations_company_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse_locations",
                schema: "public",
                table: "warehouse_locations",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_locations_companies_company_id",
                schema: "public",
                table: "warehouse_locations",
                column: "company_id",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_locations_warehouses_warehouse_id",
                schema: "public",
                table: "warehouse_locations",
                column: "warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_locations_companies_company_id",
                schema: "public",
                table: "warehouse_locations");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_locations_warehouses_warehouse_id",
                schema: "public",
                table: "warehouse_locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse_locations",
                schema: "public",
                table: "warehouse_locations");

            migrationBuilder.RenameTable(
                name: "warehouse_locations",
                schema: "public",
                newName: "locations",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "warehouse_id",
                schema: "public",
                table: "locations",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_locations_warehouse_id",
                schema: "public",
                table: "locations",
                newName: "IX_locations_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_locations_company_id",
                schema: "public",
                table: "locations",
                newName: "IX_locations_company_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locations",
                schema: "public",
                table: "locations",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_companies_company_id",
                schema: "public",
                table: "locations",
                column: "company_id",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locations_warehouses_WarehouseId",
                schema: "public",
                table: "locations",
                column: "WarehouseId",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
