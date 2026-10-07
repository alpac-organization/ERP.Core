using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangesAtCustomerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_customers_customer_code",
                schema: "public",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "customer_code",
                schema: "public",
                table: "customers");

            migrationBuilder.CreateIndex(
                name: "IX_customers_company_id",
                schema: "public",
                table: "customers",
                column: "company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_customers_company_id",
                schema: "public",
                table: "customers");

            migrationBuilder.AddColumn<string>(
                name: "customer_code",
                schema: "public",
                table: "customers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_customers_customer_code",
                schema: "public",
                table: "customers",
                columns: new[] { "company_id", "customer_code" },
                unique: true);
        }
    }
}
