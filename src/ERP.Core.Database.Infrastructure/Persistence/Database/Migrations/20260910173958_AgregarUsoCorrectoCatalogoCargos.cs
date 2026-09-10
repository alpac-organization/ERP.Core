using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUsoCorrectoCatalogoCargos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_working_information_sub_catalogs_work_position_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropIndex(
                name: "IX_working_information_work_position_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropColumn(
                name: "work_position_id",
                schema: "public",
                table: "working_information");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "work_position_id",
                schema: "public",
                table: "working_information",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_working_information_work_position_id",
                schema: "public",
                table: "working_information",
                column: "work_position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_sub_catalogs_work_position_id",
                schema: "public",
                table: "working_information",
                column: "work_position_id",
                principalSchema: "public",
                principalTable: "sub_catalogs",
                principalColumn: "sub_catalog_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
