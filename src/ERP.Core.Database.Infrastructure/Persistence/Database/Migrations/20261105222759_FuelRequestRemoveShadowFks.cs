using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FuelRequestRemoveShadowFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fuel_requests_machineries_MachineryId1",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_fuel_requests_product_stock_ProductStockId1",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_fuel_requests_units_measurement_UnitMeasureId1",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropIndex(
                name: "IX_fuel_requests_MachineryId1",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropIndex(
                name: "IX_fuel_requests_ProductStockId1",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropIndex(
                name: "IX_fuel_requests_UnitMeasureId1",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropColumn(
                name: "MachineryId1",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropColumn(
                name: "ProductStockId1",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropColumn(
                name: "UnitMeasureId1",
                schema: "public",
                table: "fuel_requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MachineryId1",
                schema: "public",
                table: "fuel_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductStockId1",
                schema: "public",
                table: "fuel_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitMeasureId1",
                schema: "public",
                table: "fuel_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_MachineryId1",
                schema: "public",
                table: "fuel_requests",
                column: "MachineryId1");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_ProductStockId1",
                schema: "public",
                table: "fuel_requests",
                column: "ProductStockId1");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_UnitMeasureId1",
                schema: "public",
                table: "fuel_requests",
                column: "UnitMeasureId1");

            migrationBuilder.AddForeignKey(
                name: "FK_fuel_requests_machineries_MachineryId1",
                schema: "public",
                table: "fuel_requests",
                column: "MachineryId1",
                principalSchema: "public",
                principalTable: "machineries",
                principalColumn: "machinery_id");

            migrationBuilder.AddForeignKey(
                name: "FK_fuel_requests_product_stock_ProductStockId1",
                schema: "public",
                table: "fuel_requests",
                column: "ProductStockId1",
                principalSchema: "public",
                principalTable: "product_stock",
                principalColumn: "product_stock_id");

            migrationBuilder.AddForeignKey(
                name: "FK_fuel_requests_units_measurement_UnitMeasureId1",
                schema: "public",
                table: "fuel_requests",
                column: "UnitMeasureId1",
                principalSchema: "public",
                principalTable: "units_measurement",
                principalColumn: "unit_measure_id");
        }
    }
}
