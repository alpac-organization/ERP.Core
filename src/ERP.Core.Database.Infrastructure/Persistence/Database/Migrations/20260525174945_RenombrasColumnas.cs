using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenombrasColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permit_applications_payrolls_PayrolId",
                schema: "public",
                table: "permit_applications");

            migrationBuilder.RenameColumn(
                name: "PayrolId",
                schema: "public",
                table: "permit_applications",
                newName: "payroll_id");

            migrationBuilder.RenameIndex(
                name: "IX_permit_applications_PayrolId",
                schema: "public",
                table: "permit_applications",
                newName: "IX_permit_applications_payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_permit_applications_payrolls_payroll_id",
                schema: "public",
                table: "permit_applications",
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
                name: "FK_permit_applications_payrolls_payroll_id",
                schema: "public",
                table: "permit_applications");

            migrationBuilder.RenameColumn(
                name: "payroll_id",
                schema: "public",
                table: "permit_applications",
                newName: "PayrolId");

            migrationBuilder.RenameIndex(
                name: "IX_permit_applications_payroll_id",
                schema: "public",
                table: "permit_applications",
                newName: "IX_permit_applications_PayrolId");

            migrationBuilder.AddForeignKey(
                name: "FK_permit_applications_payrolls_PayrolId",
                schema: "public",
                table: "permit_applications",
                column: "PayrolId",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
