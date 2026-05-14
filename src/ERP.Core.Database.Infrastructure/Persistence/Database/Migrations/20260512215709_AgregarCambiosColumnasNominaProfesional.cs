using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCambiosColumnasNominaProfesional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ordinary_payroll_id",
                schema: "public",
                table: "professional_services_payrolls",
                newName: "professional_services_payroll_id");

            migrationBuilder.RenameIndex(
                name: "ix_ordinary_payroll_id",
                schema: "public",
                table: "professional_services_payrolls",
                newName: "ix_prof_services_payroll_ordinary_payroll_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "professional_services_payroll_id",
                schema: "public",
                table: "professional_services_payrolls",
                newName: "ordinary_payroll_id");

            migrationBuilder.RenameIndex(
                name: "ix_prof_services_payroll_ordinary_payroll_id",
                schema: "public",
                table: "professional_services_payrolls",
                newName: "ix_ordinary_payroll_id");
        }
    }
}
