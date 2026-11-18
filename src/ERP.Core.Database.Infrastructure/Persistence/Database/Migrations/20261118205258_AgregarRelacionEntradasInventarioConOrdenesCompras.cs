using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionEntradasInventarioConOrdenesCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_entries_purchase_requests_purchase_request_id",
                schema: "public",
                table: "inventory_entries");

            migrationBuilder.DropIndex(
                name: "IX_inventory_entries_purchase_request_id",
                schema: "public",
                table: "inventory_entries");

            migrationBuilder.DropColumn(
                name: "purchase_request_id",
                schema: "public",
                table: "inventory_entries");

            migrationBuilder.AddColumn<Guid>(
                name: "purchase_order_id",
                schema: "public",
                table: "inventory_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_inventory_entries_purchase_order_id",
                schema: "public",
                table: "inventory_entries",
                column: "purchase_order_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_entries_purchase_orders_purchase_order_id",
                schema: "public",
                table: "inventory_entries",
                column: "purchase_order_id",
                principalSchema: "public",
                principalTable: "purchase_orders",
                principalColumn: "purchase_order_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_entries_purchase_orders_purchase_order_id",
                schema: "public",
                table: "inventory_entries");

            migrationBuilder.DropIndex(
                name: "IX_inventory_entries_purchase_order_id",
                schema: "public",
                table: "inventory_entries");

            migrationBuilder.DropColumn(
                name: "purchase_order_id",
                schema: "public",
                table: "inventory_entries");

            migrationBuilder.AddColumn<Guid>(
                name: "purchase_request_id",
                schema: "public",
                table: "inventory_entries",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_entries_purchase_request_id",
                schema: "public",
                table: "inventory_entries",
                column: "purchase_request_id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_entries_purchase_requests_purchase_request_id",
                schema: "public",
                table: "inventory_entries",
                column: "purchase_request_id",
                principalSchema: "public",
                principalTable: "purchase_requests",
                principalColumn: "purchase_request_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
