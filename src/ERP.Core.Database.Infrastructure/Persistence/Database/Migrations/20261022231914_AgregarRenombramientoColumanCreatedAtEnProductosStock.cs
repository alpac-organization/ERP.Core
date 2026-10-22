using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRenombramientoColumanCreatedAtEnProductosStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_stock_products_ProductId1",
                schema: "public",
                table: "product_stock");

            migrationBuilder.DropIndex(
                name: "IX_product_stock_ProductId1",
                schema: "public",
                table: "product_stock");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                schema: "public",
                table: "product_stock");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "product_stock",
                newName: "deleted_at");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "product_stock",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "product_stock");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "product_stock",
                newName: "DeletedAt");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                schema: "public",
                table: "product_stock",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_stock_ProductId1",
                schema: "public",
                table: "product_stock",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_product_stock_products_ProductId1",
                schema: "public",
                table: "product_stock",
                column: "ProductId1",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id");
        }
    }
}
