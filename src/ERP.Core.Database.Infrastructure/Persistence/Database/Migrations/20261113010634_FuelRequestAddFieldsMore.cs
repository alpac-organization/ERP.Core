using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FuelRequestAddFieldsMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_allowed_categories",
                schema: "public");

            migrationBuilder.AddColumn<Guid>(
                name: "customer_id",
                schema: "public",
                table: "fuel_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "requested_quantity_litters",
                schema: "public",
                table: "fuel_requests",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_customer_id",
                schema: "public",
                table: "fuel_requests",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_fuel_requests_customers_customer_id",
                schema: "public",
                table: "fuel_requests",
                column: "customer_id",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fuel_requests_customers_customer_id",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropIndex(
                name: "IX_fuel_requests_customer_id",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropColumn(
                name: "customer_id",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.DropColumn(
                name: "requested_quantity_litters",
                schema: "public",
                table: "fuel_requests");

            migrationBuilder.CreateTable(
                name: "inventory_allowed_categories",
                schema: "public",
                columns: table => new
                {
                    inventory_allowed_category_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_allowed_categories", x => x.inventory_allowed_category_id);
                    table.ForeignKey(
                        name: "FK_inventory_allowed_categories_category_products_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_allowed_categories_category_id",
                schema: "public",
                table: "inventory_allowed_categories",
                column: "category_id");
        }
    }
}
