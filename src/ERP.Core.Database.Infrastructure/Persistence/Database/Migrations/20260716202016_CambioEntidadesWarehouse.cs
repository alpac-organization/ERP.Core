using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CambioEntidadesWarehouse : Migration
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

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "public",
                table: "workflow_step_definitions",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs",
                type: "character varying(50)",
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
                type: "character varying(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_workflow_step_definitions_code",
                schema: "public",
                table: "workflow_step_definitions",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_workflow_step_definitions_code",
                schema: "public",
                table: "workflow_step_definitions",
                column: "code",
                unique: true);

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

            migrationBuilder.DropUniqueConstraint(
                name: "AK_workflow_step_definitions_code",
                schema: "public",
                table: "workflow_step_definitions");

            migrationBuilder.DropIndex(
                name: "IX_workflow_step_definitions_code",
                schema: "public",
                table: "workflow_step_definitions");

            migrationBuilder.DropIndex(
                name: "IX_step_execution_logs_workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_current_step_code",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropColumn(
                name: "workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropColumn(
                name: "current_step_code",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "public",
                table: "workflow_step_definitions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
