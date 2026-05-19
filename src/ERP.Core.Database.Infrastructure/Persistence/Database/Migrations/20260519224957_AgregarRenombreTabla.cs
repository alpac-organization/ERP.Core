using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRenombreTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacations_accruals_payrolls_PayrollId",
                schema: "public",
                table: "vacations_accruals");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                schema: "public",
                table: "vacations_accruals",
                newName: "payroll_id");

            migrationBuilder.RenameIndex(
                name: "IX_vacations_accruals_PayrollId",
                schema: "public",
                table: "vacations_accruals",
                newName: "IX_vacations_accruals_payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_accruals_payrolls_payroll_id",
                schema: "public",
                table: "vacations_accruals",
                column: "payroll_id",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacations_accruals_payrolls_payroll_id",
                schema: "public",
                table: "vacations_accruals");

            migrationBuilder.RenameColumn(
                name: "payroll_id",
                schema: "public",
                table: "vacations_accruals",
                newName: "PayrollId");

            migrationBuilder.RenameIndex(
                name: "IX_vacations_accruals_payroll_id",
                schema: "public",
                table: "vacations_accruals",
                newName: "IX_vacations_accruals_PayrollId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_accruals_payrolls_PayrollId",
                schema: "public",
                table: "vacations_accruals",
                column: "PayrollId",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
