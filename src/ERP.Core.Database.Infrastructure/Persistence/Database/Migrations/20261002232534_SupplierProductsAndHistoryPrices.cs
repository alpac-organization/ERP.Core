using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class SupplierProductsAndHistoryPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                schema: "public",
                table: "quotations");

            migrationBuilder.AddColumn<int>(
                name: "product_usage_type",
                schema: "public",
                table: "products",
                type: "product_usage_type_enum",
                nullable: false,
                defaultValueSql: "'insumo'::product_usage_type_enum");

            migrationBuilder.CreateTable(
                name: "supplier_products",
                schema: "public",
                columns: table => new
                {
                    supplier_product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    unit_price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    supplier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_products", x => x.supplier_product_id);
                    table.ForeignKey(
                        name: "FK_supplier_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplier_products_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalSchema: "public",
                        principalTable: "suppliers",
                        principalColumn: "suppliers_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "history_prices",
                schema: "public",
                columns: table => new
                {
                    history_price_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    unit_price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    effective_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    effective_to = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    supplier_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history_prices", x => x.history_price_id);
                    table.ForeignKey(
                        name: "FK_history_prices_supplier_products_supplier_product_id",
                        column: x => x.supplier_product_id,
                        principalSchema: "public",
                        principalTable: "supplier_products",
                        principalColumn: "supplier_product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_history_prices_supplier_product_id",
                schema: "public",
                table: "history_prices",
                column: "supplier_product_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_products_product_id",
                schema: "public",
                table: "supplier_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_products_supplier_id",
                schema: "public",
                table: "supplier_products",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ux_supplier_products_supplier_product",
                schema: "public",
                table: "supplier_products",
                columns: new[] { "supplier_id", "product_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "history_prices",
                schema: "public");

            migrationBuilder.DropTable(
                name: "supplier_products",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "product_usage_type",
                schema: "public",
                table: "products");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
