using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCentroCostoAsociadoProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_credit_information_customer_branches_branch_id",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_products_ProductId",
                schema: "public",
                table: "ProductStock");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyRequestItem_ProductStock_ProductStockId",
                schema: "public",
                table: "SupplyRequestItem");

            migrationBuilder.DropTable(
                name: "customer_branches",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStock",
                schema: "public",
                table: "ProductStock");

            migrationBuilder.DropIndex(
                name: "IX_ProductStock_ProductId",
                schema: "public",
                table: "ProductStock");

            migrationBuilder.RenameTable(
                name: "ProductStock",
                schema: "public",
                newName: "product_stock",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "public",
                table: "product_stock",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "MinimumStock",
                schema: "public",
                table: "product_stock",
                newName: "minimum_stock");

            migrationBuilder.RenameColumn(
                name: "MaximumStock",
                schema: "public",
                table: "product_stock",
                newName: "maximum_stock");

            migrationBuilder.RenameColumn(
                name: "AvailableQuantity",
                schema: "public",
                table: "product_stock",
                newName: "available_quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "product_stock",
                newName: "product_stock_id");

            migrationBuilder.AddColumn<Guid>(
                name: "cost_center_id",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "product_stock_id",
                schema: "public",
                table: "product_stock",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "cost_center_id",
                schema: "public",
                table: "product_stock",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "product_stock",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_stock",
                schema: "public",
                table: "product_stock",
                column: "product_stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_cost_center_id",
                schema: "public",
                table: "products",
                column: "cost_center_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_stock_cost_center_id",
                schema: "public",
                table: "product_stock",
                column: "cost_center_id");

            migrationBuilder.CreateIndex(
                name: "ux_product_stock_product_costcenter",
                schema: "public",
                table: "product_stock",
                columns: new[] { "product_id", "cost_center_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_product_stock_cost_centers_cost_center_id",
                schema: "public",
                table: "product_stock",
                column: "cost_center_id",
                principalSchema: "public",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_stock_products_product_id",
                schema: "public",
                table: "product_stock",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_cost_centers_cost_center_id",
                schema: "public",
                table: "products",
                column: "cost_center_id",
                principalSchema: "public",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyRequestItem_product_stock_ProductStockId",
                schema: "public",
                table: "SupplyRequestItem",
                column: "ProductStockId",
                principalSchema: "public",
                principalTable: "product_stock",
                principalColumn: "product_stock_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_stock_cost_centers_cost_center_id",
                schema: "public",
                table: "product_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_product_stock_products_product_id",
                schema: "public",
                table: "product_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_products_cost_centers_cost_center_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyRequestItem_product_stock_ProductStockId",
                schema: "public",
                table: "SupplyRequestItem");

            migrationBuilder.DropIndex(
                name: "IX_products_cost_center_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_stock",
                schema: "public",
                table: "product_stock");

            migrationBuilder.DropIndex(
                name: "IX_product_stock_cost_center_id",
                schema: "public",
                table: "product_stock");

            migrationBuilder.DropIndex(
                name: "ux_product_stock_product_costcenter",
                schema: "public",
                table: "product_stock");

            migrationBuilder.DropColumn(
                name: "cost_center_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "cost_center_id",
                schema: "public",
                table: "product_stock");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "public",
                table: "product_stock");

            migrationBuilder.RenameTable(
                name: "product_stock",
                schema: "public",
                newName: "ProductStock",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "public",
                table: "ProductStock",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "minimum_stock",
                schema: "public",
                table: "ProductStock",
                newName: "MinimumStock");

            migrationBuilder.RenameColumn(
                name: "maximum_stock",
                schema: "public",
                table: "ProductStock",
                newName: "MaximumStock");

            migrationBuilder.RenameColumn(
                name: "available_quantity",
                schema: "public",
                table: "ProductStock",
                newName: "AvailableQuantity");

            migrationBuilder.RenameColumn(
                name: "product_stock_id",
                schema: "public",
                table: "ProductStock",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "ProductStock",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStock",
                schema: "public",
                table: "ProductStock",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "customer_branches",
                schema: "public",
                columns: table => new
                {
                    customer_branch_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    contact = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_main_branch = table.Column<bool>(type: "boolean", nullable: false),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_branches", x => x.customer_branch_id);
                    table.ForeignKey(
                        name: "FK_customer_branches_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductId",
                schema: "public",
                table: "ProductStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "ix_customer_branches_customer_id",
                schema: "public",
                table: "customer_branches",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_credit_information_customer_branches_branch_id",
                schema: "public",
                table: "customer_credit_information",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "customer_branches",
                principalColumn: "customer_branch_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_products_ProductId",
                schema: "public",
                table: "ProductStock",
                column: "ProductId",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyRequestItem_ProductStock_ProductStockId",
                schema: "public",
                table: "SupplyRequestItem",
                column: "ProductStockId",
                principalSchema: "public",
                principalTable: "ProductStock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
