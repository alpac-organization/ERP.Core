using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ReajusteDeEntidadesAlmacen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustometType_CustomerTypeId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                schema: "public",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_CustometType_AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "CustometType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductType",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                schema: "public",
                table: "Product",
                newName: "CatalogWarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductTypeId",
                schema: "public",
                table: "Product",
                newName: "IX_Product_CatalogWarehouseId");

            migrationBuilder.RenameColumn(
                name: "CustomerTypeId",
                schema: "public",
                table: "Customers",
                newName: "CatalogWarehouseId");

            migrationBuilder.AddColumn<bool>(
                name: "is_owner",
                schema: "public",
                table: "Warehouses",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "catalog_warehouse",
                schema: "public",
                columns: table => new
                {
                    catalog_warehouse_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalog_warehouse", x => x.catalog_warehouse_id);
                    table.ForeignKey(
                        name: "FK_catalog_warehouse_catalog_warehouse_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "public",
                        principalTable: "catalog_warehouse",
                        principalColumn: "catalog_warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CatalogWarehouseId",
                schema: "public",
                table: "Customers",
                column: "CatalogWarehouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_catalog_warehouse_parent_id",
                schema: "public",
                table: "catalog_warehouse",
                column: "parent_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_catalog_warehouse_CatalogWarehouseId",
                schema: "public",
                table: "Customers",
                column: "CatalogWarehouseId",
                principalSchema: "public",
                principalTable: "catalog_warehouse",
                principalColumn: "catalog_warehouse_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_catalog_warehouse_CatalogWarehouseId",
                schema: "public",
                table: "Product",
                column: "CatalogWarehouseId",
                principalSchema: "public",
                principalTable: "catalog_warehouse",
                principalColumn: "catalog_warehouse_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_catalog_warehouse_CatalogWarehouseId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_catalog_warehouse_CatalogWarehouseId",
                schema: "public",
                table: "Product");

            migrationBuilder.DropTable(
                name: "catalog_warehouse",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CatalogWarehouseId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "is_owner",
                schema: "public",
                table: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "CatalogWarehouseId",
                schema: "public",
                table: "Product",
                newName: "ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CatalogWarehouseId",
                schema: "public",
                table: "Product",
                newName: "IX_Product_ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "CatalogWarehouseId",
                schema: "public",
                table: "Customers",
                newName: "CustomerTypeId");

            migrationBuilder.AddColumn<Guid>(
                name: "AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CustometType",
                schema: "public",
                columns: table => new
                {
                    type_customer_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    type_customer_code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    type_customer_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustometType", x => x.type_customer_id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                schema: "public",
                columns: table => new
                {
                    type_product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    type_product_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.type_product_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses",
                column: "AllowedCustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "public",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustometType_CustomerTypeId",
                schema: "public",
                table: "Customers",
                column: "CustomerTypeId",
                principalSchema: "public",
                principalTable: "CustometType",
                principalColumn: "type_customer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                schema: "public",
                table: "Product",
                column: "ProductTypeId",
                principalSchema: "public",
                principalTable: "ProductType",
                principalColumn: "type_product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_CustometType_AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses",
                column: "AllowedCustomerTypeId",
                principalSchema: "public",
                principalTable: "CustometType",
                principalColumn: "type_customer_id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
