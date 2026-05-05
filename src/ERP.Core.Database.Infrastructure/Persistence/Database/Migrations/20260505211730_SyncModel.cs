using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class SyncModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_income_tax_accrual_payrolls_payroll_id",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.AddColumn<decimal>(
                name: "commissions",
                schema: "public",
                table: "ordinary_payrolls",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_income_tax_accrual_payrolls_payroll_id",
                schema: "public",
                table: "income_tax_accrual",
                column: "payroll_id",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_income_tax_accrual_payrolls_payroll_id",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.DropColumn(
                name: "commissions",
                schema: "public",
                table: "ordinary_payrolls");

            migrationBuilder.AddForeignKey(
                name: "FK_income_tax_accrual_payrolls_payroll_id",
                schema: "public",
                table: "income_tax_accrual",
                column: "payroll_id",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
