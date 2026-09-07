using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadesRefactorizadasWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_section_capacities_sections_section_id",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropForeignKey(
                name: "FK_section_overflow_capacities_sections_section_id",
                schema: "public",
                table: "section_overflow_capacities");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_sections_section_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_branches_branch_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropTable(
                name: "warehouse_details",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_section_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropColumn(
                name: "has_children",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "is_owner",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "warehouse_name",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "current_polines_stored",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "last_calculated_at",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "total_max_polines",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "layout_position_x",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "layout_position_y",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "layout_position_z",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "layout_rotation_y",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "length_metres",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "section_name",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "section_type",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "storage_type",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "width_metres",
                schema: "public",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "height_metres",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_position_x",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_position_y",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_position_z",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_rotation_y",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "length_metres",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "width_metres",
                schema: "public",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "layout_position_x",
                schema: "public",
                table: "lots");

            migrationBuilder.DropColumn(
                name: "layout_position_y",
                schema: "public",
                table: "lots");

            migrationBuilder.DropColumn(
                name: "layout_position_z",
                schema: "public",
                table: "lots");

            migrationBuilder.DropColumn(
                name: "layout_rotation_y",
                schema: "public",
                table: "lots");

            migrationBuilder.DropColumn(
                name: "length_metres",
                schema: "public",
                table: "lots");

            migrationBuilder.DropColumn(
                name: "width_metres",
                schema: "public",
                table: "lots");

            migrationBuilder.RenameColumn(
                name: "branch_id",
                schema: "public",
                table: "warehouses",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                newName: "location_id");

            migrationBuilder.RenameIndex(
                name: "ix_warehouses_parent_wareouse_id",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_location_id");

            migrationBuilder.RenameIndex(
                name: "ix_warehouses_branch_id",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_BranchId");

            migrationBuilder.RenameColumn(
                name: "warehouse_capacity_id",
                schema: "public",
                table: "warehouse_capacities",
                newName: "capacity_id");

            migrationBuilder.RenameColumn(
                name: "usable_area_m2",
                schema: "public",
                table: "warehouse_capacities",
                newName: "width");

            migrationBuilder.RenameColumn(
                name: "unusable_area_m2",
                schema: "public",
                table: "warehouse_capacities",
                newName: "length");

            migrationBuilder.RenameColumn(
                name: "total_area_m2",
                schema: "public",
                table: "warehouse_capacities",
                newName: "available_space_without_spacing_m2");

            migrationBuilder.RenameIndex(
                name: "ix_warehouse_capacities_warehouse_id",
                schema: "public",
                table: "warehouse_capacities",
                newName: "IX_warehouse_capacities_warehouse_id");

            migrationBuilder.RenameColumn(
                name: "section_capacity_id",
                schema: "public",
                table: "section_capacities",
                newName: "capacity_id");

            migrationBuilder.RenameIndex(
                name: "ux_section_capacities_section_id",
                schema: "public",
                table: "section_capacities",
                newName: "IX_section_capacities_section_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
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
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
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
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "empty,racks,lots")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle,abandoned")
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
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                schema: "public",
                table: "warehouses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<decimal>(
                name: "available_space_with_spacing_m2",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "available_space_with_spacing_m3",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "available_space_without_spacing_m3",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_space_between_wall",
                schema: "public",
                table: "warehouse_capacities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "maximum_height",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "minimum_height",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "percent_available_space_with_spacing_m2",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "percent_available_space_with_spacing_m3",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "spacing_bottom",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "spacing_left",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "spacing_right",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "spacing_top",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "unused_space_m2",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "unused_space_m3",
                schema: "public",
                table: "warehouse_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "usable_area_m2",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "unusable_area_m2",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "available_space_with_spacing_m2",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "available_space_without_spacing_m2",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "length",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "maximum_height",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "minimum_height",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "percent_available_space_with_spacing_m2",
                schema: "public",
                table: "section_capacities",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "percent_available_space_with_spacing_m3",
                schema: "public",
                table: "section_capacities",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "width",
                schema: "public",
                table: "section_capacities",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "locations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "lots_capacities",
                schema: "public",
                columns: table => new
                {
                    capacity_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    width = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    length = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    minimum_height = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    maximum_height = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    available_space_with_spacing_m2 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    available_space_without_spacing_m2 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    percent_available_space_with_spacing_m2 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    percent_available_space_with_spacing_m3 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    lots_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lots_capacities", x => x.capacity_id);
                    table.ForeignKey(
                        name: "FK_lots_capacities_lots_lots_id",
                        column: x => x.lots_id,
                        principalSchema: "public",
                        principalTable: "lots",
                        principalColumn: "tramo_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rack_capacities",
                schema: "public",
                columns: table => new
                {
                    capacity_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    width = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    length = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    minimum_height = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    maximum_height = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    available_space_with_spacing_m2 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    available_space_without_spacing_m2 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    percent_available_space_with_spacing_m2 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    percent_available_space_with_spacing_m3 = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rack_capacities", x => x.capacity_id);
                    table.ForeignKey(
                        name: "FK_rack_capacities_racks_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks",
                        principalColumn: "rack_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_warehouses_code",
                schema: "public",
                table: "warehouses",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lots_capacities_lots_id",
                schema: "public",
                table: "lots_capacities",
                column: "lots_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rack_capacities_rack_id",
                schema: "public",
                table: "rack_capacities",
                column: "rack_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_section_capacities_sections_section_id",
                schema: "public",
                table: "section_capacities",
                column: "section_id",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_section_overflow_capacities_sections_section_id",
                schema: "public",
                table: "section_overflow_capacities",
                column: "section_id",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_locations_location_id",
                schema: "public",
                table: "warehouses",
                column: "location_id",
                principalSchema: "public",
                principalTable: "locations",
                principalColumn: "location_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_section_capacities_sections_section_id",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropForeignKey(
                name: "FK_section_overflow_capacities_sections_section_id",
                schema: "public",
                table: "section_overflow_capacities");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_locations_location_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropTable(
                name: "lots_capacities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "rack_capacities",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_warehouses_code",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "available_space_with_spacing_m2",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "available_space_with_spacing_m3",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "available_space_without_spacing_m3",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "has_space_between_wall",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "maximum_height",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "minimum_height",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "percent_available_space_with_spacing_m2",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "percent_available_space_with_spacing_m3",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "spacing_bottom",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "spacing_left",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "spacing_right",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "spacing_top",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "unused_space_m2",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "unused_space_m3",
                schema: "public",
                table: "warehouse_capacities");

            migrationBuilder.DropColumn(
                name: "available_space_with_spacing_m2",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "available_space_without_spacing_m2",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "length",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "maximum_height",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "minimum_height",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "percent_available_space_with_spacing_m2",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "percent_available_space_with_spacing_m3",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "width",
                schema: "public",
                table: "section_capacities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "locations");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                schema: "public",
                table: "warehouses",
                newName: "branch_id");

            migrationBuilder.RenameColumn(
                name: "location_id",
                schema: "public",
                table: "warehouses",
                newName: "parent_warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_location_id",
                schema: "public",
                table: "warehouses",
                newName: "ix_warehouses_parent_wareouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_BranchId",
                schema: "public",
                table: "warehouses",
                newName: "ix_warehouses_branch_id");

            migrationBuilder.RenameColumn(
                name: "capacity_id",
                schema: "public",
                table: "warehouse_capacities",
                newName: "warehouse_capacity_id");

            migrationBuilder.RenameColumn(
                name: "width",
                schema: "public",
                table: "warehouse_capacities",
                newName: "usable_area_m2");

            migrationBuilder.RenameColumn(
                name: "length",
                schema: "public",
                table: "warehouse_capacities",
                newName: "unusable_area_m2");

            migrationBuilder.RenameColumn(
                name: "available_space_without_spacing_m2",
                schema: "public",
                table: "warehouse_capacities",
                newName: "total_area_m2");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_capacities_warehouse_id",
                schema: "public",
                table: "warehouse_capacities",
                newName: "ix_warehouse_capacities_warehouse_id");

            migrationBuilder.RenameColumn(
                name: "capacity_id",
                schema: "public",
                table: "section_capacities",
                newName: "section_capacity_id");

            migrationBuilder.RenameIndex(
                name: "IX_section_capacities_section_id",
                schema: "public",
                table: "section_capacities",
                newName: "ux_section_capacities_section_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
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
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "empty,racks,lots")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle,abandoned")
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
                .Annotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
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
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "warehouses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_children",
                schema: "public",
                table: "warehouses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_owner",
                schema: "public",
                table: "warehouses",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "warehouse_name",
                schema: "public",
                table: "warehouses",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses",
                type: "warehouse_type_enum",
                nullable: false,
                defaultValueSql: "'fiscal'::warehouse_type_enum");

            migrationBuilder.AddColumn<int>(
                name: "current_polines_stored",
                schema: "public",
                table: "warehouse_capacities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_calculated_at",
                schema: "public",
                table: "warehouse_capacities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "total_max_polines",
                schema: "public",
                table: "warehouse_capacities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_x",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_y",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_z",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_rotation_y",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "length_metres",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "section_name",
                schema: "public",
                table: "sections",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "section_type",
                schema: "public",
                table: "sections",
                type: "section_type_enum",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "storage_type",
                schema: "public",
                table: "sections",
                type: "section_storage_type_enum",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<decimal>(
                name: "width_metres",
                schema: "public",
                table: "sections",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "usable_area_m2",
                schema: "public",
                table: "section_capacities",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "unusable_area_m2",
                schema: "public",
                table: "section_capacities",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "height_metres",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_x",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_y",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_z",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_rotation_y",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "length_metres",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "width_metres",
                schema: "public",
                table: "racks",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_x",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_y",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_position_z",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "layout_rotation_y",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "length_metres",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "width_metres",
                schema: "public",
                table: "lots",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "warehouse_details",
                schema: "public",
                columns: table => new
                {
                    warehouse_details_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    length_metres = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    parking_spaces_count = table.Column<int>(type: "integer", nullable: true),
                    ramps_count = table.Column<int>(type: "integer", nullable: true),
                    width_metres = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_details", x => x.warehouse_details_id);
                    table.ForeignKey(
                        name: "FK_warehouse_details_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_section_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_deatils_warehouse_id",
                schema: "public",
                table: "warehouse_details",
                column: "warehouse_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_section_capacities_sections_section_id",
                schema: "public",
                table: "section_capacities",
                column: "section_id",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_section_overflow_capacities_sections_section_id",
                schema: "public",
                table: "section_overflow_capacities",
                column: "section_id",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_sections_section_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "section_id",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id",
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
        }
    }
}
