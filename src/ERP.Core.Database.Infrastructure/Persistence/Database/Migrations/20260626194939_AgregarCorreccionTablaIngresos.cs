using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCorreccionTablaIngresos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_incomes_payrolls_payroll_id ",
                schema: "public",
                table: "incomes");

            migrationBuilder.RenameColumn(
                name: "payroll_id ",
                schema: "public",
                table: "incomes",
                newName: "payroll_id");

            migrationBuilder.RenameIndex(
                name: "IX_incomes_payroll_id ",
                schema: "public",
                table: "incomes",
                newName: "IX_incomes_payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_incomes_payrolls_payroll_id",
                schema: "public",
                table: "incomes",
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
                name: "FK_incomes_payrolls_payroll_id",
                schema: "public",
                table: "incomes");

            migrationBuilder.RenameColumn(
                name: "payroll_id",
                schema: "public",
                table: "incomes",
                newName: "payroll_id ");

            migrationBuilder.RenameIndex(
                name: "IX_incomes_payroll_id",
                schema: "public",
                table: "incomes",
                newName: "IX_incomes_payroll_id ");

            migrationBuilder.AddForeignKey(
                name: "FK_incomes_payrolls_payroll_id ",
                schema: "public",
                table: "incomes",
                column: "payroll_id ",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
