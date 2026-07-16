using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EliminarTablaConflicto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_warehouses_warehouse_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_workflow_step_definitions_current_step_id",
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
                name: "IX_step_execution_logs_workflow_step_definition_id",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_current_step_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_warehouse_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropColumn(
                name: "workflow_step_definition_id",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropColumn(
                name: "current_step_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.AddColumn<string>(
                name: "workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_at",
                schema: "public",
                table: "record_entrances",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "current_step_code",
                schema: "public",
                table: "record_entrances",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropColumn(
                name: "current_step_code",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.AddColumn<int>(
                name: "workflow_step_definition_id",
                schema: "public",
                table: "step_execution_logs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_at",
                schema: "public",
                table: "record_entrances",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "current_step_id",
                schema: "public",
                table: "record_entrances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "warehouse_id",
                schema: "public",
                table: "record_entrances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "workflow_step_definitions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    execution_order = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_step_definitions", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_workflow_step_definition_id",
                schema: "public",
                table: "step_execution_logs",
                column: "workflow_step_definition_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_current_step_id",
                schema: "public",
                table: "record_entrances",
                column: "current_step_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_warehouse_id",
                schema: "public",
                table: "record_entrances",
                column: "warehouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_warehouses_warehouse_id",
                schema: "public",
                table: "record_entrances",
                column: "warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_workflow_step_definitions_current_step_id",
                schema: "public",
                table: "record_entrances",
                column: "current_step_id",
                principalSchema: "public",
                principalTable: "workflow_step_definitions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_step_execution_logs_workflow_step_definitions_workflow_step~",
                schema: "public",
                table: "step_execution_logs",
                column: "workflow_step_definition_id",
                principalSchema: "public",
                principalTable: "workflow_step_definitions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
