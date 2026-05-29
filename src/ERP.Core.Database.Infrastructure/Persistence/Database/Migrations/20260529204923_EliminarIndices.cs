using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EliminarIndices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_record_travel_expense_collaborator_id",
                schema: "public",
                table: "records_travel_expense_payments");

            migrationBuilder.CreateIndex(
                name: "IX_records_travel_expense_payments_collaborator_id",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "collaborator_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_records_travel_expense_payments_collaborator_id",
                schema: "public",
                table: "records_travel_expense_payments");

            migrationBuilder.CreateIndex(
                name: "ix_record_travel_expense_collaborator_id",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "collaborator_id",
                unique: true);
        }
    }
}
