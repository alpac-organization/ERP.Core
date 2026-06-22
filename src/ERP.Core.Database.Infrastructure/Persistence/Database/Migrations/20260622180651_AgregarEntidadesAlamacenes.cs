using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadesAlamacenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustometType",
                schema: "public",
                columns: table => new
                {
                    type_customer_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    type_customer_code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    type_customer_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                    type_product_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.type_product_id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "public",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CustomerTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    dni_ruc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    legal_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_Customers_CustometType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalSchema: "public",
                        principalTable: "CustometType",
                        principalColumn: "type_customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                schema: "public",
                columns: table => new
                {
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    warehouse_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AllowedCustomerTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    total_cubic_capacity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_wight_capacity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.warehouse_id);
                    table.ForeignKey(
                        name: "FK_Warehouses_CustometType_AllowedCustomerTypeId",
                        column: x => x.AllowedCustomerTypeId,
                        principalSchema: "public",
                        principalTable: "CustometType",
                        principalColumn: "type_customer_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Warehouses_branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "public",
                        principalTable: "branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "public",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    product_sku = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    unit_of_measure = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Product_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductType",
                        principalColumn: "type_product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_customer_id",
                schema: "public",
                table: "Customers",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                schema: "public",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CustomerId",
                schema: "public",
                table: "Product",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "ix_product_id",
                schema: "public",
                table: "Product",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                schema: "public",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_AllowedCustomerTypeId",
                schema: "public",
                table: "Warehouses",
                column: "AllowedCustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_BranchId",
                schema: "public",
                table: "Warehouses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "ix_warehuose_id",
                schema: "public",
                table: "Warehouses",
                column: "warehouse_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Warehouses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CustometType",
                schema: "public");
        }
    }
}
