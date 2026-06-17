using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionTipoNominasContables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "company_id",
                schema: "public",
                table: "types_accounting_payroll",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "does_generate_seniority",
                schema: "public",
                table: "types_accounting_payroll",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_types_accounting_payroll_company_id",
                schema: "public",
                table: "types_accounting_payroll",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_types_accounting_payroll_companies_company_id",
                schema: "public",
                table: "types_accounting_payroll",
                column: "company_id",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_types_accounting_payroll_companies_company_id",
                schema: "public",
                table: "types_accounting_payroll");

            migrationBuilder.DropIndex(
                name: "IX_types_accounting_payroll_company_id",
                schema: "public",
                table: "types_accounting_payroll");

            migrationBuilder.DropColumn(
                name: "company_id",
                schema: "public",
                table: "types_accounting_payroll");

            migrationBuilder.DropColumn(
                name: "does_generate_seniority",
                schema: "public",
                table: "types_accounting_payroll");
        }
    }
}
