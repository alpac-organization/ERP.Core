using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EstablecerComoRequeridoLosCamposDePerfilesUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_work_areas_AreaId",
                schema: "public",
                table: "users_profiles");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                schema: "public",
                table: "users_profiles",
                newName: "area_id");

            migrationBuilder.RenameIndex(
                name: "IX_users_profiles_AreaId",
                schema: "public",
                table: "users_profiles",
                newName: "IX_users_profiles_area_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "cost_center_id",
                schema: "public",
                table: "users_profiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "area_id",
                schema: "public",
                table: "users_profiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_work_areas_area_id",
                schema: "public",
                table: "users_profiles",
                column: "area_id",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_work_areas_area_id",
                schema: "public",
                table: "users_profiles");

            migrationBuilder.RenameColumn(
                name: "area_id",
                schema: "public",
                table: "users_profiles",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_users_profiles_area_id",
                schema: "public",
                table: "users_profiles",
                newName: "IX_users_profiles_AreaId");

            migrationBuilder.AlterColumn<Guid>(
                name: "cost_center_id",
                schema: "public",
                table: "users_profiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                schema: "public",
                table: "users_profiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_work_areas_AreaId",
                schema: "public",
                table: "users_profiles",
                column: "AreaId",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
