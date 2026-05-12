using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNuevaColumna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deductions_payrolls_PayrollId",
                schema: "public",
                table: "deductions");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                schema: "public",
                table: "deductions",
                newName: "payroll_id");

            migrationBuilder.RenameIndex(
                name: "IX_deductions_PayrollId",
                schema: "public",
                table: "deductions",
                newName: "IX_deductions_payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_deductions_payrolls_payroll_id",
                schema: "public",
                table: "deductions",
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
                name: "FK_deductions_payrolls_payroll_id",
                schema: "public",
                table: "deductions");

            migrationBuilder.RenameColumn(
                name: "payroll_id",
                schema: "public",
                table: "deductions",
                newName: "PayrollId");

            migrationBuilder.RenameIndex(
                name: "IX_deductions_payroll_id",
                schema: "public",
                table: "deductions",
                newName: "IX_deductions_PayrollId");

            migrationBuilder.AddForeignKey(
                name: "FK_deductions_payrolls_PayrollId",
                schema: "public",
                table: "deductions",
                column: "PayrollId",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
