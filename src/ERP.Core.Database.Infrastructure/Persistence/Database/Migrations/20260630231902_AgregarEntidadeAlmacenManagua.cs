using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadeAlmacenManagua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropTable(
                name: "product",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "accumulated_ir_currently",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.DropColumn(
                name: "salary_earned_currently",
                schema: "public",
                table: "income_tax_accrual");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                schema: "public",
                table: "warehouses",
                newName: "branch_id");

            migrationBuilder.RenameColumn(
                name: "total_wight_capacity",
                schema: "public",
                table: "warehouses",
                newName: "unusable_area");

            migrationBuilder.RenameIndex(
                name: "ix_warehuose_id",
                schema: "public",
                table: "warehouses",
                newName: "ix_warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_BranchId",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_branch_id");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "service_orders",
                newName: "create_at");

            migrationBuilder.RenameColumn(
                name: "service_order_id",
                schema: "public",
                table: "service_orders",
                newName: "os_id");

            migrationBuilder.RenameIndex(
                name: "ix_service_order_id",
                schema: "public",
                table: "service_orders",
                newName: "ix_service_orders_id)");

            migrationBuilder.AddColumn<decimal>(
                name: "max_height",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "min_height",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "net_storage_area",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "parking_spaces_count",
                schema: "public",
                table: "warehouses",
                type: "numeric(5,1)",
                precision: 5,
                scale: 1,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "rampas_count",
                schema: "public",
                table: "warehouses",
                type: "numeric(5,1)",
                precision: 5,
                scale: 1,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "total_area",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                schema: "public",
                table: "service_orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CurrentDbContext_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<bool>(
                name: "IsCreatedFromPortal",
                schema: "public",
                table: "service_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "code",
                schema: "public",
                table: "service_orders",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "customer_id",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "observations",
                schema: "public",
                table: "service_orders",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "service_orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "dni_ruc",
                schema: "public",
                table: "customers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                schema: "public",
                table: "customers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InboundAppointments",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestCode = table.Column<int>(type: "integer", nullable: false),
                    GeneratedBy = table.Column<string>(type: "text", nullable: true),
                    QrCodeCreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InboundAppointments_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "public",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    product_sku = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    unit_of_measure = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_category_products_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    WarehousesId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones_managua", x => x.zones_managua_id);
                    table.ForeignKey(
                        name: "FK_zones_managua_warehouses_WarehousesId",
                        column: x => x.WarehousesId,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id");
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
                        name: "FK_stocks_managua_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "products",
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
                        name: "FK_discrepancies_managua_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "products",
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
                name: "IX_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                column: "parent_warehouse_id");

            migrationBuilder.CreateIndex(
                name: "ix_os_code",
                schema: "public",
                table: "service_orders",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_orders_branch_id",
                schema: "public",
                table: "service_orders",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_service_orders_customer_id",
                schema: "public",
                table: "service_orders",
                column: "customer_id");

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
                name: "IX_InboundAppointments_CustomerId",
                schema: "public",
                table: "InboundAppointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "ix_product_id",
                schema: "public",
                table: "products",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                schema: "public",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_customer_id",
                schema: "public",
                table: "products",
                column: "customer_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_zones_managua_WarehousesId",
                schema: "public",
                table: "zones_managua",
                column: "WarehousesId");

            migrationBuilder.AddForeignKey(
                name: "FK_service_orders_branches_branch_id",
                schema: "public",
                table: "service_orders",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_service_orders_customers_customer_id",
                schema: "public",
                table: "service_orders",
                column: "customer_id",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_branches_branch_id",
                schema: "public",
                table: "warehouses",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                column: "parent_warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_service_orders_branches_branch_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_service_orders_customers_customer_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_branches_branch_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses");

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
                name: "InboundAppointments",
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
                name: "products",
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

            migrationBuilder.DropIndex(
                name: "IX_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropIndex(
                name: "ix_os_code",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropIndex(
                name: "IX_service_orders_branch_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropIndex(
                name: "IX_service_orders_customer_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "max_height",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "min_height",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "net_storage_area",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "parent_warehouse_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "parking_spaces_count",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "rampas_count",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "total_area",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "IsCreatedFromPortal",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "branch_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "code",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "customer_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "observations",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                schema: "public",
                table: "customers");

            migrationBuilder.RenameColumn(
                name: "branch_id",
                schema: "public",
                table: "warehouses",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "unusable_area",
                schema: "public",
                table: "warehouses",
                newName: "total_wight_capacity");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_branch_id",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_BranchId");

            migrationBuilder.RenameIndex(
                name: "ix_warehouse_id",
                schema: "public",
                table: "warehouses",
                newName: "ix_warehuose_id");

            migrationBuilder.RenameColumn(
                name: "create_at",
                schema: "public",
                table: "service_orders",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "os_id",
                schema: "public",
                table: "service_orders",
                newName: "service_order_id");

            migrationBuilder.RenameIndex(
                name: "ix_service_orders_id)",
                schema: "public",
                table: "service_orders",
                newName: "ix_service_order_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "service_orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CurrentDbContext_TIMESTAMP");

            migrationBuilder.AddColumn<decimal>(
                name: "accumulated_ir_currently",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "salary_earned_currently",
                schema: "public",
                table: "income_tax_accrual",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "dni_ruc",
                schema: "public",
                table: "customers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "product",
                schema: "public",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    product_sku = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    unit_of_measure = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_product_category_products_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                schema: "public",
                table: "product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_customer_id",
                schema: "public",
                table: "product",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_id",
                schema: "public",
                table: "product",
                column: "product_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
