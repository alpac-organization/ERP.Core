using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarColumnasAcumulados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary_earned_monthly",
                schema: "public",
                table: "income_tax_accrual",
                newName: "salary_earned_currently");

            migrationBuilder.RenameColumn(
                name: "salary_earned_fortnight",
                schema: "public",
                table: "income_tax_accrual",
                newName: "salary_earned_by_fornight");

            migrationBuilder.RenameColumn(
                name: "ir_monthly",
                schema: "public",
                table: "income_tax_accrual",
                newName: "accumulated_ir_currently");

            migrationBuilder.RenameColumn(
                name: "ir_fortnight",
                schema: "public",
                table: "income_tax_accrual",
                newName: "accumulated_ir_by_fornight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary_earned_currently",
                schema: "public",
                table: "income_tax_accrual",
                newName: "salary_earned_monthly");

            migrationBuilder.RenameColumn(
                name: "salary_earned_by_fornight",
                schema: "public",
                table: "income_tax_accrual",
                newName: "salary_earned_fortnight");

            migrationBuilder.RenameColumn(
                name: "accumulated_ir_currently",
                schema: "public",
                table: "income_tax_accrual",
                newName: "ir_monthly");

            migrationBuilder.RenameColumn(
                name: "accumulated_ir_by_fornight",
                schema: "public",
                table: "income_tax_accrual",
                newName: "ir_fortnight");
        }
    }
}
