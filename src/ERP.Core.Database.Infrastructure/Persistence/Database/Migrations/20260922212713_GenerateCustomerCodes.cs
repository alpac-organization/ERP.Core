using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class GenerateCustomerCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_customers_company_id",
                schema: "public",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "ix_customers_customer_code",
                schema: "public",
                table: "customers");

            migrationBuilder.CreateIndex(
                name: "ix_customers_customer_code",
                schema: "public",
                table: "customers",
                columns: new[] { "company_id", "customer_code" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_customers_customer_code",
                schema: "public",
                table: "customers");

            migrationBuilder.CreateIndex(
                name: "IX_customers_company_id",
                schema: "public",
                table: "customers",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_customers_customer_code",
                schema: "public",
                table: "customers",
                column: "customer_code",
                unique: true);
        }
    }
}
