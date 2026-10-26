using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTiposAlcanceYPoliticaPermisos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.absence_source_enum", "manual,biometric_clock")
                .Annotation("Npgsql:Enum:public.absence_status_enum", "pending,applied,cancelled")
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
                .Annotation("Npgsql:Enum:public.entry_status_enum", "pending_review,approved_entry,cancel_entry")
                .Annotation("Npgsql:Enum:public.entry_type_enum", "buy,return,inventory_adjustment")
                .Annotation("Npgsql:Enum:public.family_relationship_enum", "none,spouse,child,parent,sibling")
                .Annotation("Npgsql:Enum:public.fault_severity_enum", "minor,serious,very_serious")
                .Annotation("Npgsql:Enum:public.fault_source_enum", "manual,system_escalation")
                .Annotation("Npgsql:Enum:public.fault_status_enum", "open,sanction_applied,prescribed")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.invoice_status_enum", "pending,paid,overdue")
                .Annotation("Npgsql:Enum:public.kardex_movement_type_enum", "buys,exit,returns")
                .Annotation("Npgsql:Enum:public.kardex_type_enum", "operational,administrative")
                .Annotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .Annotation("Npgsql:Enum:public.machinery_type_enum", "forklift")
                .Annotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.merchandise_category_enum", "none,refrigerated,perishable,dangerous,ordinary,chemicals")
                .Annotation("Npgsql:Enum:public.operational_order_status_enum", "completed,pending_document,assignment")
                .Annotation("Npgsql:Enum:public.outflow_status_enum", "pending_review,annuled,pending_dispatch,dispatch_cancelled,approved")
                .Annotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .Annotation("Npgsql:Enum:public.payment_condition_enum", "credit,cash")
                .Annotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .Annotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .Annotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay,judicial_appointment,marriage_leave,birth_leave,bereavement_leave")
                .Annotation("Npgsql:Enum:public.permit_beneficiary_scope_enum", "none,own,family_nucleus")
                .Annotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .Annotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .Annotation("Npgsql:Enum:public.product_stock_status_enum", "stable,low_balance,empty")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "administrative,operational")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.sanction_status_enum", "applied,cancelled")
                .Annotation("Npgsql:Enum:public.sanction_type_enum", "verbal_warning,memorandum,suspension,commitment_letter,termination")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .Annotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .Annotation("Npgsql:Enum:public.supplier_type_enum", "international,ordinary")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .Annotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .Annotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.absence_source_enum", "manual,biometric_clock")
                .OldAnnotation("Npgsql:Enum:public.absence_status_enum", "pending,applied,cancelled")
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
                .OldAnnotation("Npgsql:Enum:public.entry_status_enum", "pending_review,approved_entry,cancel_entry")
                .OldAnnotation("Npgsql:Enum:public.entry_type_enum", "buy,return,inventory_adjustment")
                .OldAnnotation("Npgsql:Enum:public.fault_severity_enum", "minor,serious,very_serious")
                .OldAnnotation("Npgsql:Enum:public.fault_source_enum", "manual,system_escalation")
                .OldAnnotation("Npgsql:Enum:public.fault_status_enum", "open,sanction_applied,prescribed")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.invoice_status_enum", "pending,paid,overdue")
                .OldAnnotation("Npgsql:Enum:public.kardex_movement_type_enum", "buys,exit,returns")
                .OldAnnotation("Npgsql:Enum:public.kardex_type_enum", "operational,administrative")
                .OldAnnotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .OldAnnotation("Npgsql:Enum:public.machinery_type_enum", "forklift")
                .OldAnnotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.merchandise_category_enum", "none,refrigerated,perishable,dangerous,ordinary,chemicals")
                .OldAnnotation("Npgsql:Enum:public.operational_order_status_enum", "completed,pending_document,assignment")
                .OldAnnotation("Npgsql:Enum:public.outflow_status_enum", "pending_review,annuled,pending_dispatch,dispatch_cancelled,approved")
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
                .OldAnnotation("Npgsql:Enum:public.product_stock_status_enum", "stable,low_balance,empty")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "administrative,operational")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.sanction_status_enum", "applied,cancelled")
                .OldAnnotation("Npgsql:Enum:public.sanction_type_enum", "verbal_warning,memorandum,suspension,commitment_letter,termination")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .OldAnnotation("Npgsql:Enum:public.supplier_type_enum", "international,ordinary")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AddColumn<int>(
                name: "beneficiary_scope",
                schema: "public",
                table: "permit_applications_pending",
                type: "permit_beneficiary_scope_enum",
                nullable: false,
                defaultValueSql: "'none'::permit_beneficiary_scope_enum");

            migrationBuilder.AddColumn<int>(
                name: "family_relationship",
                schema: "public",
                table: "permit_applications_pending",
                type: "family_relationship_enum",
                nullable: false,
                defaultValueSql: "'none'::family_relationship_enum");

            migrationBuilder.AddColumn<string>(
                name: "related_person_name",
                schema: "public",
                table: "permit_applications_pending",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "beneficiary_scope",
                schema: "public",
                table: "permit_applications",
                type: "permit_beneficiary_scope_enum",
                nullable: false,
                defaultValueSql: "'none'::permit_beneficiary_scope_enum");

            migrationBuilder.AddColumn<int>(
                name: "family_relationship",
                schema: "public",
                table: "permit_applications",
                type: "family_relationship_enum",
                nullable: false,
                defaultValueSql: "'none'::family_relationship_enum");

            migrationBuilder.AddColumn<string>(
                name: "related_person_name",
                schema: "public",
                table: "permit_applications",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "permission_type_policies",
                schema: "public",
                columns: table => new
                {
                    perm_type_policy_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    permit_application_type = table.Column<int>(type: "permit_application_type_enum", nullable: false),
                    beneficiary_scope = table.Column<int>(type: "permit_beneficiary_scope_enum", nullable: false, defaultValueSql: "'none'::permit_beneficiary_scope_enum"),
                    family_relationship = table.Column<int>(type: "family_relationship_enum", nullable: false, defaultValueSql: "'none'::family_relationship_enum"),
                    is_paid = table.Column<bool>(type: "boolean", nullable: false),
                    consumes_vacation_balance = table.Column<bool>(type: "boolean", nullable: false),
                    requires_evidence = table.Column<bool>(type: "boolean", nullable: false),
                    max_evidence_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    min_evidence_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    required_approval_steps = table.Column<int>(type: "integer", nullable: false),
                    max_amount_days = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission_type_policies", x => x.perm_type_policy_id);
                    table.CheckConstraint("ck_permit_type_policies_evidence", "min_evidence_count >= 0 AND max_evidence_count >= min_evidence_count");
                    table.CheckConstraint("ck_permit_type_policies_steps", "required_approval_steps IN (1, 2)");
                });

            migrationBuilder.CreateIndex(
                name: "ix_permit_type_policy_id",
                schema: "public",
                table: "permission_type_policies",
                column: "perm_type_policy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_permit_type_policies_rule",
                schema: "public",
                table: "permission_type_policies",
                columns: new[] { "permit_application_type", "beneficiary_scope", "family_relationship" },
                unique: true,
                filter: "deleted_at IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permission_type_policies",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "beneficiary_scope",
                schema: "public",
                table: "permit_applications_pending");

            migrationBuilder.DropColumn(
                name: "family_relationship",
                schema: "public",
                table: "permit_applications_pending");

            migrationBuilder.DropColumn(
                name: "related_person_name",
                schema: "public",
                table: "permit_applications_pending");

            migrationBuilder.DropColumn(
                name: "beneficiary_scope",
                schema: "public",
                table: "permit_applications");

            migrationBuilder.DropColumn(
                name: "family_relationship",
                schema: "public",
                table: "permit_applications");

            migrationBuilder.DropColumn(
                name: "related_person_name",
                schema: "public",
                table: "permit_applications");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.absence_source_enum", "manual,biometric_clock")
                .Annotation("Npgsql:Enum:public.absence_status_enum", "pending,applied,cancelled")
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
                .Annotation("Npgsql:Enum:public.entry_status_enum", "pending_review,approved_entry,cancel_entry")
                .Annotation("Npgsql:Enum:public.entry_type_enum", "buy,return,inventory_adjustment")
                .Annotation("Npgsql:Enum:public.fault_severity_enum", "minor,serious,very_serious")
                .Annotation("Npgsql:Enum:public.fault_source_enum", "manual,system_escalation")
                .Annotation("Npgsql:Enum:public.fault_status_enum", "open,sanction_applied,prescribed")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.invoice_status_enum", "pending,paid,overdue")
                .Annotation("Npgsql:Enum:public.kardex_movement_type_enum", "buys,exit,returns")
                .Annotation("Npgsql:Enum:public.kardex_type_enum", "operational,administrative")
                .Annotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .Annotation("Npgsql:Enum:public.machinery_type_enum", "forklift")
                .Annotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.merchandise_category_enum", "none,refrigerated,perishable,dangerous,ordinary,chemicals")
                .Annotation("Npgsql:Enum:public.operational_order_status_enum", "completed,pending_document,assignment")
                .Annotation("Npgsql:Enum:public.outflow_status_enum", "pending_review,annuled,pending_dispatch,dispatch_cancelled,approved")
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
                .Annotation("Npgsql:Enum:public.product_stock_status_enum", "stable,low_balance,empty")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "administrative,operational")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.sanction_status_enum", "applied,cancelled")
                .Annotation("Npgsql:Enum:public.sanction_type_enum", "verbal_warning,memorandum,suspension,commitment_letter,termination")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .Annotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .Annotation("Npgsql:Enum:public.supplier_type_enum", "international,ordinary")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .Annotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .Annotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.absence_source_enum", "manual,biometric_clock")
                .OldAnnotation("Npgsql:Enum:public.absence_status_enum", "pending,applied,cancelled")
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
                .OldAnnotation("Npgsql:Enum:public.entry_status_enum", "pending_review,approved_entry,cancel_entry")
                .OldAnnotation("Npgsql:Enum:public.entry_type_enum", "buy,return,inventory_adjustment")
                .OldAnnotation("Npgsql:Enum:public.family_relationship_enum", "none,spouse,child,parent,sibling")
                .OldAnnotation("Npgsql:Enum:public.fault_severity_enum", "minor,serious,very_serious")
                .OldAnnotation("Npgsql:Enum:public.fault_source_enum", "manual,system_escalation")
                .OldAnnotation("Npgsql:Enum:public.fault_status_enum", "open,sanction_applied,prescribed")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.invoice_status_enum", "pending,paid,overdue")
                .OldAnnotation("Npgsql:Enum:public.kardex_movement_type_enum", "buys,exit,returns")
                .OldAnnotation("Npgsql:Enum:public.kardex_type_enum", "operational,administrative")
                .OldAnnotation("Npgsql:Enum:public.machinery_status_enum", "available,in_use,in_maintenance,out_of_service")
                .OldAnnotation("Npgsql:Enum:public.machinery_type_enum", "forklift")
                .OldAnnotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.merchandise_category_enum", "none,refrigerated,perishable,dangerous,ordinary,chemicals")
                .OldAnnotation("Npgsql:Enum:public.operational_order_status_enum", "completed,pending_document,assignment")
                .OldAnnotation("Npgsql:Enum:public.outflow_status_enum", "pending_review,annuled,pending_dispatch,dispatch_cancelled,approved")
                .OldAnnotation("Npgsql:Enum:public.pallet_type_enum", "standard,oversized")
                .OldAnnotation("Npgsql:Enum:public.payment_condition_enum", "credit,cash")
                .OldAnnotation("Npgsql:Enum:public.payment_method_type_enum", "ach,local_transfer,check,cash,international_wire")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay,judicial_appointment,marriage_leave,birth_leave,bereavement_leave")
                .OldAnnotation("Npgsql:Enum:public.permit_beneficiary_scope_enum", "none,own,family_nucleus")
                .OldAnnotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .OldAnnotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .OldAnnotation("Npgsql:Enum:public.product_stock_status_enum", "stable,low_balance,empty")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "administrative,operational")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.sanction_status_enum", "applied,cancelled")
                .OldAnnotation("Npgsql:Enum:public.sanction_type_enum", "verbal_warning,memorandum,suspension,commitment_letter,termination")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .OldAnnotation("Npgsql:Enum:public.supplier_type_enum", "international,ordinary")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }
    }
}
