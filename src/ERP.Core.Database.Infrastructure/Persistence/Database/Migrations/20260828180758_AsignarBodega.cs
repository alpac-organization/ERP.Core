using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AsignarBodega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_lots_LotsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_rack_positions_RackPositionsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_tramo_positions_LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropTable(
                name: "unloading_crew_assignments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_machinery_assignments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_details",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_machinery_code",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.RenameColumn(
                name: "RackPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                newName: "rack_positions_id");

            migrationBuilder.RenameColumn(
                name: "LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                newName: "lots_positions_id");

            migrationBuilder.RenameColumn(
                name: "LotsId",
                schema: "public",
                table: "warehouse_assignments",
                newName: "lots_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_assignments_RackPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                newName: "IX_warehouse_assignments_rack_positions_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_assignments_LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                newName: "IX_warehouse_assignments_lots_positions_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_assignments_LotsId",
                schema: "public",
                table: "warehouse_assignments",
                newName: "IX_warehouse_assignments_lots_id");

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
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .Annotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
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
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.machinery_type_enum", "forklift,crane,pallet_jack,conveyor,other")
                .OldAnnotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
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
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AddColumn<Guid>(
                name: "assigned_operator_id",
                schema: "public",
                table: "warehouse_machinery",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "warehouse_machinery",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "brand",
                schema: "public",
                table: "warehouse_machinery",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "company_id",
                schema: "public",
                table: "warehouse_machinery",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "fuel_type",
                schema: "public",
                table: "warehouse_machinery",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "hour_meter",
                schema: "public",
                table: "warehouse_machinery",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                schema: "public",
                table: "warehouse_machinery",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_maintenance_date",
                schema: "public",
                table: "warehouse_machinery",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "license_plate",
                schema: "public",
                table: "warehouse_machinery",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "load_capacity_kg",
                schema: "public",
                table: "warehouse_machinery",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "manufacture_year",
                schema: "public",
                table: "warehouse_machinery",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "max_reach_height_meters",
                schema: "public",
                table: "warehouse_machinery",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "model",
                schema: "public",
                table: "warehouse_machinery",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "next_maintenance_date",
                schema: "public",
                table: "warehouse_machinery",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "notes",
                schema: "public",
                table: "warehouse_machinery",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "purchase_date",
                schema: "public",
                table: "warehouse_machinery",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serial_number",
                schema: "public",
                table: "warehouse_machinery",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "warehouse_machinery",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "warehouse_id",
                schema: "public",
                table: "warehouse_machinery",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "warranty_expiration_date",
                schema: "public",
                table: "warehouse_machinery",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "rack_id",
                schema: "public",
                table: "warehouse_assignments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "unloading_end_time",
                schema: "public",
                table: "warehouse_assignments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "unloading_start_time",
                schema: "public",
                table: "warehouse_assignments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "warehouse_keeper_user_id",
                schema: "public",
                table: "warehouse_assignments",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "crew_assignments",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_outsourced = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    person_count = table.Column<int>(type: "integer", nullable: true),
                    provider_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    invoice_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    warehouse_assignment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crew_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_crew_assignments_warehouse_assignments_warehouse_assignment~",
                        column: x => x.warehouse_assignment_id,
                        principalSchema: "public",
                        principalTable: "warehouse_assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "machinery_assignments",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_assignment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    machinery_code = table.Column<Guid>(type: "uuid", nullable: true),
                    operator_collaborator_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_outsourced = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    provider_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    invoice_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    machinery_description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    assigned_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_machinery_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_machinery_assignments_warehouse_assignments_warehouse_assig~",
                        column: x => x.warehouse_assignment_id,
                        principalSchema: "public",
                        principalTable: "warehouse_assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_machinery_assignments_warehouse_machinery_machinery_code",
                        column: x => x.machinery_code,
                        principalSchema: "public",
                        principalTable: "warehouse_machinery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_machinery_code_company_id",
                schema: "public",
                table: "warehouse_machinery",
                columns: new[] { "code", "company_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_crew_assignments_warehouse_assignment_id",
                schema: "public",
                table: "crew_assignments",
                column: "warehouse_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_machinery_assignments_machinery_code",
                schema: "public",
                table: "machinery_assignments",
                column: "machinery_code");

            migrationBuilder.CreateIndex(
                name: "IX_machinery_assignments_warehouse_assignment_id",
                schema: "public",
                table: "machinery_assignments",
                column: "warehouse_assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_lots_lots_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "lots_id",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_lots_lots_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_rack_positions_rack_positions_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_tramo_positions_lots_positions_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropTable(
                name: "crew_assignments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "machinery_assignments",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_machinery_code_company_id",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "assigned_operator_id",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "branch_id",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "brand",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "company_id",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "fuel_type",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "hour_meter",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "image_url",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "last_maintenance_date",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "license_plate",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "load_capacity_kg",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "manufacture_year",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "max_reach_height_meters",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "model",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "next_maintenance_date",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "notes",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "purchase_date",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "serial_number",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "warranty_expiration_date",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.DropColumn(
                name: "unloading_end_time",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropColumn(
                name: "unloading_start_time",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropColumn(
                name: "warehouse_keeper_user_id",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.RenameColumn(
                name: "rack_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                newName: "RackPositionsId");

            migrationBuilder.RenameColumn(
                name: "lots_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                newName: "LotsPositionsId");

            migrationBuilder.RenameColumn(
                name: "lots_id",
                schema: "public",
                table: "warehouse_assignments",
                newName: "LotsId");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_assignments_rack_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                newName: "IX_warehouse_assignments_RackPositionsId");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_assignments_lots_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                newName: "IX_warehouse_assignments_LotsPositionsId");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_assignments_lots_id",
                schema: "public",
                table: "warehouse_assignments",
                newName: "IX_warehouse_assignments_LotsId");

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
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.machinery_type_enum", "forklift,crane,pallet_jack,conveyor,other")
                .Annotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
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
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .Annotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
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
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "rack_id",
                schema: "public",
                table: "warehouse_assignments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "unloading_details",
                schema: "public",
                columns: table => new
                {
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_assignments_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    prepared_pallets = table.Column<decimal>(type: "numeric(10,0)", precision: 10, nullable: true),
                    unloading_end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    unloading_start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    warehouse_chief_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false)
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
                    unloading_crew_assignment_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    persona_count = table.Column<int>(type: "integer", nullable: false),
                    tercerizada = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_crew_assignments", x => x.unloading_crew_assignment_id);
                    table.ForeignKey(
                        name: "FK_unloading_crew_assignments_unloading_details_unloading_deta~",
                        column: x => x.unloading_details_id,
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
                    machinery_code = table.Column<Guid>(type: "uuid", nullable: false),
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_unloading_machinery_assignments_warehouse_machinery_machine~",
                        column: x => x.machinery_code,
                        principalSchema: "public",
                        principalTable: "warehouse_machinery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_machinery_code",
                schema: "public",
                table: "warehouse_machinery",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unloading_crew_assignments_unloading_details_id",
                schema: "public",
                table: "unloading_crew_assignments",
                column: "unloading_details_id");

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
                name: "IX_unloading_machinery_assignments_machinery_code",
                schema: "public",
                table: "unloading_machinery_assignments",
                column: "machinery_code");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_machinery_assignments_unloading_details_id",
                schema: "public",
                table: "unloading_machinery_assignments",
                column: "unloading_details_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_lots_LotsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "LotsId",
                principalSchema: "public",
                principalTable: "lots",
                principalColumn: "tramo_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_rack_positions_RackPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "RackPositionsId",
                principalSchema: "public",
                principalTable: "rack_positions",
                principalColumn: "rack_position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_tramo_positions_LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "LotsPositionsId",
                principalSchema: "public",
                principalTable: "tramo_positions",
                principalColumn: "tramo_position_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
