using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarColumnnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subsidies_payrolls_PayrollId",
                schema: "public",
                table: "subsidies");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                schema: "public",
                table: "subsidies",
                newName: "payroll_id");

            migrationBuilder.RenameColumn(
                name: "AmountDays",
                schema: "public",
                table: "subsidies",
                newName: "amount_days");

            migrationBuilder.RenameIndex(
                name: "IX_subsidies_PayrollId",
                schema: "public",
                table: "subsidies",
                newName: "IX_subsidies_payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_subsidies_payrolls_payroll_id",
                schema: "public",
                table: "subsidies",
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
                name: "FK_subsidies_payrolls_payroll_id",
                schema: "public",
                table: "subsidies");

            migrationBuilder.RenameColumn(
                name: "payroll_id",
                schema: "public",
                table: "subsidies",
                newName: "PayrollId");

            migrationBuilder.RenameColumn(
                name: "amount_days",
                schema: "public",
                table: "subsidies",
                newName: "AmountDays");

            migrationBuilder.RenameIndex(
                name: "IX_subsidies_payroll_id",
                schema: "public",
                table: "subsidies",
                newName: "IX_subsidies_PayrollId");

            migrationBuilder.AddForeignKey(
                name: "FK_subsidies_payrolls_PayrollId",
                schema: "public",
                table: "subsidies",
                column: "PayrollId",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
