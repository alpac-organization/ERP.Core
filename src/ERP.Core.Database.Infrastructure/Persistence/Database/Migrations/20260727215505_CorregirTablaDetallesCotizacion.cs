using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CorregirTablaDetallesCotizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotes_details_products_ProductId",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropForeignKey(
                name: "FK_quotes_details_units_measurement_UnitMeasureId",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropIndex(
                name: "IX_quotes_details_ProductId",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropIndex(
                name: "IX_quotes_details_UnitMeasureId",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropColumn(
                name: "UnitMeasureId",
                schema: "public",
                table: "quotes_details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "public",
                table: "quotes_details",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitMeasureId",
                schema: "public",
                table: "quotes_details",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_quotes_details_ProductId",
                schema: "public",
                table: "quotes_details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_details_UnitMeasureId",
                schema: "public",
                table: "quotes_details",
                column: "UnitMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_details_products_ProductId",
                schema: "public",
                table: "quotes_details",
                column: "ProductId",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_details_units_measurement_UnitMeasureId",
                schema: "public",
                table: "quotes_details",
                column: "UnitMeasureId",
                principalSchema: "public",
                principalTable: "units_measurement",
                principalColumn: "unit_measure_id");
        }
    }
}
