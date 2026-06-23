using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionDeEntidadesYConfiguracionesAlmace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_products_category_products_ParentId",
                schema: "public",
                table: "category_products");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_customer_types_CustomerTypeId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_product_Customers_customer_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_parent_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_branches_BranchId",
                schema: "public",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                schema: "public",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "product");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "customer_types");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "category_products");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                schema: "public",
                newName: "warehouses",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "public",
                newName: "customers",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_BranchId",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_BranchId");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                schema: "public",
                table: "product",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_parent_id",
                schema: "public",
                table: "product",
                newName: "IX_product_category_id");

            migrationBuilder.RenameColumn(
                name: "CustomerTypeId",
                schema: "public",
                table: "customers",
                newName: "customer_type_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "category_products",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                schema: "public",
                table: "category_products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_category_products_ParentId",
                schema: "public",
                table: "category_products",
                newName: "IX_category_products_CategoryId");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "category_products",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouses",
                schema: "public",
                table: "warehouses",
                column: "warehouse_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                schema: "public",
                table: "customers",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_customer_type_id",
                schema: "public",
                table: "customers",
                column: "customer_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_category_products_category_products_CategoryId",
                schema: "public",
                table: "category_products",
                column: "CategoryId",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_products_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_customers_customer_types_customer_type_id",
                schema: "public",
                table: "customers",
                column: "customer_type_id",
                principalSchema: "public",
                principalTable: "customer_types",
                principalColumn: "customer_type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_customers_customer_id",
                schema: "public",
                table: "product",
                column: "customer_id",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_category_id",
                schema: "public",
                table: "product",
                column: "category_id",
                principalSchema: "public",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_products_category_products_CategoryId",
                schema: "public",
                table: "category_products");

            migrationBuilder.DropForeignKey(
                name: "FK_customers_customer_types_customer_type_id",
                schema: "public",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_product_customers_customer_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_category_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouses",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                schema: "public",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_customer_type_id",
                schema: "public",
                table: "customers");

            migrationBuilder.RenameTable(
                name: "warehouses",
                schema: "public",
                newName: "Warehouses",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "customers",
                schema: "public",
                newName: "Customers",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_BranchId",
                schema: "public",
                table: "Warehouses",
                newName: "IX_Warehouses_BranchId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                schema: "public",
                table: "product",
                newName: "parent_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_category_id",
                schema: "public",
                table: "product",
                newName: "IX_product_parent_id");

            migrationBuilder.RenameColumn(
                name: "customer_type_id",
                schema: "public",
                table: "Customers",
                newName: "CustomerTypeId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "category_products",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "public",
                table: "category_products",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_category_products_CategoryId",
                schema: "public",
                table: "category_products",
                newName: "IX_category_products_ParentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "product",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "customer_types",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "category_products",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "category_products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                schema: "public",
                table: "Warehouses",
                column: "warehouse_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                schema: "public",
                table: "Customers",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "public",
                table: "Customers",
                column: "CustomerTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_category_products_category_products_ParentId",
                schema: "public",
                table: "category_products",
                column: "ParentId",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_products_id");

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
                name: "FK_product_product_parent_id",
                schema: "public",
                table: "product",
                column: "parent_id",
                principalSchema: "public",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_branches_BranchId",
                schema: "public",
                table: "Warehouses",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
