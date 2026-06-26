using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class TablasWarehouseManagua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workflow_step_definitions",
                schema: "public",
                columns: table => new
                {
                    workflow_step_definition_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    execution_order = table.Column<int>(type: "integer", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_step_definitions", x => x.workflow_step_definition_id);
                });

            migrationBuilder.CreateTable(
                name: "zones_managua",
                schema: "public",
                columns: table => new
                {
                    zones_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    zone_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones_managua", x => x.zones_managua_id);
                    table.ForeignKey(
                        name: "FK_zones_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "racks_managua",
                schema: "public",
                columns: table => new
                {
                    racks_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    zone_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    row_number = table.Column<int>(type: "integer", nullable: false),
                    level_number = table.Column<int>(type: "integer", nullable: false),
                    cost_per_position = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    is_occupied = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racks_managua", x => x.racks_managua_id);
                    table.ForeignKey(
                        name: "FK_racks_managua_zones_managua_zone_id",
                        column: x => x.zone_id,
                        principalSchema: "public",
                        principalTable: "zones_managua",
                        principalColumn: "zones_managua_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stocks_managua",
                schema: "public",
                columns: table => new
                {
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    stored_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks_managua", x => x.stock_id);
                    table.ForeignKey(
                        name: "FK_stocks_managua_product_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stocks_managua_racks_managua_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks_managua",
                        principalColumn: "racks_managua_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discrepancies_managua",
                schema: "public",
                columns: table => new
                {
                    discrepancy_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    discrepancy_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    declared_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    found_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    customs_letter_reference = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RecordEntranceManaguaId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discrepancies_managua", x => x.discrepancy_id);
                    table.ForeignKey(
                        name: "FK_discrepancies_managua_product_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry_details_managua",
                schema: "public",
                columns: table => new
                {
                    ducat_registry_detail_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ducat_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    package_count = table.Column<int>(type: "integer", nullable: false),
                    total_weight = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    product_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    sender_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    destination_area_observation = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry_details_managua", x => x.ducat_registry_detail_id);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry_headers_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    registry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    entry_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    trailer_identifier = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    empresa = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    transportista = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    aduana = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    consignee = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry_headers_managua", x => x.record_entrance_id);
                });

            migrationBuilder.CreateTable(
                name: "entrance_ducats_managua",
                schema: "public",
                columns: table => new
                {
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ducat_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrance_ducats_managua", x => x.entrance_ducat_id);
                });

            migrationBuilder.CreateTable(
                name: "manifest_cancellations_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    manifest_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    container_count = table.Column<int>(type: "integer", nullable: false),
                    container_dimension = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    personnel_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    customs_officer_signature = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    warehouse_chief_signature = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manifest_cancellations_managua", x => x.record_entrance_id);
                });

            migrationBuilder.CreateTable(
                name: "reception_details_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    country_of_origin = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    aduana = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    entry_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    plate_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    trailer_chassis = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    driver_license = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    transportista = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    medium = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    driver_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    consignee = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    seal_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception_details_managua", x => x.record_entrance_id);
                });

            migrationBuilder.CreateTable(
                name: "record_entrances_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    movement_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_step_id = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    closed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UnloadingDetailsRecordEntranceManaguaId = table.Column<Guid>(type: "uuid", nullable: true),
                    ManifestCancellationRecordEntranceManaguaId = table.Column<Guid>(type: "uuid", nullable: true),
                    WarehouseReceiptRecordEntranceManaguaId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_entrances_managua", x => x.record_entrance_managua_id);
                    table.ForeignKey(
                        name: "FK_record_entrances_managua_manifest_cancellations_managua_Man~",
                        column: x => x.ManifestCancellationRecordEntranceManaguaId,
                        principalSchema: "public",
                        principalTable: "manifest_cancellations_managua",
                        principalColumn: "record_entrance_id");
                    table.ForeignKey(
                        name: "FK_record_entrances_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_record_entrances_managua_workflow_step_definitions_current_~",
                        column: x => x.current_step_id,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "workflow_step_definition_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "step_execution_logs_managua",
                schema: "public",
                columns: table => new
                {
                    log_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    workflow_step_definition_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_step_execution_logs_managua", x => x.log_id);
                    table.ForeignKey(
                        name: "FK_step_execution_logs_managua_record_entrances_managua_record~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_step_execution_logs_managua_workflow_step_definitions_workf~",
                        column: x => x.workflow_step_definition_id,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "workflow_step_definition_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unloading_details_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unloading_start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    unloading_end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    warehouse_chief_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    prepared_pallets_per_hour = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_details_managua", x => x.record_entrance_id);
                    table.ForeignKey(
                        name: "FK_unloading_details_managua_record_entrances_managua_record_e~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_assignments_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    zone_id = table.Column<Guid>(type: "uuid", nullable: true),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_assignments_managua", x => x.record_entrance_id);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_racks_managua_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks_managua",
                        principalColumn: "racks_managua_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_record_entrances_managua_reco~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_receipts_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    receipt_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    resa_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    customs_cif_value = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    customs_brokerage = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    receipt_creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    receipt_cancellation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_receipts_managua", x => x.record_entrance_id);
                    table.ForeignKey(
                        name: "FK_warehouse_receipts_managua_record_entrances_managua_record_~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_managua_product_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_managua_record_entrance_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_managua_RecordEntranceManaguaId1",
                schema: "public",
                table: "discrepancies_managua",
                column: "RecordEntranceManaguaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_managua_record_entrance_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_entrance_ducats_managua_record_entrance_managua_id",
                schema: "public",
                table: "entrance_ducats_managua",
                column: "record_entrance_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_racks_managua_zone_id",
                schema: "public",
                table: "racks_managua",
                column: "zone_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_current_step_id",
                schema: "public",
                table: "record_entrances_managua",
                column: "current_step_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_ManifestCancellationRecordEntrance~",
                schema: "public",
                table: "record_entrances_managua",
                column: "ManifestCancellationRecordEntranceManaguaId");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_movement_number",
                schema: "public",
                table: "record_entrances_managua",
                column: "movement_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_UnloadingDetailsRecordEntranceMana~",
                schema: "public",
                table: "record_entrances_managua",
                column: "UnloadingDetailsRecordEntranceManaguaId");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_warehouse_id",
                schema: "public",
                table: "record_entrances_managua",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_WarehouseReceiptRecordEntranceMana~",
                schema: "public",
                table: "record_entrances_managua",
                column: "WarehouseReceiptRecordEntranceManaguaId");

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_managua_record_entrance_id",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_managua_workflow_step_definition_id",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "workflow_step_definition_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_product_id",
                schema: "public",
                table: "stocks_managua",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_rack_id",
                schema: "public",
                table: "stocks_managua",
                column: "rack_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_rack_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "rack_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_warehouse_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_managua_receipt_number",
                schema: "public",
                table: "warehouse_receipts_managua",
                column: "receipt_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_zones_managua_warehouse_id_code",
                schema: "public",
                table: "zones_managua",
                columns: new[] { "warehouse_id", "code" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_discrepancies_managua_record_entrances_managua_RecordEntran~",
                schema: "public",
                table: "discrepancies_managua",
                column: "RecordEntranceManaguaId1",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id");

            migrationBuilder.AddForeignKey(
                name: "FK_discrepancies_managua_record_entrances_managua_record_entra~",
                schema: "public",
                table: "discrepancies_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_managua_ducat_registry_headers_manag~",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "ducat_registry_headers_managua",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_headers_managua_record_entrances_managua_rec~",
                schema: "public",
                table: "ducat_registry_headers_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entrance_ducats_managua_record_entrances_managua_record_ent~",
                schema: "public",
                table: "entrance_ducats_managua",
                column: "record_entrance_managua_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_manifest_cancellations_managua_record_entrances_managua_rec~",
                schema: "public",
                table: "manifest_cancellations_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_details_managua_record_entrances_managua_record_e~",
                schema: "public",
                table: "reception_details_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_managua_unloading_details_managua_Unloadin~",
                schema: "public",
                table: "record_entrances_managua",
                column: "UnloadingDetailsRecordEntranceManaguaId",
                principalSchema: "public",
                principalTable: "unloading_details_managua",
                principalColumn: "record_entrance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_managua_warehouse_receipts_managua_Warehou~",
                schema: "public",
                table: "record_entrances_managua",
                column: "WarehouseReceiptRecordEntranceManaguaId",
                principalSchema: "public",
                principalTable: "warehouse_receipts_managua",
                principalColumn: "record_entrance_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_manifest_cancellations_managua_record_entrances_managua_rec~",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_unloading_details_managua_record_entrances_managua_record_e~",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_receipts_managua_record_entrances_managua_record_~",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropTable(
                name: "discrepancies_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry_details_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "entrance_ducats_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reception_details_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "step_execution_logs_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "stocks_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_assignments_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry_headers_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "racks_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "zones_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "record_entrances_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "manifest_cancellations_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_details_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_receipts_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "workflow_step_definitions",
                schema: "public");
        }
    }
}
