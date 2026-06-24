using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSincronizacionBaseDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assistance_control_locations_location_id",
                schema: "public",
                table: "assistance_control");

            migrationBuilder.DropForeignKey(
                name: "FK_job_positions_companies_CompanyId",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_locations_assistance_control_AssistanceControlId1",
                schema: "public",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_AssistanceControlId1",
                schema: "public",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_assistance_control_location_id",
                schema: "public",
                table: "assistance_control");

            migrationBuilder.DropColumn(
                name: "AssistanceControlId",
                schema: "public",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "AssistanceControlId1",
                schema: "public",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "location_id",
                schema: "public",
                table: "assistance_control");

            migrationBuilder.AddForeignKey(
                name: "FK_job_positions_companies_CompanyId",
                schema: "public",
                table: "job_positions",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_positions_companies_CompanyId",
                schema: "public",
                table: "job_positions");

            migrationBuilder.AddColumn<Guid>(
                name: "AssistanceControlId",
                schema: "public",
                table: "locations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AssistanceControlId1",
                schema: "public",
                table: "locations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "location_id",
                schema: "public",
                table: "assistance_control",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_locations_AssistanceControlId1",
                schema: "public",
                table: "locations",
                column: "AssistanceControlId1");

            migrationBuilder.CreateIndex(
                name: "IX_assistance_control_location_id",
                schema: "public",
                table: "assistance_control",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assistance_control_locations_location_id",
                schema: "public",
                table: "assistance_control",
                column: "location_id",
                principalSchema: "public",
                principalTable: "locations",
                principalColumn: "location_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_positions_companies_CompanyId",
                schema: "public",
                table: "job_positions",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locations_assistance_control_AssistanceControlId1",
                schema: "public",
                table: "locations",
                column: "AssistanceControlId1",
                principalSchema: "public",
                principalTable: "assistance_control",
                principalColumn: "assistance_control_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
