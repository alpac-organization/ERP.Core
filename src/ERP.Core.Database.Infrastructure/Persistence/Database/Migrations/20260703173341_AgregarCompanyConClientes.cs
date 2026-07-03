using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCompanyConClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_orders_companies_CompanyId",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropIndex(
                name: "IX_service_orders_CompanyId",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "public",
                table: "service_orders");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "public",
                table: "customers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_customers_CompanyId",
                schema: "public",
                table: "customers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_companies_CompanyId",
                schema: "public",
                table: "customers",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_companies_CompanyId",
                schema: "public",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_CompanyId",
                schema: "public",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "public",
                table: "customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_orders_CompanyId",
                schema: "public",
                table: "service_orders",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_service_orders_companies_CompanyId",
                schema: "public",
                table: "service_orders",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id");
        }
    }
}
