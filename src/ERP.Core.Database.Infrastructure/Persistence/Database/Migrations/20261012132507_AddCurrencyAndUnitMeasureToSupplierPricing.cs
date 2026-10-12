using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrencyAndUnitMeasureToSupplierPricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "unit_measure_id",
                schema: "public",
                table: "supplier_products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "currency",
                schema: "public",
                table: "history_prices",
                type: "currency_enum",
                nullable: false,
                defaultValueSql: "'nio'::currency_enum");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_products_unit_measure_id",
                schema: "public",
                table: "supplier_products",
                column: "unit_measure_id");

            migrationBuilder.AddForeignKey(
                name: "FK_supplier_products_units_measurement_unit_measure_id",
                schema: "public",
                table: "supplier_products",
                column: "unit_measure_id",
                principalSchema: "public",
                principalTable: "units_measurement",
                principalColumn: "unit_measure_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplier_products_units_measurement_unit_measure_id",
                schema: "public",
                table: "supplier_products");

            migrationBuilder.DropIndex(
                name: "ix_supplier_products_unit_measure_id",
                schema: "public",
                table: "supplier_products");

            migrationBuilder.DropColumn(
                name: "unit_measure_id",
                schema: "public",
                table: "supplier_products");

            migrationBuilder.DropColumn(
                name: "currency",
                schema: "public",
                table: "history_prices");
        }
    }
}
