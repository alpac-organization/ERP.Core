using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionesDeAreasConInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supply_requests_work_areas_WorkAreaId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropIndex(
                name: "IX_supply_requests_WorkAreaId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropColumn(
                name: "WorkAreaId1",
                schema: "public",
                table: "supply_requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkAreaId1",
                schema: "public",
                table: "supply_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_supply_requests_WorkAreaId1",
                schema: "public",
                table: "supply_requests",
                column: "WorkAreaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_supply_requests_work_areas_WorkAreaId1",
                schema: "public",
                table: "supply_requests",
                column: "WorkAreaId1",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id");
        }
    }
}
