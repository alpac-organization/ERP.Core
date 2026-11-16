using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class QuitarIndiceUnicoCodigoProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ux_products_code",
                schema: "public",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "ux_products_code",
                schema: "public",
                table: "products",
                column: "code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ux_products_code",
                schema: "public",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "ux_products_code",
                schema: "public",
                table: "products",
                column: "code",
                unique: true);
        }
    }
}
