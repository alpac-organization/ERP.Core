using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CodesWarehousesAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_stock_placements_section_positions_rack_position~",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.DropForeignKey(
                name: "FK_assignment_stock_placements_stocks_stock_id",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.DropIndex(
                name: "IX_purchase_orders_purchase_request_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.RenameColumn(
                name: "supplier_rejection_justification",
                schema: "public",
                table: "quotations",
                newName: "supplier_rejection_comments");

            migrationBuilder.RenameColumn(
                name: "reason_rejection",
                schema: "public",
                table: "purchase_requests",
                newName: "rejection_comments");

            migrationBuilder.RenameColumn(
                name: "annulment_reason",
                schema: "public",
                table: "purchase_requests",
                newName: "annulment_comments");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "purchase_orders",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "stock_id",
                schema: "public",
                table: "assignment_stock_placements",
                newName: "assignment_id");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_stock_placements_stock_id",
                schema: "public",
                table: "assignment_stock_placements",
                newName: "IX_assignment_stock_placements_assignment_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.assignment_collaborators_roles_enum", "warehouse_assistant,forklift_operator")
                .Annotation("Npgsql:Enum:public.assignment_operational_status_enum", "none,pending,in_progress,on_hold,downloaded")
                .Annotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments,purchase_rejection_reasons")
                .Annotation("Npgsql:Enum:public.codes_type_enum", "none,qr,bar")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.credit_status_enum", "active,blocked,suspended,overdue")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.customer_type_enum", "natural,juridical")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .Annotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .Annotation("Npgsql:Enum:public.destination_type_enum", "none,warehouse,custom_yard,custom_sheld")
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
                .Annotation("Npgsql:Enum:public.merchandise_category_enum", "none,refrigerated,perishable,dangerous,ordinary,chemicals")
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
                .OldAnnotation("Npgsql:Enum:public.assignment_operational_status_enum", "none,pending,in_progress,on_hold,downloaded")
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
                .OldAnnotation("Npgsql:Enum:public.destination_type_enum", "none,warehouse,custom_yard,custom_sheld")
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
                .OldAnnotation("Npgsql:Enum:public.merchandise_category_enum", "none,refrigerated,perishable,dangerous,ordinary,chemicals")
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

            migrationBuilder.AddColumn<DateTime>(
                name: "last_price_update",
                schema: "public",
                table: "supplier_products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "additional_data",
                schema: "public",
                table: "quotations",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "supplier_rejection_reason_id",
                schema: "public",
                table: "quotations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "annulment_reason_id",
                schema: "public",
                table: "purchase_requests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "reason_rejection_id",
                schema: "public",
                table: "purchase_requests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "estimated_price",
                schema: "public",
                table: "purchase_request_items",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "purchase_orders",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<string>(
                name: "code",
                schema: "public",
                table: "purchase_orders",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "supplier_id",
                schema: "public",
                table: "purchase_orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "code",
                schema: "public",
                table: "products",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "unit_measure_id",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "codes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    code_type = table.Column<int>(type: "codes_type_enum", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    code_generated = table.Column<string>(type: "text", nullable: false),
                    AssignmentOperationalId = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_codes_assignment_operational_AssignmentId",
                        column: x => x.AssignmentId,
                        principalSchema: "public",
                        principalTable: "assignment_operational",
                        principalColumn: "assignment_operational_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_codes_assignment_operational_AssignmentOperationalId",
                        column: x => x.AssignmentOperationalId,
                        principalSchema: "public",
                        principalTable: "assignment_operational",
                        principalColumn: "assignment_operational_id");
                });

            migrationBuilder.CreateTable(
                name: "purchase_order_items",
                schema: "public",
                columns: table => new
                {
                    purchase_order_item_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    purchase_order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchase_request_item_id = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_order_items", x => x.purchase_order_item_id);
                    table.ForeignKey(
                        name: "FK_purchase_order_items_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchase_order_items_purchase_orders_purchase_order_id",
                        column: x => x.purchase_order_id,
                        principalSchema: "public",
                        principalTable: "purchase_orders",
                        principalColumn: "purchase_order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchase_order_items_purchase_request_items_purchase_reques~",
                        column: x => x.purchase_request_item_id,
                        principalSchema: "public",
                        principalTable: "purchase_request_items",
                        principalColumn: "purchase_request_item_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quotations_supplier_rejection_reason_id",
                schema: "public",
                table: "quotations",
                column: "supplier_rejection_reason_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_annulment_reason_id",
                schema: "public",
                table: "purchase_requests",
                column: "annulment_reason_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_reason_rejection_id",
                schema: "public",
                table: "purchase_requests",
                column: "reason_rejection_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_orders_purchase_request_id",
                schema: "public",
                table: "purchase_orders",
                column: "purchase_request_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_orders_supplier_id",
                schema: "public",
                table: "purchase_orders",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ux_purchase_orders_code",
                schema: "public",
                table: "purchase_orders",
                column: "code",
                unique: true,
                filter: "\"code\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_products_unit_measure_id",
                schema: "public",
                table: "products",
                column: "unit_measure_id");

            migrationBuilder.CreateIndex(
                name: "ux_products_code",
                schema: "public",
                table: "products",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_assignment_stock_placements_section_position_id",
                schema: "public",
                table: "assignment_stock_placements",
                column: "section_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_codes_AssignmentId",
                schema: "public",
                table: "codes",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_codes_AssignmentOperationalId",
                schema: "public",
                table: "codes",
                column: "AssignmentOperationalId");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_items_product_id",
                schema: "public",
                table: "purchase_order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_items_purchase_order_id",
                schema: "public",
                table: "purchase_order_items",
                column: "purchase_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_order_items_purchase_request_item_id",
                schema: "public",
                table: "purchase_order_items",
                column: "purchase_request_item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_stock_placements_assignment_operational_assignme~",
                schema: "public",
                table: "assignment_stock_placements",
                column: "assignment_id",
                principalSchema: "public",
                principalTable: "assignment_operational",
                principalColumn: "assignment_operational_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_stock_placements_section_positions_section_posit~",
                schema: "public",
                table: "assignment_stock_placements",
                column: "section_position_id",
                principalSchema: "public",
                principalTable: "section_positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_units_measurement_unit_measure_id",
                schema: "public",
                table: "products",
                column: "unit_measure_id",
                principalSchema: "public",
                principalTable: "units_measurement",
                principalColumn: "unit_measure_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_orders_suppliers_supplier_id",
                schema: "public",
                table: "purchase_orders",
                column: "supplier_id",
                principalSchema: "public",
                principalTable: "suppliers",
                principalColumn: "suppliers_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_requests_sub_catalogs_annulment_reason_id",
                schema: "public",
                table: "purchase_requests",
                column: "annulment_reason_id",
                principalSchema: "public",
                principalTable: "sub_catalogs",
                principalColumn: "sub_catalog_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_requests_sub_catalogs_reason_rejection_id",
                schema: "public",
                table: "purchase_requests",
                column: "reason_rejection_id",
                principalSchema: "public",
                principalTable: "sub_catalogs",
                principalColumn: "sub_catalog_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_quotations_sub_catalogs_supplier_rejection_reason_id",
                schema: "public",
                table: "quotations",
                column: "supplier_rejection_reason_id",
                principalSchema: "public",
                principalTable: "sub_catalogs",
                principalColumn: "sub_catalog_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_stock_placements_assignment_operational_assignme~",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.DropForeignKey(
                name: "FK_assignment_stock_placements_section_positions_section_posit~",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.DropForeignKey(
                name: "FK_products_units_measurement_unit_measure_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_orders_suppliers_supplier_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_requests_sub_catalogs_annulment_reason_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_requests_sub_catalogs_reason_rejection_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_quotations_sub_catalogs_supplier_rejection_reason_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropTable(
                name: "codes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "purchase_order_items",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_quotations_supplier_rejection_reason_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropIndex(
                name: "IX_purchase_requests_annulment_reason_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropIndex(
                name: "IX_purchase_requests_reason_rejection_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropIndex(
                name: "ix_purchase_orders_purchase_request_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropIndex(
                name: "ix_purchase_orders_supplier_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropIndex(
                name: "ux_purchase_orders_code",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropIndex(
                name: "IX_products_unit_measure_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ux_products_code",
                schema: "public",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_assignment_stock_placements_section_position_id",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.DropColumn(
                name: "last_price_update",
                schema: "public",
                table: "supplier_products");

            migrationBuilder.DropColumn(
                name: "additional_data",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "supplier_rejection_reason_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "annulment_reason_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropColumn(
                name: "reason_rejection_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropColumn(
                name: "estimated_price",
                schema: "public",
                table: "purchase_request_items");

            migrationBuilder.DropColumn(
                name: "code",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "supplier_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "code",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "unit_measure_id",
                schema: "public",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "supplier_rejection_comments",
                schema: "public",
                table: "quotations",
                newName: "supplier_rejection_justification");

            migrationBuilder.RenameColumn(
                name: "rejection_comments",
                schema: "public",
                table: "purchase_requests",
                newName: "reason_rejection");

            migrationBuilder.RenameColumn(
                name: "annulment_comments",
                schema: "public",
                table: "purchase_requests",
                newName: "annulment_reason");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "purchase_orders",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "assignment_id",
                schema: "public",
                table: "assignment_stock_placements",
                newName: "stock_id");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_stock_placements_assignment_id",
                schema: "public",
                table: "assignment_stock_placements",
                newName: "IX_assignment_stock_placements_stock_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.assignment_collaborators_roles_enum", "warehouse_assistant,forklift_operator")
                .Annotation("Npgsql:Enum:public.assignment_operational_status_enum", "none,pending,in_progress,on_hold,downloaded")
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
                .Annotation("Npgsql:Enum:public.destination_type_enum", "none,warehouse,custom_yard,custom_sheld")
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
                .Annotation("Npgsql:Enum:public.merchandise_category_enum", "none,refrigerated,perishable,dangerous,ordinary,chemicals")
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
                .OldAnnotation("Npgsql:Enum:public.assignment_operational_status_enum", "none,pending,in_progress,on_hold,downloaded")
                .OldAnnotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments,purchase_rejection_reasons")
                .OldAnnotation("Npgsql:Enum:public.codes_type_enum", "none,qr,bar")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .OldAnnotation("Npgsql:Enum:public.credit_status_enum", "active,blocked,suspended,overdue")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.customer_type_enum", "natural,juridical")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .OldAnnotation("Npgsql:Enum:public.destination_request_enum", "internal,client,service_order")
                .OldAnnotation("Npgsql:Enum:public.destination_type_enum", "none,warehouse,custom_yard,custom_sheld")
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
                .OldAnnotation("Npgsql:Enum:public.merchandise_category_enum", "none,refrigerated,perishable,dangerous,ordinary,chemicals")
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "purchase_orders",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_orders_purchase_request_id",
                schema: "public",
                table: "purchase_orders",
                column: "purchase_request_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_stock_placements_section_positions_rack_position~",
                schema: "public",
                table: "assignment_stock_placements",
                column: "rack_position_id",
                principalSchema: "public",
                principalTable: "section_positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_stock_placements_stocks_stock_id",
                schema: "public",
                table: "assignment_stock_placements",
                column: "stock_id",
                principalSchema: "public",
                principalTable: "stocks",
                principalColumn: "stock_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
