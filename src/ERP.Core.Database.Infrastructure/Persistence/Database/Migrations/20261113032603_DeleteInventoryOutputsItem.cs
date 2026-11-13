using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class DeleteInventoryOutputsItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_outputs_items",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "is_all_dispached",
                schema: "public",
                table: "inventory_outputs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_all_dispached",
                schema: "public",
                table: "inventory_outputs",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "inventory_outputs_items",
                schema: "public",
                columns: table => new
                {
                    inventory_output_item_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    inventory_output_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_stock_id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dispatched_quantity = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_outputs_items", x => x.inventory_output_item_id);
                    table.ForeignKey(
                        name: "FK_inventory_outputs_items_inventory_outputs_inventory_output_~",
                        column: x => x.inventory_output_id,
                        principalSchema: "public",
                        principalTable: "inventory_outputs",
                        principalColumn: "inventory_output_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_outputs_items_product_stock_product_stock_id",
                        column: x => x.product_stock_id,
                        principalSchema: "public",
                        principalTable: "product_stock",
                        principalColumn: "product_stock_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_outputs_items_inventory_output_id",
                schema: "public",
                table: "inventory_outputs_items",
                column: "inventory_output_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_outputs_items_product_stock_id",
                schema: "public",
                table: "inventory_outputs_items",
                column: "product_stock_id");
        }
    }
}
