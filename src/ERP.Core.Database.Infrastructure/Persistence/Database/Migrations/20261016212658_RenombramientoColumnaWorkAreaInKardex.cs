using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenombramientoColumnaWorkAreaInKardex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kardex_work_areas_WorkAreaId",
                schema: "public",
                table: "kardex");

            migrationBuilder.RenameColumn(
                name: "WorkAreaId",
                schema: "public",
                table: "kardex",
                newName: "area_id");

            migrationBuilder.AddForeignKey(
                name: "FK_kardex_work_areas_area_id",
                schema: "public",
                table: "kardex",
                column: "area_id",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kardex_work_areas_area_id",
                schema: "public",
                table: "kardex");

            migrationBuilder.RenameColumn(
                name: "area_id",
                schema: "public",
                table: "kardex",
                newName: "WorkAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_kardex_work_areas_WorkAreaId",
                schema: "public",
                table: "kardex",
                column: "WorkAreaId",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
