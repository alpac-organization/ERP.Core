using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionAreaTrabajo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AreaId",
                schema: "public",
                table: "users_profiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_profiles_AreaId",
                schema: "public",
                table: "users_profiles",
                column: "AreaId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_work_areas_AreaId",
                schema: "public",
                table: "users_profiles");

            migrationBuilder.DropIndex(
                name: "IX_users_profiles_AreaId",
                schema: "public",
                table: "users_profiles");

            migrationBuilder.DropColumn(
                name: "AreaId",
                schema: "public",
                table: "users_profiles");
        }
    }
}
