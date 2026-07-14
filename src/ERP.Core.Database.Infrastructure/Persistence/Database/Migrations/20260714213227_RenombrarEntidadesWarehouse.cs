using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarEntidadesWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_record_entrances_managua_record_entrance~",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropTable(
                name: "discrepancies_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry_details_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "manifest_cancellations_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "step_execution_logs_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "stocks_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_crew_assignments_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_machinery_assignments_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_receipts_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "entrance_ducats_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_details_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_assignments_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "racks_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "record_entrances_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "zones_managua",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "record_entrance_managua_id",
                schema: "public",
                table: "reception_entrance",
                newName: "record_entrance_id");

            migrationBuilder.RenameIndex(
                name: "IX_reception_entrance_record_entrance_managua_id",
                schema: "public",
                table: "reception_entrance",
                newName: "IX_reception_entrance_record_entrance_id");

            migrationBuilder.CreateTable(
                name: "record_entrances",
                schema: "public",
                columns: table => new
                {
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    service_order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_step_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "record_entrance_status_enum", nullable: false),
                    closed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_consolidated = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_entrances", x => x.record_entrance_id);
                    table.ForeignKey(
                        name: "FK_record_entrances_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_record_entrances_workflow_step_definitions_current_step_id",
                        column: x => x.current_step_id,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sections",
                schema: "public",
                columns: table => new
                {
                    section_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    section_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    width_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    length_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    heigth_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    total_colume_capacity_m3 = table.Column<decimal>(type: "numeric(12,3)", precision: 12, scale: 3, nullable: false),
                    max_weight_capacity_kg = table.Column<decimal>(type: "numeric(14,2)", precision: 14, scale: 2, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sections", x => x.section_id);
                    table.ForeignKey(
                        name: "FK_sections_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry",
                schema: "public",
                columns: table => new
                {
                    ducat_registtry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    registry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    trailer_identifier = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    empresa = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    registered_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    general_observations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    is_in_transit = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry", x => x.ducat_registtry_id);
                    table.ForeignKey(
                        name: "FK_ducat_registry_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entrance_ducats",
                schema: "public",
                columns: table => new
                {
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ducat_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                });

            migrationBuilder.CreateTable(
                name: "manifest_cancellations",
                schema: "public",
                columns: table => new
                {
                    manifest_cancellation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    service_orders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    manifest_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    container_count = table.Column<int>(type: "integer", nullable: false),
                    container_dimension = table.Column<string>(type: "text", nullable: false),
                    personal_type = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    customs_officer_signature = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    warehouse_chief_signature = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manifest_cancellations", x => x.manifest_cancellation_id);
                    table.ForeignKey(
                        name: "FK_manifest_cancellations_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_manifest_cancellations_service_orders_service_orders_id",
                        column: x => x.service_orders_id,
                        principalSchema: "public",
                        principalTable: "service_orders",
                        principalColumn: "service_order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "step_execution_logs",
                schema: "public",
                columns: table => new
                {
                    step_execution_logs_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    workflow_step_definition_id = table.Column<int>(type: "integer", nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    processed_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_step_execution_logs", x => x.step_execution_logs_id);
                    table.ForeignKey(
                        name: "FK_step_execution_logs_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_step_execution_logs_workflow_step_definitions_workflow_step~",
                        column: x => x.workflow_step_definition_id,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_receipts",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    receipt_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    resa_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    customs_cif_value = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    customs_brokerage = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    receipt_creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    receipt_cancellation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_receipts", x => x.id);
                    table.ForeignKey(
                        name: "FK_warehouse_receipts_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "racks",
                schema: "public",
                columns: table => new
                {
                    racks_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    section_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    row_number = table.Column<int>(type: "integer", nullable: false),
                    level_number = table.Column<int>(type: "integer", nullable: false),
                    cost_per_position = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    is_available = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    max_weight_kg = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    max_height_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racks", x => x.racks_id);
                    table.ForeignKey(
                        name: "FK_racks_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "discrepancies",
                schema: "public",
                columns: table => new
                {
                    discrepancy_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    discrepancy_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    declared_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    found_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    customs_letter_reference = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    is_damage = table.Column<bool>(type: "boolean", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entrance_ducats_id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntranceDucatsId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    RecordEntranceId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discrepancies", x => x.discrepancy_id);
                    table.ForeignKey(
                        name: "FK_discrepancies_entrance_ducats_EntranceDucatsId1",
                        column: x => x.EntranceDucatsId1,
                        principalSchema: "public",
                        principalTable: "entrance_ducats",
                        principalColumn: "entrance_ducat_id");
                    table.ForeignKey(
                        name: "FK_discrepancies_entrance_ducats_entrance_ducats_id",
                        column: x => x.entrance_ducats_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_discrepancies_record_entrances_RecordEntranceId1",
                        column: x => x.RecordEntranceId1,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id");
                    table.ForeignKey(
                        name: "FK_discrepancies_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry_details",
                schema: "public",
                columns: table => new
                {
                    ducat_registry_detail_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_bultos = table.Column<int>(type: "integer", nullable: false),
                    total_weight = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    product_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    remitente = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    destination_area_observation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry_details", x => x.ducat_registry_detail_id);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_category_products_category_product_id",
                        column: x => x.category_product_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_ducat_registry_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "ducat_registry",
                        principalColumn: "ducat_registtry_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_entrance_ducats_entrance_ducat_id",
                        column: x => x.entrance_ducat_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                schema: "public",
                columns: table => new
                {
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entrance_ducats_id = table.Column<Guid>(type: "uuid", nullable: false),
                    section_id = table.Column<Guid>(type: "uuid", nullable: false),
                    racks_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_bultos = table.Column<int>(type: "integer", nullable: false),
                    current_weight_kg = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    stored_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    row_version = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.stock_id);
                    table.ForeignKey(
                        name: "FK_stocks_category_products_category_product_id",
                        column: x => x.category_product_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_entrance_ducats_entrance_ducats_id",
                        column: x => x.entrance_ducats_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_racks_racks_id",
                        column: x => x.racks_id,
                        principalSchema: "public",
                        principalTable: "racks",
                        principalColumn: "racks_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_assignments",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    section_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    assigned_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_racks_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks",
                        principalColumn: "racks_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_details",
                schema: "public",
                columns: table => new
                {
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_assignments_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unloading_start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    unloading_end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    warehouse_chief_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    prepared_pallets = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_details", x => x.unloading_details_id);
                    table.ForeignKey(
                        name: "FK_unloading_details_record_entrances_record_entrance_id",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances",
                        principalColumn: "record_entrance_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_unloading_details_warehouse_assignments_warehouse_assignmen~",
                        column: x => x.warehouse_assignments_id,
                        principalSchema: "public",
                        principalTable: "warehouse_assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_crew_assignments",
                schema: "public",
                columns: table => new
                {
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    persona_count = table.Column<int>(type: "integer", nullable: false),
                    tercerizada = table.Column<bool>(type: "boolean", nullable: false),
                    UnloadingDetailsId = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_crew_assignments", x => x.unloading_details_id);
                    table.ForeignKey(
                        name: "FK_unloading_crew_assignments_unloading_details_UnloadingDetai~",
                        column: x => x.UnloadingDetailsId,
                        principalSchema: "public",
                        principalTable: "unloading_details",
                        principalColumn: "unloading_details_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_machinery_assignments",
                schema: "public",
                columns: table => new
                {
                    unloading_machinery_assignment_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false),
                    machinery_code = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: false),
                    machinery_type = table.Column<Guid>(type: "uuid", maxLength: 150, nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    assigned_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_machinery_assignments", x => x.unloading_machinery_assignment_id);
                    table.ForeignKey(
                        name: "FK_unloading_machinery_assignments_unloading_details_unloading~",
                        column: x => x.unloading_details_id,
                        principalSchema: "public",
                        principalTable: "unloading_details",
                        principalColumn: "unloading_details_id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "ix_discrepancy_id",
                schema: "public",
                table: "discrepancies",
                column: "discrepancy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_record_entrance_id",
                schema: "public",
                table: "ducat_registry",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_category_product_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "category_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_entrance_ducat_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "entrance_ducat_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_record_entrance_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_entrance_ducats_record_entrance_id",
                schema: "public",
                table: "entrance_ducats",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_manifest_cancellations_record_entrance_id",
                schema: "public",
                table: "manifest_cancellations",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_manifest_cancellations_service_orders_id",
                schema: "public",
                table: "manifest_cancellations",
                column: "service_orders_id");

            migrationBuilder.CreateIndex(
                name: "IX_racks_section_id",
                schema: "public",
                table: "racks",
                column: "section_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_sections_warehouse_id",
                schema: "public",
                table: "sections",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_record_entrance_id",
                schema: "public",
                table: "step_execution_logs",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_workflow_step_definition_id",
                schema: "public",
                table: "step_execution_logs",
                column: "workflow_step_definition_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_category_product_id",
                schema: "public",
                table: "stocks",
                column: "category_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_entrance_ducats_id",
                schema: "public",
                table: "stocks",
                column: "entrance_ducats_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_racks_id",
                schema: "public",
                table: "stocks",
                column: "racks_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_section_id",
                schema: "public",
                table: "stocks",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_crew_assignments_UnloadingDetailsId",
                schema: "public",
                table: "unloading_crew_assignments",
                column: "UnloadingDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_details_record_entrance_id",
                schema: "public",
                table: "unloading_details",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unloading_details_warehouse_assignments_id",
                schema: "public",
                table: "unloading_details",
                column: "warehouse_assignments_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unloading_machinery_assignments_unloading_details_id",
                schema: "public",
                table: "unloading_machinery_assignments",
                column: "unloading_details_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_rack_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "rack_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_record_entrance_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_section_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_warehouse_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_receipt_number",
                schema: "public",
                table: "warehouse_receipts",
                column: "receipt_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_record_entrance_id",
                schema: "public",
                table: "warehouse_receipts",
                column: "record_entrance_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_record_entrances_record_entrance_id",
                schema: "public",
                table: "reception_entrance",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_record_entrances_record_entrance_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropTable(
                name: "discrepancies",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry_details",
                schema: "public");

            migrationBuilder.DropTable(
                name: "manifest_cancellations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "step_execution_logs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "stocks",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_crew_assignments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_machinery_assignments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_receipts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry",
                schema: "public");

            migrationBuilder.DropTable(
                name: "entrance_ducats",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_details",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_assignments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "racks",
                schema: "public");

            migrationBuilder.DropTable(
                name: "record_entrances",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sections",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "reception_entrance",
                newName: "record_entrance_managua_id");

            migrationBuilder.RenameIndex(
                name: "IX_reception_entrance_record_entrance_id",
                schema: "public",
                table: "reception_entrance",
                newName: "IX_reception_entrance_record_entrance_managua_id");

            migrationBuilder.CreateTable(
                name: "record_entrances_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    current_step_id = table.Column<int>(type: "integer", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    closed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_consolidated = table.Column<bool>(type: "boolean", nullable: false),
                    service_order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<int>(type: "record_entrance_status_enum", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_entrances_managua", x => x.record_entrance_managua_id);
                    table.ForeignKey(
                        name: "FK_record_entrances_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_record_entrances_managua_workflow_step_definitions_current_~",
                        column: x => x.current_step_id,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zones_managua",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    heigth_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    length_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    max_weight_capacity_kg = table.Column<decimal>(type: "numeric(14,2)", precision: 14, scale: 2, nullable: false),
                    zone_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    total_colume_capacity_m3 = table.Column<decimal>(type: "numeric(12,3)", precision: 12, scale: 3, nullable: false),
                    width_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones_managua", x => x.id);
                    table.ForeignKey(
                        name: "FK_zones_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry_managua",
                schema: "public",
                columns: table => new
                {
                    ducat_registtry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    empresa = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    general_observations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    is_in_transit = table.Column<bool>(type: "boolean", nullable: false),
                    registered_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    registry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    trailer_identifier = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry_managua", x => x.ducat_registtry_id);
                    table.ForeignKey(
                        name: "FK_ducat_registry_managua_record_entrances_managua_record_entr~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entrance_ducats_managua",
                schema: "public",
                columns: table => new
                {
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ducat_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrance_ducats_managua", x => x.entrance_ducat_id);
                    table.ForeignKey(
                        name: "FK_entrance_ducats_managua_record_entrances_managua_record_ent~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "manifest_cancellations_managua",
                schema: "public",
                columns: table => new
                {
                    manifest_cancellation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    service_orders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    container_count = table.Column<int>(type: "integer", nullable: false),
                    container_dimension = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    customs_officer_signature = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    manifest_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    personal_type = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    warehouse_chief_signature = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manifest_cancellations_managua", x => x.manifest_cancellation_id);
                    table.ForeignKey(
                        name: "FK_manifest_cancellations_managua_record_entrances_managua_rec~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_manifest_cancellations_managua_service_orders_service_order~",
                        column: x => x.service_orders_id,
                        principalSchema: "public",
                        principalTable: "service_orders",
                        principalColumn: "service_order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "step_execution_logs_managua",
                schema: "public",
                columns: table => new
                {
                    step_execution_logs_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    workflow_step_definition_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    processed_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_step_execution_logs_managua", x => x.step_execution_logs_id);
                    table.ForeignKey(
                        name: "FK_step_execution_logs_managua_record_entrances_managua_record~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_step_execution_logs_managua_workflow_step_definitions_workf~",
                        column: x => x.workflow_step_definition_id,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_receipts_managua",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    customs_brokerage = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    customs_cif_value = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    receipt_cancellation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    receipt_creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    receipt_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    resa_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_receipts_managua", x => x.id);
                    table.ForeignKey(
                        name: "FK_warehouse_receipts_managua_record_entrances_managua_record_~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "racks_managua",
                schema: "public",
                columns: table => new
                {
                    racks_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    zone_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cost_per_position = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_available = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    level_number = table.Column<int>(type: "integer", nullable: false),
                    max_height_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    max_weight_kg = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    row_number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racks_managua", x => x.racks_id);
                    table.ForeignKey(
                        name: "FK_racks_managua_zones_managua_zone_id",
                        column: x => x.zone_id,
                        principalSchema: "public",
                        principalTable: "zones_managua",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "discrepancies_managua",
                schema: "public",
                columns: table => new
                {
                    discrepancy_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    entrance_ducats_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    customs_letter_reference = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    declared_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    discrepancy_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EntranceDucatsManaguaId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    found_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    is_damage = table.Column<bool>(type: "boolean", nullable: false),
                    RecordEntranceManaguaId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discrepancies_managua", x => x.discrepancy_id);
                    table.ForeignKey(
                        name: "FK_discrepancies_managua_entrance_ducats_managua_EntranceDucat~",
                        column: x => x.EntranceDucatsManaguaId1,
                        principalSchema: "public",
                        principalTable: "entrance_ducats_managua",
                        principalColumn: "entrance_ducat_id");
                    table.ForeignKey(
                        name: "FK_discrepancies_managua_entrance_ducats_managua_entrance_duca~",
                        column: x => x.entrance_ducats_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats_managua",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_discrepancies_managua_record_entrances_managua_RecordEntran~",
                        column: x => x.RecordEntranceManaguaId1,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id");
                    table.ForeignKey(
                        name: "FK_discrepancies_managua_record_entrances_managua_record_entra~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry_details_managua",
                schema: "public",
                columns: table => new
                {
                    ducat_registry_detail_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    category_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entrance_ducat_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    destination_area_observation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    product_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    remitente = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    total_bultos = table.Column<int>(type: "integer", nullable: false),
                    total_weight = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry_details_managua", x => x.ducat_registry_detail_id);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_managua_category_products_category_p~",
                        column: x => x.category_product_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_managua_ducat_registry_managua_recor~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "ducat_registry_managua",
                        principalColumn: "ducat_registtry_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_managua_entrance_ducats_managua_entr~",
                        column: x => x.entrance_ducat_managua_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats_managua",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stocks_managua",
                schema: "public",
                columns: table => new
                {
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    category_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entrance_ducats_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    racks_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    zone_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    current_bultos = table.Column<int>(type: "integer", nullable: false),
                    current_weight_kg = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    row_version = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    stored_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks_managua", x => x.stock_id);
                    table.ForeignKey(
                        name: "FK_stocks_managua_category_products_category_product_id",
                        column: x => x.category_product_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_managua_entrance_ducats_managua_entrance_ducats_mana~",
                        column: x => x.entrance_ducats_managua_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats_managua",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_managua_racks_managua_racks_managua_id",
                        column: x => x.racks_managua_id,
                        principalSchema: "public",
                        principalTable: "racks_managua",
                        principalColumn: "racks_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_managua_zones_managua_zone_managua_id",
                        column: x => x.zone_managua_id,
                        principalSchema: "public",
                        principalTable: "zones_managua",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_assignments_managua",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    zone_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    assigned_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_assignments_managua", x => x.id);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_racks_managua_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks_managua",
                        principalColumn: "racks_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_record_entrances_managua_reco~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_zones_managua_zone_id",
                        column: x => x.zone_id,
                        principalSchema: "public",
                        principalTable: "zones_managua",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_details_managua",
                schema: "public",
                columns: table => new
                {
                    unloading_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_assignments_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    prepared_pallets = table.Column<decimal>(type: "numeric(2,0)", precision: 2, nullable: false),
                    unloading_end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    unloading_start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    warehouse_chief_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_details_managua", x => x.unloading_details_managua_id);
                    table.ForeignKey(
                        name: "FK_unloading_details_managua_record_entrances_managua_record_e~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_unloading_details_managua_warehouse_assignments_managua_war~",
                        column: x => x.warehouse_assignments_managua_id,
                        principalSchema: "public",
                        principalTable: "warehouse_assignments_managua",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_crew_assignments_managua",
                schema: "public",
                columns: table => new
                {
                    unloading_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UnloadingDetailsManaguaId = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    persona_count = table.Column<int>(type: "integer", nullable: false),
                    tercerizada = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_crew_assignments_managua", x => x.unloading_details_managua_id);
                    table.ForeignKey(
                        name: "FK_unloading_crew_assignments_managua_unloading_details_managu~",
                        column: x => x.UnloadingDetailsManaguaId,
                        principalSchema: "public",
                        principalTable: "unloading_details_managua",
                        principalColumn: "unloading_details_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_machinery_assignments_managua",
                schema: "public",
                columns: table => new
                {
                    unloading_machinery_assignment_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    unloading_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    machinery_code = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: false),
                    machinery_type = table.Column<Guid>(type: "uuid", maxLength: 150, nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_machinery_assignments_managua", x => x.unloading_machinery_assignment_id);
                    table.ForeignKey(
                        name: "FK_unloading_machinery_assignments_managua_unloading_details_m~",
                        column: x => x.unloading_details_managua_id,
                        principalSchema: "public",
                        principalTable: "unloading_details_managua",
                        principalColumn: "unloading_details_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_managua_entrance_ducats_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "entrance_ducats_id");

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_managua_EntranceDucatsManaguaId1",
                schema: "public",
                table: "discrepancies_managua",
                column: "EntranceDucatsManaguaId1",
                unique: true);

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
                name: "ix_discrepancy_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "discrepancy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_managua_category_product_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "category_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_managua_entrance_ducat_managua_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "entrance_ducat_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_managua_record_entrance_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_managua_record_entrance_managua_id",
                schema: "public",
                table: "ducat_registry_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entrance_ducats_managua_record_entrance_managua_id",
                schema: "public",
                table: "entrance_ducats_managua",
                column: "record_entrance_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_manifest_cancellations_managua_record_entrance_managua_id",
                schema: "public",
                table: "manifest_cancellations_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_manifest_cancellations_managua_service_orders_id",
                schema: "public",
                table: "manifest_cancellations_managua",
                column: "service_orders_id");

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
                name: "IX_record_entrances_managua_warehouse_id",
                schema: "public",
                table: "record_entrances_managua",
                column: "warehouse_id");

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
                name: "IX_stocks_managua_category_product_id",
                schema: "public",
                table: "stocks_managua",
                column: "category_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_entrance_ducats_managua_id",
                schema: "public",
                table: "stocks_managua",
                column: "entrance_ducats_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_racks_managua_id",
                schema: "public",
                table: "stocks_managua",
                column: "racks_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_zone_managua_id",
                schema: "public",
                table: "stocks_managua",
                column: "zone_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_crew_assignments_managua_UnloadingDetailsManaguaId",
                schema: "public",
                table: "unloading_crew_assignments_managua",
                column: "UnloadingDetailsManaguaId");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_details_managua_record_entrance_managua_id",
                schema: "public",
                table: "unloading_details_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unloading_details_managua_warehouse_assignments_managua_id",
                schema: "public",
                table: "unloading_details_managua",
                column: "warehouse_assignments_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unloading_machinery_assignments_managua_unloading_details_m~",
                schema: "public",
                table: "unloading_machinery_assignments_managua",
                column: "unloading_details_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_rack_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "rack_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_record_entrance_managua_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_warehouse_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_zone_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "zone_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_managua_receipt_number",
                schema: "public",
                table: "warehouse_receipts_managua",
                column: "receipt_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_managua_record_entrance_managua_id",
                schema: "public",
                table: "warehouse_receipts_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_zones_managua_warehouse_id",
                schema: "public",
                table: "zones_managua",
                column: "warehouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_record_entrances_managua_record_entrance~",
                schema: "public",
                table: "reception_entrance",
                column: "record_entrance_managua_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
