using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUserWithSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "processed_by_user_id",
                schema: "public",
                table: "step_execution_logs_managua",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_managua_processed_by_user_id",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "processed_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_step_execution_logs_managua_users_processed_by_user_id",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "processed_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_step_execution_logs_managua_users_processed_by_user_id",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropIndex(
                name: "IX_step_execution_logs_managua_processed_by_user_id",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.AlterColumn<string>(
                name: "processed_by_user_id",
                schema: "public",
                table: "step_execution_logs_managua",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
