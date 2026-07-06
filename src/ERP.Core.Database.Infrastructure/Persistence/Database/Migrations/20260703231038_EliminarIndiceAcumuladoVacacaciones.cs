using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EliminarIndiceAcumuladoVacacaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vacations_accruals_collaborator_id",
                schema: "public",
                table: "vacations_accruals");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_accruals_collaborator_id",
                schema: "public",
                table: "vacations_accruals",
                column: "collaborator_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vacations_accruals_collaborator_id",
                schema: "public",
                table: "vacations_accruals");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_accruals_collaborator_id",
                schema: "public",
                table: "vacations_accruals",
                column: "collaborator_id",
                unique: true);
        }
    }
}
