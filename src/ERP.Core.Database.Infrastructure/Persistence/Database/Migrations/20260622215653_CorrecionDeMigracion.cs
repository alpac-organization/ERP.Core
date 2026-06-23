using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionDeMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustometType_CustomerTypeId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Customers_CustomerId",
                schema: "public",
                table: "Product");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "public",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "public",
                newName: "product",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "public",
                table: "product",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                schema: "public",
                table: "product",
                newName: "category_products_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductTypeId",
                schema: "public",
                table: "product",
                newName: "IX_product_category_products_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CustomerId",
                schema: "public",
                table: "product",
                newName: "IX_product_customer_id");

            migrationBuilder.AddColumn<bool>(
                name: "is_owner",
                schema: "public",
                table: "Warehouses",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<Guid>(
                name: "parent_id",
                schema: "public",
                table: "product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                schema: "public",
                table: "product",
                column: "product_id");

            migrationBuilder.CreateTable(
                name: "category_products",
                schema: "public",
                columns: table => new
                {
                    category_products_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_products", x => x.category_products_id);
                    table.ForeignKey(
                        name: "FK_category_products_category_products_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_products_id");
                });

            migrationBuilder.CreateTable(
                name: "customer_types",
                schema: "public",
                columns: table => new
                {
                    customer_type_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_types", x => x.customer_type_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_parent_id",
                schema: "public",
                table: "product",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "public",
                table: "Customers",
                column: "CustomerTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_category_products_ParentId",
                schema: "public",
                table: "category_products",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_customer_types_CustomerTypeId",
                schema: "public",
                table: "Customers",
                column: "CustomerTypeId",
                principalSchema: "public",
                principalTable: "customer_types",
                principalColumn: "customer_type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_Customers_customer_id",
                schema: "public",
                table: "product",
                column: "customer_id",
                principalSchema: "public",
                principalTable: "Customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_products_category_products_id",
                schema: "public",
                table: "product",
                column: "category_products_id",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_products_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_parent_id",
                schema: "public",
                table: "product",
                column: "parent_id",
                principalSchema: "public",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_customer_types_CustomerTypeId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_product_Customers_customer_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_products_category_products_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_parent_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropTable(
                name: "category_products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "customer_types",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                schema: "public",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_parent_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "is_owner",
                schema: "public",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "parent_id",
                schema: "public",
                table: "product");

            migrationBuilder.RenameTable(
                name: "product",
                schema: "public",
                newName: "Product",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                schema: "public",
                table: "Product",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "category_products_id",
                schema: "public",
                table: "Product",
                newName: "ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_product_customer_id",
                schema: "public",
                table: "Product",
                newName: "IX_Product_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_product_category_products_id",
                schema: "public",
                table: "Product",
                newName: "IX_Product_ProductTypeId");

            migrationBuilder.AddColumn<Guid>(
                name: "AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "public",
                table: "Product",
                column: "product_id");

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
                name: "FK_Product_Customers_CustomerId",
                schema: "public",
                table: "Product",
                column: "CustomerId",
                principalSchema: "public",
                principalTable: "Customers",
                principalColumn: "customer_id",
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
