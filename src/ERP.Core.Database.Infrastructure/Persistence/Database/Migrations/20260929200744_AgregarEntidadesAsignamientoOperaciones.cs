using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadesAsignamientoOperaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_collaborators_operational_orders_operational_ord~",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropForeignKey(
                name: "FK_assignments_machinery_operational_orders_operational_order_~",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_merchandise_merchandise_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropForeignKey(
                name: "FK_operational_orders_warehouses_warehouse_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_services_orders_operational_orders_operational_order_id",
                schema: "public",
                table: "services_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_merchandise_merchandise_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropTable(
                name: "merchandise",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_supplies",
                schema: "public");

            migrationBuilder.DropTable(
                name: "supplies",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_stocks_merchandise_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "ix_services_orders_operational_order_id",
                schema: "public",
                table: "services_orders");

            migrationBuilder.DropIndex(
                name: "IX_operational_orders_warehouse_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropIndex(
                name: "IX_ducat_registry_details_merchandise_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "merchandise_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "operational_order_id",
                schema: "public",
                table: "services_orders");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "merchandise_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.RenameColumn(
                name: "operational_order_id",
                schema: "public",
                table: "assignments_machinery",
                newName: "assignment_operational_id");

            migrationBuilder.RenameIndex(
                name: "ix_assignments_machinery_operational_order_id",
                schema: "public",
                table: "assignments_machinery",
                newName: "ix_assignments_machinery_assignment_operational_id");

            migrationBuilder.RenameColumn(
                name: "operational_order_id",
                schema: "public",
                table: "assignment_collaborators",
                newName: "OperationalOrderId");

            migrationBuilder.RenameIndex(
                name: "ix_assignment_collaborators_operational_order_id",
                schema: "public",
                table: "assignment_collaborators",
                newName: "IX_assignment_collaborators_OperationalOrderId");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.assignment_collaborators_roles_enum", "warehouse_assistant,forklift_operator")
                .Annotation("Npgsql:Enum:public.assignment_operational_status_enum", "pending,in_progress,on_hold,downloaded")
                .Annotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.credit_status_enum", "active,blocked,suspended,overdue")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.customer_type_enum", "natural,juridical")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .Annotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .Annotation("Npgsql:Enum:public.destination_type_enum", "warehouse,custom_yard,custom_sheld")
                .Annotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .Annotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .Annotation("Npgsql:Enum:public.duca_type_enum", "duca_f,duca_d,duca_t")
                .Annotation("Npgsql:Enum:public.employment_type_enum", "internal,outsourced,temporary")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.invoice_status_enum", "pending,paid,overdue")
                .Annotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .Annotation("Npgsql:Enum:public.machinery_type_enum", "forklift")
                .Annotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.operational_order_status_enum", "completed,pending_document,assignment")
                .Annotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .Annotation("Npgsql:Enum:public.payment_condition_enum", "credit,cash")
                .Annotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .Annotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .Annotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .Annotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .Annotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.reassignment_session_status_enum", "open,paused,closed")
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
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
                .OldAnnotation("Npgsql:Enum:public.assignment_collaborators_roles_enum", "warehouse_assistant,forklift_operator")
                .OldAnnotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .OldAnnotation("Npgsql:Enum:public.credit_status_enum", "active,blocked,suspended,overdue")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.customer_type_enum", "natural,juridical")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .OldAnnotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .OldAnnotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .OldAnnotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .OldAnnotation("Npgsql:Enum:public.duca_type_enum", "duca_f,duca_d,duca_t")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.invoice_status_enum", "pending,paid,overdue")
                .OldAnnotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .OldAnnotation("Npgsql:Enum:public.machinery_type_enum", "forklift")
                .OldAnnotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.operational_order_status_enum", "completed,pending_document,assignment")
                .OldAnnotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .OldAnnotation("Npgsql:Enum:public.payment_condition_enum", "credit,cash")
                .OldAnnotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .OldAnnotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .OldAnnotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.reassignment_session_status_enum", "open,paused,closed")
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
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

            migrationBuilder.AddColumn<int>(
                name: "employment_type",
                schema: "public",
                table: "operational_orders",
                type: "employment_type_enum",
                nullable: false,
                defaultValueSql: "'internal'::employment_type_enum");

            migrationBuilder.AddColumn<bool>(
                name: "has_enclosure_assigned",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_consolidated",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Concept",
                schema: "public",
                table: "assignments_machinery",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                schema: "public",
                table: "assignments_machinery",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "assignments_machinery",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                schema: "public",
                table: "assignment_collaborators",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "assignment_collaborators",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "assignment_operational_id",
                schema: "public",
                table: "assignment_collaborators",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "assignment_operational",
                schema: "public",
                columns: table => new
                {
                    assignment_operational_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    has_machinery_assigned = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    has_enclosure_assigned = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    has_collaborators_assigned = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    status = table.Column<int>(type: "assignment_operational_status_enum", nullable: false, defaultValueSql: "'pending'::assignment_operational_status_enum"),
                    operational_order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    additional_data = table.Column<string>(type: "jsonb", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment_operational", x => x.assignment_operational_id);
                    table.ForeignKey(
                        name: "FK_assignment_operational_operational_orders_operational_order~",
                        column: x => x.operational_order_id,
                        principalSchema: "public",
                        principalTable: "operational_orders",
                        principalColumn: "operational_order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assignment_enclosure",
                schema: "public",
                columns: table => new
                {
                    assignment_enclosure_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    observations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    merchandise = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    merchandise_description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    destination_type = table.Column<int>(type: "destination_type_enum", nullable: false, defaultValueSql: "'warehouse'::destination_type_enum"),
                    warehosue_id = table.Column<Guid>(type: "uuid", nullable: true),
                    AssignmentOperationalId = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment_enclosure", x => x.assignment_enclosure_id);
                    table.ForeignKey(
                        name: "FK_assignment_enclosure_assignment_operational_AssignmentOpera~",
                        column: x => x.AssignmentOperationalId,
                        principalSchema: "public",
                        principalTable: "assignment_operational",
                        principalColumn: "assignment_operational_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assignment_enclosure_warehouses_warehosue_id",
                        column: x => x.warehosue_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignments_machinery_UserId",
                schema: "public",
                table: "assignments_machinery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "ix_assignment_collaborators_assignment_operational_id",
                schema: "public",
                table: "assignment_collaborators",
                column: "assignment_operational_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_collaborators_UserId",
                schema: "public",
                table: "assignment_collaborators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_enclosure_AssignmentOperationalId",
                schema: "public",
                table: "assignment_enclosure",
                column: "AssignmentOperationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_assignment_enclosure_warehosue_id",
                schema: "public",
                table: "assignment_enclosure",
                column: "warehosue_id");

            migrationBuilder.CreateIndex(
                name: "ix_assignment_operational_operational_order_id",
                schema: "public",
                table: "assignment_operational",
                column: "operational_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_assignment_operational_status",
                schema: "public",
                table: "assignment_operational",
                column: "status");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_collaborators_assignment_operational_assignment_~",
                schema: "public",
                table: "assignment_collaborators",
                column: "assignment_operational_id",
                principalSchema: "public",
                principalTable: "assignment_operational",
                principalColumn: "assignment_operational_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_collaborators_operational_orders_OperationalOrde~",
                schema: "public",
                table: "assignment_collaborators",
                column: "OperationalOrderId",
                principalSchema: "public",
                principalTable: "operational_orders",
                principalColumn: "operational_order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_collaborators_users_UserId",
                schema: "public",
                table: "assignment_collaborators",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_machinery_assignment_operational_assignment_ope~",
                schema: "public",
                table: "assignments_machinery",
                column: "assignment_operational_id",
                principalSchema: "public",
                principalTable: "assignment_operational",
                principalColumn: "assignment_operational_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_machinery_users_UserId",
                schema: "public",
                table: "assignments_machinery",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_collaborators_assignment_operational_assignment_~",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropForeignKey(
                name: "FK_assignment_collaborators_operational_orders_OperationalOrde~",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropForeignKey(
                name: "FK_assignment_collaborators_users_UserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropForeignKey(
                name: "FK_assignments_machinery_assignment_operational_assignment_ope~",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropForeignKey(
                name: "FK_assignments_machinery_users_UserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropTable(
                name: "assignment_enclosure",
                schema: "public");

            migrationBuilder.DropTable(
                name: "assignment_operational",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_assignments_machinery_UserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropIndex(
                name: "ix_assignment_collaborators_assignment_operational_id",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropIndex(
                name: "IX_assignment_collaborators_UserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropColumn(
                name: "employment_type",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "has_enclosure_assigned",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "is_consolidated",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "Concept",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropColumn(
                name: "assignment_operational_id",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.RenameColumn(
                name: "assignment_operational_id",
                schema: "public",
                table: "assignments_machinery",
                newName: "operational_order_id");

            migrationBuilder.RenameIndex(
                name: "ix_assignments_machinery_assignment_operational_id",
                schema: "public",
                table: "assignments_machinery",
                newName: "ix_assignments_machinery_operational_order_id");

            migrationBuilder.RenameColumn(
                name: "OperationalOrderId",
                schema: "public",
                table: "assignment_collaborators",
                newName: "operational_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_collaborators_OperationalOrderId",
                schema: "public",
                table: "assignment_collaborators",
                newName: "ix_assignment_collaborators_operational_order_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.assignment_collaborators_roles_enum", "warehouse_assistant,forklift_operator")
                .Annotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.credit_status_enum", "active,blocked,suspended,overdue")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.customer_type_enum", "natural,juridical")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .Annotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .Annotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .Annotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .Annotation("Npgsql:Enum:public.duca_type_enum", "duca_f,duca_d,duca_t")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.invoice_status_enum", "pending,paid,overdue")
                .Annotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .Annotation("Npgsql:Enum:public.machinery_type_enum", "forklift")
                .Annotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.operational_order_status_enum", "completed,pending_document,assignment")
                .Annotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .Annotation("Npgsql:Enum:public.payment_condition_enum", "credit,cash")
                .Annotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .Annotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .Annotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .Annotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .Annotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.reassignment_session_status_enum", "open,paused,closed")
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
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
                .OldAnnotation("Npgsql:Enum:public.assignment_collaborators_roles_enum", "warehouse_assistant,forklift_operator")
                .OldAnnotation("Npgsql:Enum:public.assignment_operational_status_enum", "pending,in_progress,on_hold,downloaded")
                .OldAnnotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .OldAnnotation("Npgsql:Enum:public.credit_status_enum", "active,blocked,suspended,overdue")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.customer_type_enum", "natural,juridical")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .OldAnnotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .OldAnnotation("Npgsql:Enum:public.destination_type_enum", "warehouse,custom_yard,custom_sheld")
                .OldAnnotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .OldAnnotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .OldAnnotation("Npgsql:Enum:public.duca_type_enum", "duca_f,duca_d,duca_t")
                .OldAnnotation("Npgsql:Enum:public.employment_type_enum", "internal,outsourced,temporary")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.invoice_status_enum", "pending,paid,overdue")
                .OldAnnotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .OldAnnotation("Npgsql:Enum:public.machinery_type_enum", "forklift")
                .OldAnnotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.operational_order_status_enum", "completed,pending_document,assignment")
                .OldAnnotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .OldAnnotation("Npgsql:Enum:public.payment_condition_enum", "credit,cash")
                .OldAnnotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .OldAnnotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .OldAnnotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.reassignment_session_status_enum", "open,paused,closed")
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
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
                name: "merchandise_id",
                schema: "public",
                table: "stocks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "operational_order_id",
                schema: "public",
                table: "services_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "warehouse_id",
                schema: "public",
                table: "operational_orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "merchandise_id",
                schema: "public",
                table: "ducat_registry_details",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "merchandise",
                schema: "public",
                columns: table => new
                {
                    merchandise_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    merchandise_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_merchandise", x => x.merchandise_id);
                    table.ForeignKey(
                        name: "FK_merchandise_category_products_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplies",
                schema: "public",
                columns: table => new
                {
                    supplies_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplies", x => x.supplies_id);
                });

            migrationBuilder.CreateTable(
                name: "unloading_supplies",
                schema: "public",
                columns: table => new
                {
                    unloading_supplies_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    supplies_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    quantity = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_supplies", x => x.unloading_supplies_id);
                    table.ForeignKey(
                        name: "FK_unloading_supplies_supplies_supplies_id",
                        column: x => x.supplies_id,
                        principalSchema: "public",
                        principalTable: "supplies",
                        principalColumn: "supplies_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unloading_supplies_unloading_details_unloading_details_id",
                        column: x => x.unloading_details_id,
                        principalSchema: "public",
                        principalTable: "unloading_details",
                        principalColumn: "unloading_details_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stocks_merchandise_id",
                schema: "public",
                table: "stocks",
                column: "merchandise_id");

            migrationBuilder.CreateIndex(
                name: "ix_services_orders_operational_order_id",
                schema: "public",
                table: "services_orders",
                column: "operational_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_operational_orders_warehouse_id",
                schema: "public",
                table: "operational_orders",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_merchandise_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "merchandise_id");

            migrationBuilder.CreateIndex(
                name: "IX_merchandise_category_id",
                schema: "public",
                table: "merchandise",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_supplies_supplies_id",
                schema: "public",
                table: "unloading_supplies",
                column: "supplies_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_supplies_unloading_details_id",
                schema: "public",
                table: "unloading_supplies",
                column: "unloading_details_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_collaborators_operational_orders_operational_ord~",
                schema: "public",
                table: "assignment_collaborators",
                column: "operational_order_id",
                principalSchema: "public",
                principalTable: "operational_orders",
                principalColumn: "operational_order_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_machinery_operational_orders_operational_order_~",
                schema: "public",
                table: "assignments_machinery",
                column: "operational_order_id",
                principalSchema: "public",
                principalTable: "operational_orders",
                principalColumn: "operational_order_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_merchandise_merchandise_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "merchandise_id",
                principalSchema: "public",
                principalTable: "merchandise",
                principalColumn: "merchandise_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_operational_orders_warehouses_warehouse_id",
                schema: "public",
                table: "operational_orders",
                column: "warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_services_orders_operational_orders_operational_order_id",
                schema: "public",
                table: "services_orders",
                column: "operational_order_id",
                principalSchema: "public",
                principalTable: "operational_orders",
                principalColumn: "operational_order_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_merchandise_merchandise_id",
                schema: "public",
                table: "stocks",
                column: "merchandise_id",
                principalSchema: "public",
                principalTable: "merchandise",
                principalColumn: "merchandise_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
