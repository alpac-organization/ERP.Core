using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EliminarIndicesDuplicados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_wa_company_id",
                schema: "public",
                table: "work_areas");

            migrationBuilder.DropIndex(
                name: "IX_jb_cost_center_id",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropIndex(
                name: "IX_jb_work_area_id",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropIndex(
                name: "IX_cc_work_area_id",
                schema: "public",
                table: "cost_centers");

            migrationBuilder.CreateIndex(
                name: "IX_work_areas_company_id",
                schema: "public",
                table: "work_areas",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_positions_cost_center_id",
                schema: "public",
                table: "job_positions",
                column: "cost_center_id");

            migrationBuilder.CreateIndex(
                name: "IX_job_positions_work_area_id",
                schema: "public",
                table: "job_positions",
                column: "work_area_id");

            migrationBuilder.CreateIndex(
                name: "IX_cost_centers_work_area_id",
                schema: "public",
                table: "cost_centers",
                column: "work_area_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_work_areas_company_id",
                schema: "public",
                table: "work_areas");

            migrationBuilder.DropIndex(
                name: "IX_job_positions_cost_center_id",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropIndex(
                name: "IX_job_positions_work_area_id",
                schema: "public",
                table: "job_positions");

            migrationBuilder.DropIndex(
                name: "IX_cost_centers_work_area_id",
                schema: "public",
                table: "cost_centers");

            migrationBuilder.CreateIndex(
                name: "IX_wa_company_id",
                schema: "public",
                table: "work_areas",
                column: "company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_jb_cost_center_id",
                schema: "public",
                table: "job_positions",
                column: "cost_center_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_jb_work_area_id",
                schema: "public",
                table: "job_positions",
                column: "work_area_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cc_work_area_id",
                schema: "public",
                table: "cost_centers",
                column: "work_area_id",
                unique: true);
        }
    }
}
