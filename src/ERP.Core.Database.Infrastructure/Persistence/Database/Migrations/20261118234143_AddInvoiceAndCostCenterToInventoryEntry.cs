using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceAndCostCenterToInventoryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_kardex_product_id",
                schema: "public",
                table: "kardex");

            migrationBuilder.AddColumn<DateOnly>(
                name: "invoice_date",
                schema: "public",
                table: "inventory_entries",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "invoice_number",
                schema: "public",
                table: "inventory_entries",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "inventory_entry_items",
                schema: "public",
                columns: table => new
                {
                    inventory_entry_item_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    inventory_entry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchase_order_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cost_center_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_entry_items", x => x.inventory_entry_item_id);
                    table.ForeignKey(
                        name: "FK_inventory_entry_items_cost_centers_cost_center_id",
                        column: x => x.cost_center_id,
                        principalSchema: "public",
                        principalTable: "cost_centers",
                        principalColumn: "cost_center_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_entry_items_inventory_entries_inventory_entry_id",
                        column: x => x.inventory_entry_id,
                        principalSchema: "public",
                        principalTable: "inventory_entries",
                        principalColumn: "inventory_entry_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_entry_items_purchase_order_items_purchase_order_i~",
                        column: x => x.purchase_order_item_id,
                        principalSchema: "public",
                        principalTable: "purchase_order_items",
                        principalColumn: "purchase_order_item_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_kardex_area_cost_center_transaction_date",
                schema: "public",
                table: "kardex",
                columns: new[] { "area_id", "cost_center_id", "transaction_date" });

            migrationBuilder.CreateIndex(
                name: "ix_kardex_product_id_transaction_date",
                schema: "public",
                table: "kardex",
                columns: new[] { "product_id", "transaction_date" });

            migrationBuilder.CreateIndex(
                name: "ix_inventory_entry_items_cost_center_id",
                schema: "public",
                table: "inventory_entry_items",
                column: "cost_center_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_entry_items_purchase_order_item_id",
                schema: "public",
                table: "inventory_entry_items",
                column: "purchase_order_item_id");

            migrationBuilder.CreateIndex(
                name: "ux_inventory_entry_items_entry_order_item",
                schema: "public",
                table: "inventory_entry_items",
                columns: new[] { "inventory_entry_id", "purchase_order_item_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_entry_items",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_kardex_area_cost_center_transaction_date",
                schema: "public",
                table: "kardex");

            migrationBuilder.DropIndex(
                name: "ix_kardex_product_id_transaction_date",
                schema: "public",
                table: "kardex");

            migrationBuilder.DropColumn(
                name: "invoice_date",
                schema: "public",
                table: "inventory_entries");

            migrationBuilder.DropColumn(
                name: "invoice_number",
                schema: "public",
                table: "inventory_entries");

            migrationBuilder.CreateIndex(
                name: "IX_kardex_product_id",
                schema: "public",
                table: "kardex",
                column: "product_id");
        }
    }
}
