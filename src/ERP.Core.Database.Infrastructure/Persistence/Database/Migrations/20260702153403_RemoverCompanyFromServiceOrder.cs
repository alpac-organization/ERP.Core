using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoverCompanyFromServiceOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_orders_companies_company_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.RenameColumn(
                name: "company_id",
                schema: "public",
                table: "service_orders",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_service_orders_company_id",
                schema: "public",
                table: "service_orders",
                newName: "IX_service_orders_CompanyId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_service_orders_companies_CompanyId",
                schema: "public",
                table: "service_orders",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_orders_companies_CompanyId",
                schema: "public",
                table: "service_orders");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                schema: "public",
                table: "service_orders",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_service_orders_CompanyId",
                schema: "public",
                table: "service_orders",
                newName: "IX_service_orders_company_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "company_id",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_service_orders_companies_company_id",
                schema: "public",
                table: "service_orders",
                column: "company_id",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
