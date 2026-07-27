using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCambiosNombreColumnasCotizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotes_branches_BranchId",
                schema: "public",
                table: "quotes");

            migrationBuilder.RenameColumn(
                name: "QuotationCode",
                schema: "public",
                table: "quotes",
                newName: "quotation_code");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                schema: "public",
                table: "quotes",
                newName: "branch_id");

            migrationBuilder.RenameIndex(
                name: "IX_quotes_BranchId",
                schema: "public",
                table: "quotes",
                newName: "IX_quotes_branch_id");

            migrationBuilder.AlterColumn<string>(
                name: "quotation_code",
                schema: "public",
                table: "quotes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_branches_branch_id",
                schema: "public",
                table: "quotes",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotes_branches_branch_id",
                schema: "public",
                table: "quotes");

            migrationBuilder.RenameColumn(
                name: "quotation_code",
                schema: "public",
                table: "quotes",
                newName: "QuotationCode");

            migrationBuilder.RenameColumn(
                name: "branch_id",
                schema: "public",
                table: "quotes",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_quotes_branch_id",
                schema: "public",
                table: "quotes",
                newName: "IX_quotes_BranchId");

            migrationBuilder.AlterColumn<string>(
                name: "QuotationCode",
                schema: "public",
                table: "quotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_branches_BranchId",
                schema: "public",
                table: "quotes",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
