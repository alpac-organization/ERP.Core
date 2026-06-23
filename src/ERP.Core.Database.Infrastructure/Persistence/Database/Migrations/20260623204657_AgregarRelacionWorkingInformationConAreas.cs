using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionWorkingInformationConAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_working_information_collaborators_collaborator_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropForeignKey(
                name: "FK_working_information_sub_catalogs_work_area_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropIndex(
                name: "IX_working_information_work_area_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropColumn(
                name: "work_area_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.AlterColumn<Guid>(
                name: "area_id",
                schema: "public",
                table: "working_information",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_working_information_area_id",
                schema: "public",
                table: "working_information",
                column: "area_id");

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_collaborators_collaborator_id",
                schema: "public",
                table: "working_information",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_work_areas_area_id",
                schema: "public",
                table: "working_information",
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
                name: "FK_working_information_collaborators_collaborator_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropForeignKey(
                name: "FK_working_information_work_areas_area_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropIndex(
                name: "IX_working_information_area_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.AlterColumn<Guid>(
                name: "area_id",
                schema: "public",
                table: "working_information",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "work_area_id",
                schema: "public",
                table: "working_information",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_working_information_work_area_id",
                schema: "public",
                table: "working_information",
                column: "work_area_id");

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_collaborators_collaborator_id",
                schema: "public",
                table: "working_information",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_sub_catalogs_work_area_id",
                schema: "public",
                table: "working_information",
                column: "work_area_id",
                principalSchema: "public",
                principalTable: "sub_catalogs",
                principalColumn: "sub_catalog_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
