using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarActualizacionWarehouseLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_locations_location_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropIndex(
                name: "IX_warehouses_location_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "location_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseId",
                schema: "public",
                table: "locations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_locations_WarehouseId",
                schema: "public",
                table: "locations",
                column: "WarehouseId",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_warehouses_WarehouseId",
                schema: "public",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_WarehouseId",
                schema: "public",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "public",
                table: "locations");

            migrationBuilder.AddColumn<Guid>(
                name: "location_id",
                schema: "public",
                table: "warehouses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_location_id",
                schema: "public",
                table: "warehouses",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_locations_location_id",
                schema: "public",
                table: "warehouses",
                column: "location_id",
                principalSchema: "public",
                principalTable: "locations",
                principalColumn: "location_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
