using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEliminacionRelacionCustomerConProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_customers_CustomerId",
                schema: "public",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CustomerId",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "public",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_CustomerId",
                schema: "public",
                table: "products",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_customers_CustomerId",
                schema: "public",
                table: "products",
                column: "CustomerId",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id");
        }
    }
}
