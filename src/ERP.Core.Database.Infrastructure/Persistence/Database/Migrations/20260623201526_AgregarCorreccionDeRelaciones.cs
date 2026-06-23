using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCorreccionDeRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_products_category_products_CategoryId",
                schema: "public",
                table: "category_products");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_products_category_products_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_category_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_category_products_id",
                schema: "public",
                table: "product");

            migrationBuilder.DropColumn(
                name: "category_products_id",
                schema: "public",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "category_products_id",
                schema: "public",
                table: "category_products",
                newName: "category_product_id");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "category_id",
                schema: "public",
                table: "product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_category_products_category_products_ParentId",
                schema: "public",
                table: "category_products",
                column: "ParentId",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_products_category_id",
                schema: "public",
                table: "product",
                column: "category_id",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_product_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_products_category_products_ParentId",
                schema: "public",
                table: "category_products");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_products_category_id",
                schema: "public",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "category_product_id",
                schema: "public",
                table: "category_products",
                newName: "category_products_id");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "category_id",
                schema: "public",
                table: "product",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "category_products_id",
                schema: "public",
                table: "product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_product_category_products_id",
                schema: "public",
                table: "product",
                column: "category_products_id");

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
                name: "FK_product_category_products_category_products_id",
                schema: "public",
                table: "product",
                column: "category_products_id",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_products_id",
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
        }
    }
}
