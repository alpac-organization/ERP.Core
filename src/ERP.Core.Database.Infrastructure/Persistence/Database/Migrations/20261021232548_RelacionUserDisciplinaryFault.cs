using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUserDisciplinaryFault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_disciplinary_faults_registered_by",
                schema: "public",
                table: "disciplinary_faults",
                column: "registered_by");

            migrationBuilder.AddForeignKey(
                name: "FK_disciplinary_faults_users_registered_by",
                schema: "public",
                table: "disciplinary_faults",
                column: "registered_by",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_disciplinary_faults_users_registered_by",
                schema: "public",
                table: "disciplinary_faults");

            migrationBuilder.DropIndex(
                name: "IX_disciplinary_faults_registered_by",
                schema: "public",
                table: "disciplinary_faults");
        }
    }
}
