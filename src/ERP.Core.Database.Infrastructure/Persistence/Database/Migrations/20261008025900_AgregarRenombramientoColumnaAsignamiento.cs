using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRenombramientoColumnaAsignamiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_codes_assignment_operational_AssignmentId",
                schema: "public",
                table: "codes");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                schema: "public",
                table: "codes",
                newName: "assignment_id");

            migrationBuilder.RenameIndex(
                name: "IX_codes_AssignmentId",
                schema: "public",
                table: "codes",
                newName: "IX_codes_assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_codes_assignment_operational_assignment_id",
                schema: "public",
                table: "codes",
                column: "assignment_id",
                principalSchema: "public",
                principalTable: "assignment_operational",
                principalColumn: "assignment_operational_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_codes_assignment_operational_assignment_id",
                schema: "public",
                table: "codes");

            migrationBuilder.RenameColumn(
                name: "assignment_id",
                schema: "public",
                table: "codes",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_codes_assignment_id",
                schema: "public",
                table: "codes",
                newName: "IX_codes_AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_codes_assignment_operational_AssignmentId",
                schema: "public",
                table: "codes",
                column: "AssignmentId",
                principalSchema: "public",
                principalTable: "assignment_operational",
                principalColumn: "assignment_operational_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
