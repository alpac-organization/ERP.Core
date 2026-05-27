using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CorregirNombresColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cost_centers_work_areas_WorkAreaId",
                schema: "public",
                table: "cost_centers");

            migrationBuilder.DropForeignKey(
                name: "FK_job_positions_cost_centers_CostCenterId",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_positions_work_areas_WorkAreaId",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_work_areas_companies_CompanyId",
                schema: "public",
                table: "work_areas");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                schema: "public",
                table: "work_areas",
                newName: "company_id");

            migrationBuilder.RenameColumn(
                name: "WorkAreaId",
                schema: "public",
                table: "job_positions",
                newName: "work_area_id");

            migrationBuilder.RenameColumn(
                name: "CostCenterId",
                schema: "public",
                table: "job_positions",
                newName: "cost_center_id");

            migrationBuilder.RenameColumn(
                name: "WorkAreaId",
                schema: "public",
                table: "cost_centers",
                newName: "work_area_id");

            migrationBuilder.AlterColumn<string>(
                name: "job_position_name",
                schema: "public",
                table: "job_positions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cost_centers_work_areas_work_area_id",
                schema: "public",
                table: "cost_centers",
                column: "work_area_id",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_positions_cost_centers_cost_center_id",
                schema: "public",
                table: "job_positions",
                column: "cost_center_id",
                principalSchema: "public",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_positions_work_areas_work_area_id",
                schema: "public",
                table: "job_positions",
                column: "work_area_id",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_work_areas_companies_company_id",
                schema: "public",
                table: "work_areas",
                column: "company_id",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cost_centers_work_areas_work_area_id",
                schema: "public",
                table: "cost_centers");

            migrationBuilder.DropForeignKey(
                name: "FK_job_positions_cost_centers_cost_center_id",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_positions_work_areas_work_area_id",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_work_areas_companies_company_id",
                schema: "public",
                table: "work_areas");

            migrationBuilder.RenameColumn(
                name: "company_id",
                schema: "public",
                table: "work_areas",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "work_area_id",
                schema: "public",
                table: "job_positions",
                newName: "WorkAreaId");

            migrationBuilder.RenameColumn(
                name: "cost_center_id",
                schema: "public",
                table: "job_positions",
                newName: "CostCenterId");

            migrationBuilder.RenameColumn(
                name: "work_area_id",
                schema: "public",
                table: "cost_centers",
                newName: "WorkAreaId");

            migrationBuilder.AlterColumn<string>(
                name: "job_position_name",
                schema: "public",
                table: "job_positions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_cost_centers_work_areas_WorkAreaId",
                schema: "public",
                table: "cost_centers",
                column: "WorkAreaId",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_positions_cost_centers_CostCenterId",
                schema: "public",
                table: "job_positions",
                column: "CostCenterId",
                principalSchema: "public",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_positions_work_areas_WorkAreaId",
                schema: "public",
                table: "job_positions",
                column: "WorkAreaId",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_work_areas_companies_CompanyId",
                schema: "public",
                table: "work_areas",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
