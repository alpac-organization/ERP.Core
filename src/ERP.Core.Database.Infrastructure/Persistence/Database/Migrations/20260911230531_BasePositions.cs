using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class BasePositions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_placements_tramo_positions_lot_position_id",
                schema: "public",
                table: "stock_placements");

            migrationBuilder.DropForeignKey(
                name: "FK_tramo_positions_lots_tramo_id",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_rack_positions_rack_positions_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_tramo_positions_lots_positions_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropTable(
                name: "section_overflow_capacities",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_rack_positions_rack_id_position_code",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropIndex(
                name: "ix_rack_positions_rack_id_position_number",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tramo_positions",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropIndex(
                name: "ix_tramo_positions_tramo_id_position_code",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "block_reason",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "is_blocked",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "is_occupied",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "is_reserved",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "position_code",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "position_number",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "allows_stacking",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "block_reason",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "column_number",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "is_blocked",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "is_occupied",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "is_reserved",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "position_code",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "row_number",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.RenameTable(
                name: "tramo_positions",
                schema: "public",
                newName: "lots_positions",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "rack_position_id",
                schema: "public",
                table: "rack_positions",
                newName: "position_id");

            migrationBuilder.RenameColumn(
                name: "tramo_id",
                schema: "public",
                table: "lots_positions",
                newName: "lot_id");

            migrationBuilder.RenameColumn(
                name: "tramo_position_id",
                schema: "public",
                table: "lots_positions",
                newName: "position_id");

            migrationBuilder.RenameIndex(
                name: "ix_tramo_positions_tramo_id",
                schema: "public",
                table: "lots_positions",
                newName: "ix_lots_positions_lot_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .Annotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .Annotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .Annotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .Annotation("Npgsql:Enum:public.duca_type_enum", "duca_f,duca_d,duca_t")
                .Annotation("Npgsql:Enum:public.fuel_type_enum", "electric,lpg,diesel,gasoline,manual,other")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .Annotation("Npgsql:Enum:public.machinery_type_enum", "forklift,crane,pallet_jack,conveyor,other")
                .Annotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .Annotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .Annotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .Annotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .Annotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .Annotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.reassignment_session_status_enum", "open,paused,closed")
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .Annotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .Annotation("Npgsql:Enum:public.unloading_status_enum", "pending,in_progress,paused,completed,cancelled")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .Annotation("Npgsql:Enum:public.warehouse_task_event_type_enum", "started,paused,resumed,completed")
                .Annotation("Npgsql:Enum:public.warehouse_task_status_enum", "in_progress,paused,completed")
                .Annotation("Npgsql:Enum:public.warehouse_task_type_enum", "unloading,reassignment,dispatch")
                .Annotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .OldAnnotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .OldAnnotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .OldAnnotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .OldAnnotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .OldAnnotation("Npgsql:Enum:public.duca_type_enum", "duca_f,duca_d,duca_t")
                .OldAnnotation("Npgsql:Enum:public.fuel_type_enum", "electric,lpg,diesel,gasoline,manual,other")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .OldAnnotation("Npgsql:Enum:public.machinery_type_enum", "forklift,crane,pallet_jack,conveyor,other")
                .OldAnnotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .OldAnnotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .OldAnnotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .OldAnnotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.reassignment_session_status_enum", "open,paused,closed")
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .OldAnnotation("Npgsql:Enum:public.unloading_status_enum", "pending,in_progress,paused,completed,cancelled")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_task_event_type_enum", "started,paused,resumed,completed")
                .OldAnnotation("Npgsql:Enum:public.warehouse_task_status_enum", "in_progress,paused,completed")
                .OldAnnotation("Npgsql:Enum:public.warehouse_task_type_enum", "unloading,reassignment,dispatch")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AddColumn<Guid>(
                name: "SectionPositionId",
                schema: "public",
                table: "stock_placements",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "allows_storage_aisle",
                schema: "public",
                table: "sections",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "enabled_by_user_name",
                schema: "public",
                table: "sections",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "enabled_date",
                schema: "public",
                table: "sections",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "enabled_time",
                schema: "public",
                table: "sections",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_storage_enable_aisle",
                schema: "public",
                table: "sections",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "max_pallets_per_level_aisle",
                schema: "public",
                table: "sections",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_lots_positions",
                schema: "public",
                table: "lots_positions",
                column: "position_id");

            migrationBuilder.CreateTable(
                name: "base_posiions_pallets",
                schema: "public",
                columns: table => new
                {
                    position_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    row = table.Column<int>(type: "integer", nullable: false),
                    column = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "rack_status_enum", nullable: false, defaultValueSql: "'available'::rack_status_enum"),
                    allows_stocking = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    observations = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_posiions_pallets", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "section_positions",
                schema: "public",
                columns: table => new
                {
                    position_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    section_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section_positions", x => x.position_id);
                    table.ForeignKey(
                        name: "FK_section_positions_base_posiions_pallets_position_id",
                        column: x => x.position_id,
                        principalSchema: "public",
                        principalTable: "base_posiions_pallets",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_section_positions_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stock_placements_SectionPositionId",
                schema: "public",
                table: "stock_placements",
                column: "SectionPositionId");

            migrationBuilder.CreateIndex(
                name: "ix_section_positions_section_id",
                schema: "public",
                table: "section_positions",
                column: "section_id");

            migrationBuilder.AddForeignKey(
                name: "FK_lots_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "lots_positions",
                column: "position_id",
                principalSchema: "public",
                principalTable: "base_posiions_pallets",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lots_positions_lots_lot_id",
                schema: "public",
                table: "lots_positions",
                column: "lot_id",
                principalSchema: "public",
                principalTable: "lots",
                principalColumn: "tramo_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rack_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "rack_positions",
                column: "position_id",
                principalSchema: "public",
                principalTable: "base_posiions_pallets",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_placements_lots_positions_lot_position_id",
                schema: "public",
                table: "stock_placements",
                column: "lot_position_id",
                principalSchema: "public",
                principalTable: "lots_positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_placements_section_positions_SectionPositionId",
                schema: "public",
                table: "stock_placements",
                column: "SectionPositionId",
                principalSchema: "public",
                principalTable: "section_positions",
                principalColumn: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_lots_positions_lots_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "lots_positions_id",
                principalSchema: "public",
                principalTable: "lots_positions",
                principalColumn: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_rack_positions_rack_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "rack_positions_id",
                principalSchema: "public",
                principalTable: "rack_positions",
                principalColumn: "position_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lots_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_lots_positions_lots_lot_id",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_rack_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_placements_lots_positions_lot_position_id",
                schema: "public",
                table: "stock_placements");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_placements_section_positions_SectionPositionId",
                schema: "public",
                table: "stock_placements");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_lots_positions_lots_positions_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_rack_positions_rack_positions_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropTable(
                name: "section_positions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "base_posiions_pallets",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_stock_placements_SectionPositionId",
                schema: "public",
                table: "stock_placements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lots_positions",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "SectionPositionId",
                schema: "public",
                table: "stock_placements");

            migrationBuilder.DropColumn(
                name: "allows_storage_aisle",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "enabled_by_user_name",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "enabled_date",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "enabled_time",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "is_storage_enable_aisle",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "max_pallets_per_level_aisle",
                schema: "public",
                table: "sections");

            migrationBuilder.RenameTable(
                name: "lots_positions",
                schema: "public",
                newName: "tramo_positions",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "position_id",
                schema: "public",
                table: "rack_positions",
                newName: "rack_position_id");

            migrationBuilder.RenameColumn(
                name: "lot_id",
                schema: "public",
                table: "tramo_positions",
                newName: "tramo_id");

            migrationBuilder.RenameColumn(
                name: "position_id",
                schema: "public",
                table: "tramo_positions",
                newName: "tramo_position_id");

            migrationBuilder.RenameIndex(
                name: "ix_lots_positions_lot_id",
                schema: "public",
                table: "tramo_positions",
                newName: "ix_tramo_positions_tramo_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .Annotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .Annotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .Annotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .Annotation("Npgsql:Enum:public.duca_type_enum", "duca_f,duca_d,duca_t")
                .Annotation("Npgsql:Enum:public.fuel_type_enum", "electric,lpg,diesel,gasoline,manual,other")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .Annotation("Npgsql:Enum:public.machinery_type_enum", "forklift,crane,pallet_jack,conveyor,other")
                .Annotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .Annotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .Annotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .Annotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .Annotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .Annotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.reassignment_session_status_enum", "open,paused,closed")
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .Annotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .Annotation("Npgsql:Enum:public.unloading_status_enum", "pending,in_progress,paused,completed,cancelled")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .Annotation("Npgsql:Enum:public.warehouse_task_event_type_enum", "started,paused,resumed,completed")
                .Annotation("Npgsql:Enum:public.warehouse_task_status_enum", "in_progress,paused,completed")
                .Annotation("Npgsql:Enum:public.warehouse_task_type_enum", "unloading,reassignment,dispatch")
                .Annotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .OldAnnotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .OldAnnotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .OldAnnotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .OldAnnotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .OldAnnotation("Npgsql:Enum:public.duca_type_enum", "duca_f,duca_d,duca_t")
                .OldAnnotation("Npgsql:Enum:public.fuel_type_enum", "electric,lpg,diesel,gasoline,manual,other")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .OldAnnotation("Npgsql:Enum:public.machinery_type_enum", "forklift,crane,pallet_jack,conveyor,other")
                .OldAnnotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .OldAnnotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .OldAnnotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .OldAnnotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.reassignment_session_status_enum", "open,paused,closed")
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .OldAnnotation("Npgsql:Enum:public.unloading_status_enum", "pending,in_progress,paused,completed,cancelled")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_task_event_type_enum", "started,paused,resumed,completed")
                .OldAnnotation("Npgsql:Enum:public.warehouse_task_status_enum", "in_progress,paused,completed")
                .OldAnnotation("Npgsql:Enum:public.warehouse_task_type_enum", "unloading,reassignment,dispatch")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AddColumn<string>(
                name: "block_reason",
                schema: "public",
                table: "rack_positions",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "rack_positions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "rack_positions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_blocked",
                schema: "public",
                table: "rack_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_occupied",
                schema: "public",
                table: "rack_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_reserved",
                schema: "public",
                table: "rack_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "position_code",
                schema: "public",
                table: "rack_positions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "position_number",
                schema: "public",
                table: "rack_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "allows_stacking",
                schema: "public",
                table: "tramo_positions",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "block_reason",
                schema: "public",
                table: "tramo_positions",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "column_number",
                schema: "public",
                table: "tramo_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "tramo_positions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "tramo_positions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_blocked",
                schema: "public",
                table: "tramo_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_occupied",
                schema: "public",
                table: "tramo_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_reserved",
                schema: "public",
                table: "tramo_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "position_code",
                schema: "public",
                table: "tramo_positions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "row_number",
                schema: "public",
                table: "tramo_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tramo_positions",
                schema: "public",
                table: "tramo_positions",
                column: "tramo_position_id");

            migrationBuilder.CreateTable(
                name: "section_overflow_capacities",
                schema: "public",
                columns: table => new
                {
                    section_overflow_capacity_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    section_id = table.Column<Guid>(type: "uuid", nullable: false),
                    allows_overflow_storage = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    enabled_by_user_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    enabled_date = table.Column<DateOnly>(type: "date", nullable: true),
                    enabled_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    is_overflow_enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    max_overflow_polines = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section_overflow_capacities", x => x.section_overflow_capacity_id);
                    table.ForeignKey(
                        name: "FK_section_overflow_capacities_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_rack_positions_rack_id_position_code",
                schema: "public",
                table: "rack_positions",
                columns: new[] { "rack_id", "position_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_rack_positions_rack_id_position_number",
                schema: "public",
                table: "rack_positions",
                columns: new[] { "rack_id", "position_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tramo_positions_tramo_id_position_code",
                schema: "public",
                table: "tramo_positions",
                columns: new[] { "tramo_id", "position_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_section_overflow_capacities_section_id",
                schema: "public",
                table: "section_overflow_capacities",
                column: "section_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_placements_tramo_positions_lot_position_id",
                schema: "public",
                table: "stock_placements",
                column: "lot_position_id",
                principalSchema: "public",
                principalTable: "tramo_positions",
                principalColumn: "tramo_position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tramo_positions_lots_tramo_id",
                schema: "public",
                table: "tramo_positions",
                column: "tramo_id",
                principalSchema: "public",
                principalTable: "lots",
                principalColumn: "tramo_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_rack_positions_rack_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "rack_positions_id",
                principalSchema: "public",
                principalTable: "rack_positions",
                principalColumn: "rack_position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_tramo_positions_lots_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "lots_positions_id",
                principalSchema: "public",
                principalTable: "tramo_positions",
                principalColumn: "tramo_position_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
