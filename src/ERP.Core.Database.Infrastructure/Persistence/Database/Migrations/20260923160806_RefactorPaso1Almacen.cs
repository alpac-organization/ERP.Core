using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPaso1Almacen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discrepancies_entrance_ducats_EntranceDucatsId1",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropForeignKey(
                name: "FK_discrepancies_entrance_ducats_entrance_ducats_id",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropForeignKey(
                name: "FK_discrepancies_record_entrances_RecordEntranceId1",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropForeignKey(
                name: "FK_discrepancies_record_entrances_record_entrance_id",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_record_entrances_record_entrance_id",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_entrance_ducats_entrance_ducat_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropForeignKey(
                name: "FK_manifest_cancellations_record_entrances_record_entrance_id",
                schema: "public",
                table: "manifest_cancellations");

            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_record_entrances_record_entrance_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropForeignKey(
                name: "FK_step_execution_logs_record_entrances_record_entrance_id",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropForeignKey(
                name: "FK_step_execution_logs_workflow_step_definitions_workflow_step~",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_entrance_ducats_entrance_ducats_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_entrance_ducats_EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_record_entrances_record_entrance_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_receipts_record_entrances_record_entrance_id",
                schema: "public",
                table: "warehouse_receipts");

            migrationBuilder.DropTable(
                name: "customs_declaration_details",
                schema: "public");

            migrationBuilder.DropTable(
                name: "entrance_ducats",
                schema: "public");

            migrationBuilder.DropTable(
                name: "customs_declarations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "record_entrances",
                schema: "public");

            migrationBuilder.DropTable(
                name: "workflow_step_definitions",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_receipts_record_entrance_id",
                schema: "public",
                table: "warehouse_receipts");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_record_entrance_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropIndex(
                name: "IX_stocks_entrance_ducats_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_step_execution_logs_record_entrance_id",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropIndex(
                name: "IX_step_execution_logs_workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropIndex(
                name: "IX_reception_entrance_record_entrance_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropIndex(
                name: "IX_manifest_cancellations_record_entrance_id",
                schema: "public",
                table: "manifest_cancellations");

            migrationBuilder.DropIndex(
                name: "IX_ducat_registry_details_entrance_ducat_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropIndex(
                name: "IX_ducat_registry_record_entrance_id",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropIndex(
                name: "IX_discrepancies_entrance_ducats_id",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropIndex(
                name: "IX_discrepancies_EntranceDucatsId1",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropIndex(
                name: "IX_discrepancies_record_entrance_id",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropIndex(
                name: "IX_discrepancies_RecordEntranceId1",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "EntranceDucatsId1",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.DropColumn(
                name: "RecordEntranceId1",
                schema: "public",
                table: "discrepancies");

            migrationBuilder.RenameColumn(
                name: "deleted_evidence_urls",
                schema: "public",
                table: "reception_entrance",
                newName: "duca_numbers");

            migrationBuilder.AlterColumn<string>(
                name: "workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                schema: "public",
                table: "operational_orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "duca_number",
                schema: "public",
                table: "operational_orders",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_operational_orders_duca_number",
                schema: "public",
                table: "operational_orders",
                column: "duca_number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_operational_orders_duca_number",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "duca_number",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.RenameColumn(
                name: "duca_numbers",
                schema: "public",
                table: "reception_entrance",
                newName: "deleted_evidence_urls");

            migrationBuilder.AlterColumn<string>(
                name: "workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "record_entrance_id",
                schema: "public",
                table: "reception_entrance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                schema: "public",
                table: "operational_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EntranceDucatsId1",
                schema: "public",
                table: "discrepancies",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecordEntranceId1",
                schema: "public",
                table: "discrepancies",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "workflow_step_definitions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    execution_order = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_step_definitions", x => x.id);
                    table.UniqueConstraint("AK_workflow_step_definitions_code", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "record_entrances",
                schema: "public",
                columns: table => new
                {
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    current_step_code = table.Column<string>(type: "character varying(50)", nullable: false),
                    closed_at_date = table.Column<DateOnly>(type: "date", nullable: true),
                    closed_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_consolidated = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<int>(type: "record_entrance_status_enum", nullable: false, defaultValueSql: "queue")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_entrances", x => x.record_entrance_id);
                    table.ForeignKey(
                        name: "FK_record_entrances_workflow_step_definitions_current_step_code",
                        column: x => x.current_step_code,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customs_declarations",
                schema: "public",
                columns: table => new
                {
                    customs_declaration_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    service_order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    service_order_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    status = table.Column<int>(type: "duca_status_enum", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customs_declarations", x => x.customs_declaration_id);
                    table.ForeignKey(
                        name: "FK_customs_declarations_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customs_declarations_services_orders_service_order_id",
                        column: x => x.service_order_id,
                        principalSchema: "public",
                        principalTable: "services_orders",
                        principalColumn: "services_order_id");
                });

            migrationBuilder.CreateTable(
                name: "entrance_ducats",
                schema: "public",
                columns: table => new
                {
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    service_order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ducat_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    service_order_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    status = table.Column<int>(type: "duca_status_enum", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrance_ducats", x => x.entrance_ducat_id);
                    table.ForeignKey(
                        name: "FK_entrance_ducats_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entrance_ducats_services_orders_service_order_id",
                        column: x => x.service_order_id,
                        principalSchema: "public",
                        principalTable: "services_orders",
                        principalColumn: "services_order_id");
                });

            migrationBuilder.CreateTable(
                name: "customs_declaration_details",
                schema: "public",
                columns: table => new
                {
                    customs_declaration_detail_id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomsDeclarationId = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    customer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    packages = table.Column<int>(type: "integer", nullable: false),
                    product = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customs_declaration_details", x => x.customs_declaration_detail_id);
                    table.ForeignKey(
                        name: "FK_customs_declaration_details_customs_declarations_CustomsDec~",
                        column: x => x.CustomsDeclarationId,
                        principalSchema: "public",
                        principalTable: "customs_declarations",
                        principalColumn: "customs_declaration_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_record_entrance_id",
                schema: "public",
                table: "warehouse_receipts",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments",
                column: "EntranceDucatId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_record_entrance_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stocks_entrance_ducats_id",
                schema: "public",
                table: "stocks",
                column: "entrance_ducats_id");

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_record_entrance_id",
                schema: "public",
                table: "step_execution_logs",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_workflow_step_definition_code",
                schema: "public",
                table: "step_execution_logs",
                column: "workflow_step_definition_code");

            migrationBuilder.CreateIndex(
                name: "IX_reception_entrance_record_entrance_id",
                schema: "public",
                table: "reception_entrance",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_manifest_cancellations_record_entrance_id",
                schema: "public",
                table: "manifest_cancellations",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_entrance_ducat_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "entrance_ducat_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_record_entrance_id",
                schema: "public",
                table: "ducat_registry",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_entrance_ducats_id",
                schema: "public",
                table: "discrepancies",
                column: "entrance_ducats_id");

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_EntranceDucatsId1",
                schema: "public",
                table: "discrepancies",
                column: "EntranceDucatsId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_record_entrance_id",
                schema: "public",
                table: "discrepancies",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_RecordEntranceId1",
                schema: "public",
                table: "discrepancies",
                column: "RecordEntranceId1");

            migrationBuilder.CreateIndex(
                name: "IX_customs_declaration_details_CustomsDeclarationId",
                schema: "public",
                table: "customs_declaration_details",
                column: "CustomsDeclarationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customs_declarations_record_entrance_id",
                schema: "public",
                table: "customs_declarations",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customs_declarations_service_order_id",
                schema: "public",
                table: "customs_declarations",
                column: "service_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_entrance_ducats_record_entrance_id",
                schema: "public",
                table: "entrance_ducats",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_entrance_ducats_service_order_id",
                schema: "public",
                table: "entrance_ducats",
                column: "service_order_id");

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
                name: "FK_discrepancies_entrance_ducats_EntranceDucatsId1",
                schema: "public",
                table: "discrepancies",
                column: "EntranceDucatsId1",
                principalSchema: "public",
                principalTable: "entrance_ducats",
                principalColumn: "entrance_ducat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_discrepancies_entrance_ducats_entrance_ducats_id",
                schema: "public",
                table: "discrepancies",
                column: "entrance_ducats_id",
                principalSchema: "public",
                principalTable: "entrance_ducats",
                principalColumn: "entrance_ducat_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_discrepancies_record_entrances_RecordEntranceId1",
                schema: "public",
                table: "discrepancies",
                column: "RecordEntranceId1",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_discrepancies_record_entrances_record_entrance_id",
                schema: "public",
                table: "discrepancies",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_record_entrances_record_entrance_id",
                schema: "public",
                table: "ducat_registry",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_entrance_ducats_entrance_ducat_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "entrance_ducat_id",
                principalSchema: "public",
                principalTable: "entrance_ducats",
                principalColumn: "entrance_ducat_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_manifest_cancellations_record_entrances_record_entrance_id",
                schema: "public",
                table: "manifest_cancellations",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_record_entrances_record_entrance_id",
                schema: "public",
                table: "reception_entrance",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_step_execution_logs_record_entrances_record_entrance_id",
                schema: "public",
                table: "step_execution_logs",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id",
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

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_entrance_ducats_entrance_ducats_id",
                schema: "public",
                table: "stocks",
                column: "entrance_ducats_id",
                principalSchema: "public",
                principalTable: "entrance_ducats",
                principalColumn: "entrance_ducat_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_entrance_ducats_EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments",
                column: "EntranceDucatId",
                principalSchema: "public",
                principalTable: "entrance_ducats",
                principalColumn: "entrance_ducat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_record_entrances_record_entrance_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_receipts_record_entrances_record_entrance_id",
                schema: "public",
                table: "warehouse_receipts",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
