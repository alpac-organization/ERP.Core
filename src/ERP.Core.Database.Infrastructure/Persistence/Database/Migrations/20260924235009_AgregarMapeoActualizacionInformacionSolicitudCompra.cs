using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMapeoActualizacionInformacionSolicitudCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomBranchId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.RenameColumn(
                name: "CustomBranchId",
                schema: "public",
                table: "reception_entrance",
                newName: "custom_branch_id");

            migrationBuilder.RenameIndex(
                name: "IX_reception_entrance_CustomBranchId",
                schema: "public",
                table: "reception_entrance",
                newName: "IX_reception_entrance_custom_branch_id");

            migrationBuilder.AddColumn<string>(
                name: "additional_data",
                schema: "public",
                table: "purchase_requests",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_customs_branches_custom_branch_id",
                schema: "public",
                table: "reception_entrance",
                column: "custom_branch_id",
                principalSchema: "public",
                principalTable: "customs_branches",
                principalColumn: "custom_branch_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_customs_branches_custom_branch_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "additional_data",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.RenameColumn(
                name: "custom_branch_id",
                schema: "public",
                table: "reception_entrance",
                newName: "CustomBranchId");

            migrationBuilder.RenameIndex(
                name: "IX_reception_entrance_custom_branch_id",
                schema: "public",
                table: "reception_entrance",
                newName: "IX_reception_entrance_CustomBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomBranchId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomBranchId",
                principalSchema: "public",
                principalTable: "customs_branches",
                principalColumn: "custom_branch_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
