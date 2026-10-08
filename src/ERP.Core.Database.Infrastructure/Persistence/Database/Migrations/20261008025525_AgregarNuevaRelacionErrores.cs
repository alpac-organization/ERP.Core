using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNuevaRelacionErrores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_codes_assignment_operational_AssignmentOperationalId",
                schema: "public",
                table: "codes");

            migrationBuilder.DropIndex(
                name: "IX_codes_AssignmentOperationalId",
                schema: "public",
                table: "codes");

            migrationBuilder.DropColumn(
                name: "AssignmentOperationalId",
                schema: "public",
                table: "codes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignmentOperationalId",
                schema: "public",
                table: "codes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_codes_AssignmentOperationalId",
                schema: "public",
                table: "codes",
                column: "AssignmentOperationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_codes_assignment_operational_AssignmentOperationalId",
                schema: "public",
                table: "codes",
                column: "AssignmentOperationalId",
                principalSchema: "public",
                principalTable: "assignment_operational",
                principalColumn: "assignment_operational_id");
        }
    }
}
