using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CorregirNombreTablaWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnloadingMachineryAssignmentsManagua_unloading_details_mana~",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnloadingMachineryAssignmentsManagua",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua");

            migrationBuilder.RenameTable(
                name: "UnloadingMachineryAssignmentsManagua",
                schema: "public",
                newName: "unloading_machinery_assignments_managua",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_UnloadingMachineryAssignmentsManagua_unloading_details_mana~",
                schema: "public",
                table: "unloading_machinery_assignments_managua",
                newName: "IX_unloading_machinery_assignments_managua_unloading_details_m~");

            migrationBuilder.AddPrimaryKey(
                name: "PK_unloading_machinery_assignments_managua",
                schema: "public",
                table: "unloading_machinery_assignments_managua",
                column: "unloading_machinery_assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_unloading_machinery_assignments_managua_unloading_details_m~",
                schema: "public",
                table: "unloading_machinery_assignments_managua",
                column: "unloading_details_managua_id",
                principalSchema: "public",
                principalTable: "unloading_details_managua",
                principalColumn: "unloading_details_managua_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_unloading_machinery_assignments_managua_unloading_details_m~",
                schema: "public",
                table: "unloading_machinery_assignments_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_unloading_machinery_assignments_managua",
                schema: "public",
                table: "unloading_machinery_assignments_managua");

            migrationBuilder.RenameTable(
                name: "unloading_machinery_assignments_managua",
                schema: "public",
                newName: "UnloadingMachineryAssignmentsManagua",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_unloading_machinery_assignments_managua_unloading_details_m~",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                newName: "IX_UnloadingMachineryAssignmentsManagua_unloading_details_mana~");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnloadingMachineryAssignmentsManagua",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                column: "unloading_machinery_assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnloadingMachineryAssignmentsManagua_unloading_details_mana~",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                column: "unloading_details_managua_id",
                principalSchema: "public",
                principalTable: "unloading_details_managua",
                principalColumn: "unloading_details_managua_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
