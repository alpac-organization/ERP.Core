using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaEliminda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "current_step_code",
                schema: "public",
                table: "record_entrances",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "workflow_step_definitions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    execution_order = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_step_definitions", x => x.id);
                    table.UniqueConstraint("AK_workflow_step_definitions_code", x => x.code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs",
                column: "workflow_step_definition_code");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_current_step_code",
                schema: "public",
                table: "record_entrances",
                column: "current_step_code");

            migrationBuilder.CreateIndex(
                name: "IX_workflow_step_definitions_code",
                schema: "public",
                table: "workflow_step_definitions",
                column: "code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_workflow_step_definitions_current_step_code",
                schema: "public",
                table: "record_entrances",
                column: "current_step_code",
                principalSchema: "public",
                principalTable: "workflow_step_definitions",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_step_execution_logs_workflow_step_definitions_workflow_step~",
                schema: "public",
                table: "step_execution_logs",
                column: "workflow_step_definition_code",
                principalSchema: "public",
                principalTable: "workflow_step_definitions",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_workflow_step_definitions_current_step_code",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropForeignKey(
                name: "FK_step_execution_logs_workflow_step_definitions_workflow_step~",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropTable(
                name: "workflow_step_definitions",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_step_execution_logs_workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_current_step_code",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.AlterColumn<string>(
                name: "workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)");

            migrationBuilder.AlterColumn<string>(
                name: "current_step_code",
                schema: "public",
                table: "record_entrances",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)");
        }
    }
}
