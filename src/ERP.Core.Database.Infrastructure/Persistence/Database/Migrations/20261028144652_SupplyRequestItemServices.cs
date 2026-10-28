using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class SupplyRequestItemServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplyRequestItem_product_stock_ProductStockId",
                schema: "public",
                table: "SupplyRequestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyRequestItem_supply_requests_SupplyRequestId",
                schema: "public",
                table: "SupplyRequestItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplyRequestItem",
                schema: "public",
                table: "SupplyRequestItem");

            migrationBuilder.RenameTable(
                name: "SupplyRequestItem",
                schema: "public",
                newName: "supply_request_item",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "public",
                table: "supply_request_item",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "SupplyRequestId",
                schema: "public",
                table: "supply_request_item",
                newName: "supply_request_id");

            migrationBuilder.RenameColumn(
                name: "ReasonUse",
                schema: "public",
                table: "supply_request_item",
                newName: "reason_use");

            migrationBuilder.RenameColumn(
                name: "ProductStockId",
                schema: "public",
                table: "supply_request_item",
                newName: "product_stock_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "supply_request_item",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "supply_request_item",
                newName: "supply_request_item_id");

            migrationBuilder.RenameIndex(
                name: "IX_SupplyRequestItem_SupplyRequestId",
                schema: "public",
                table: "supply_request_item",
                newName: "IX_supply_request_item_supply_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_SupplyRequestItem_ProductStockId",
                schema: "public",
                table: "supply_request_item",
                newName: "IX_supply_request_item_product_stock_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                schema: "public",
                table: "supply_request_item",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "reason_use",
                schema: "public",
                table: "supply_request_item",
                type: "reason_use_enum",
                nullable: false,
                defaultValueSql: "'sale'::reason_use_enum",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "supply_request_item",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductStockId1",
                schema: "public",
                table: "supply_request_item",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplyRequestId1",
                schema: "public",
                table: "supply_request_item",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_supply_request_item",
                schema: "public",
                table: "supply_request_item",
                column: "supply_request_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_supply_request_item_ProductStockId1",
                schema: "public",
                table: "supply_request_item",
                column: "ProductStockId1");

            migrationBuilder.CreateIndex(
                name: "IX_supply_request_item_SupplyRequestId1",
                schema: "public",
                table: "supply_request_item",
                column: "SupplyRequestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_supply_request_item_product_stock_ProductStockId1",
                schema: "public",
                table: "supply_request_item",
                column: "ProductStockId1",
                principalSchema: "public",
                principalTable: "product_stock",
                principalColumn: "product_stock_id");

            migrationBuilder.AddForeignKey(
                name: "FK_supply_request_item_product_stock_product_stock_id",
                schema: "public",
                table: "supply_request_item",
                column: "product_stock_id",
                principalSchema: "public",
                principalTable: "product_stock",
                principalColumn: "product_stock_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_supply_request_item_supply_requests_SupplyRequestId1",
                schema: "public",
                table: "supply_request_item",
                column: "SupplyRequestId1",
                principalSchema: "public",
                principalTable: "supply_requests",
                principalColumn: "supply_request_id");

            migrationBuilder.AddForeignKey(
                name: "FK_supply_request_item_supply_requests_supply_request_id",
                schema: "public",
                table: "supply_request_item",
                column: "supply_request_id",
                principalSchema: "public",
                principalTable: "supply_requests",
                principalColumn: "supply_request_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supply_request_item_product_stock_ProductStockId1",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_request_item_product_stock_product_stock_id",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_request_item_supply_requests_SupplyRequestId1",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_request_item_supply_requests_supply_request_id",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_supply_request_item",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.DropIndex(
                name: "IX_supply_request_item_ProductStockId1",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.DropIndex(
                name: "IX_supply_request_item_SupplyRequestId1",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.DropColumn(
                name: "ProductStockId1",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.DropColumn(
                name: "SupplyRequestId1",
                schema: "public",
                table: "supply_request_item");

            migrationBuilder.RenameTable(
                name: "supply_request_item",
                schema: "public",
                newName: "SupplyRequestItem",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "amount",
                schema: "public",
                table: "SupplyRequestItem",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "supply_request_id",
                schema: "public",
                table: "SupplyRequestItem",
                newName: "SupplyRequestId");

            migrationBuilder.RenameColumn(
                name: "reason_use",
                schema: "public",
                table: "SupplyRequestItem",
                newName: "ReasonUse");

            migrationBuilder.RenameColumn(
                name: "product_stock_id",
                schema: "public",
                table: "SupplyRequestItem",
                newName: "ProductStockId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "SupplyRequestItem",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "supply_request_item_id",
                schema: "public",
                table: "SupplyRequestItem",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_supply_request_item_supply_request_id",
                schema: "public",
                table: "SupplyRequestItem",
                newName: "IX_SupplyRequestItem_SupplyRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_supply_request_item_product_stock_id",
                schema: "public",
                table: "SupplyRequestItem",
                newName: "IX_SupplyRequestItem_ProductStockId");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                schema: "public",
                table: "SupplyRequestItem",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ReasonUse",
                schema: "public",
                table: "SupplyRequestItem",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "reason_use_enum",
                oldDefaultValueSql: "'sale'::reason_use_enum");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "SupplyRequestItem",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplyRequestItem",
                schema: "public",
                table: "SupplyRequestItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyRequestItem_product_stock_ProductStockId",
                schema: "public",
                table: "SupplyRequestItem",
                column: "ProductStockId",
                principalSchema: "public",
                principalTable: "product_stock",
                principalColumn: "product_stock_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyRequestItem_supply_requests_SupplyRequestId",
                schema: "public",
                table: "SupplyRequestItem",
                column: "SupplyRequestId",
                principalSchema: "public",
                principalTable: "supply_requests",
                principalColumn: "supply_request_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
