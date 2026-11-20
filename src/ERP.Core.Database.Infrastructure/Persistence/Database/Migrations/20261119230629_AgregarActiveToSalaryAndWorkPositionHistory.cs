using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarActiveToSalaryAndWorkPositionHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_work_position_histories_collaborator_id",
                schema: "public",
                table: "work_position_histories");

            migrationBuilder.DropIndex(
                name: "ux_salaries_collaborator_active",
                schema: "public",
                table: "salaries");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "work_position_histories",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<Guid>(
                name: "personnel_action_request_id",
                schema: "public",
                table: "work_position_histories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "salaries",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_position_histories_personnel_action_request_id",
                schema: "public",
                table: "work_position_histories",
                column: "personnel_action_request_id");

            migrationBuilder.CreateIndex(
                name: "ux_work_position_histories_collaborator_active",
                schema: "public",
                table: "work_position_histories",
                column: "collaborator_id",
                unique: true,
                filter: "\"is_active\" = true AND \"end_date\" IS NULL AND \"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "ux_salaries_collaborator_active",
                schema: "public",
                table: "salaries",
                column: "collaborator_id",
                unique: true,
                filter: "\"is_active\" = true AND \"end_date\" IS NULL AND \"deleted_at\" IS NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_work_position_histories_personnel_action_requests_personnel~",
                schema: "public",
                table: "work_position_histories",
                column: "personnel_action_request_id",
                principalSchema: "public",
                principalTable: "personnel_action_requests",
                principalColumn: "personnel_action_request_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_work_position_histories_personnel_action_requests_personnel~",
                schema: "public",
                table: "work_position_histories");

            migrationBuilder.DropIndex(
                name: "IX_work_position_histories_personnel_action_request_id",
                schema: "public",
                table: "work_position_histories");

            migrationBuilder.DropIndex(
                name: "ux_work_position_histories_collaborator_active",
                schema: "public",
                table: "work_position_histories");

            migrationBuilder.DropIndex(
                name: "ux_salaries_collaborator_active",
                schema: "public",
                table: "salaries");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "public",
                table: "work_position_histories");

            migrationBuilder.DropColumn(
                name: "personnel_action_request_id",
                schema: "public",
                table: "work_position_histories");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "public",
                table: "salaries");

            migrationBuilder.CreateIndex(
                name: "IX_work_position_histories_collaborator_id",
                schema: "public",
                table: "work_position_histories",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "ux_salaries_collaborator_active",
                schema: "public",
                table: "salaries",
                column: "collaborator_id",
                unique: true,
                filter: "\"end_date\" IS NULL AND \"deleted_at\" IS NULL");
        }
    }
}
