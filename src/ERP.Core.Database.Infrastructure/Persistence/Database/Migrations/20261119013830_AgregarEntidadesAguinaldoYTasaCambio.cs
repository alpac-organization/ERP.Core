using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadesAguinaldoYTasaCambio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_christmas_bonus_accruals_collaborators_collaborator_id",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropForeignKey(
                name: "FK_christmas_bonus_accruals_payrolls_payroll_id",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropForeignKey(
                name: "FK_salaries_collaborators_collaborator_id",
                schema: "public",
                table: "salaries");

            migrationBuilder.DropIndex(
                name: "IX_salaries_collaborator_id",
                schema: "public",
                table: "salaries");

            migrationBuilder.DropIndex(
                name: "ix_christmas_bonus_collaborator_id",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "base_salary",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "equivalent_quantity",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "equivalent_quantity_in_dollars",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.RenameIndex(
                name: "IX_christmas_bonus_accruals_payroll_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                newName: "ix_christmas_bonus_accruals_payroll_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.absence_source_enum", "manual,biometric_clock")
                .Annotation("Npgsql:Enum:public.absence_status_enum", "pending,applied,cancelled")
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.assignment_collaborators_roles_enum", "warehouse_assistant,forklift_operator")
                .Annotation("Npgsql:Enum:public.assignment_operational_status_enum", "none,pending,in_progress,on_hold,downloaded")
                .Annotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments,purchase_rejection_reasons")
                .Annotation("Npgsql:Enum:public.category_type_enum", "administrative,operational")
                .Annotation("Npgsql:Enum:public.christmas_bonus_advance_status_enum", "pending,approved,paid,cancelled")
                .Annotation("Npgsql:Enum:public.christmas_bonus_period_status_enum", "active,completed,settled")
                .Annotation("Npgsql:Enum:public.christmas_bonus_settlement_status_enum", "calculated,paid")
                .Annotation("Npgsql:Enum:public.christmas_bonus_settlement_type_enum", "annual,employment_termination")
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
                .Annotation("Npgsql:Enum:public.equipment_status_enum", "available,in_use,in_maintenance,out_of_service")
                .Annotation("Npgsql:Enum:public.equipment_type_enum", "forklift,wheel_loader,truck,pickup,conveyor,brush_cutter,generator,pressure_washer,blower,water_pump")
                .Annotation("Npgsql:Enum:public.family_relationship_enum", "none,spouse,child,parent,sibling,other")
                .Annotation("Npgsql:Enum:public.fault_severity_enum", "minor,serious,very_serious")
                .Annotation("Npgsql:Enum:public.fault_source_enum", "manual,system_escalation,biometric_clock")
                .Annotation("Npgsql:Enum:public.fault_status_enum", "open,sanction_applied,prescribed,cancelled")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.inventory_outputs_status_enum", "output_pending,dispatched,in_progress,rejected")
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
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services,christmas_bonus")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay,judicial_appointment,marriage_leave,birth_leave,bereavement_leave")
                .Annotation("Npgsql:Enum:public.permit_beneficiary_scope_enum", "none,own,family_nucleus")
                .Annotation("Npgsql:Enum:public.personnel_action_scope_enum", "individual,group,by_area")
                .Annotation("Npgsql:Enum:public.personnel_action_status_enum", "draft,pending_approval,approved,rejected,applied,cancelled")
                .Annotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .Annotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .Annotation("Npgsql:Enum:public.product_status_enum", "active,inactive,low_process")
                .Annotation("Npgsql:Enum:public.product_stock_status_enum", "stable,low_balance,empty")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "administrative,operational")
                .Annotation("Npgsql:Enum:public.purchase_order_status_enum", "pending,generated")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.reason_use_enum", "sale,operation")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.sanction_status_enum", "applied,cancelled,pending")
                .Annotation("Npgsql:Enum:public.sanction_type_enum", "verbal_warning,memorandum,suspension,commitment_letter,termination")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .Annotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .Annotation("Npgsql:Enum:public.supplier_type_enum", "international,ordinary")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .Annotation("Npgsql:Enum:public.termination_status_enum", "pending,closed,cancelled")
                .Annotation("Npgsql:Enum:public.termination_type_enum", "voluntary_resignation,mutual_agreement,justified_dismissal,unjustified_dismissal,contract_expiration,work_completion,employee_death,retirement")
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
                .OldAnnotation("Npgsql:Enum:public.category_type_enum", "administrative,operational")
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
                .OldAnnotation("Npgsql:Enum:public.equipment_status_enum", "available,in_use,in_maintenance,out_of_service")
                .OldAnnotation("Npgsql:Enum:public.equipment_type_enum", "forklift,wheel_loader,truck,pickup,conveyor,brush_cutter,generator,pressure_washer,blower,water_pump")
                .OldAnnotation("Npgsql:Enum:public.family_relationship_enum", "none,spouse,child,parent,sibling,other")
                .OldAnnotation("Npgsql:Enum:public.fault_severity_enum", "minor,serious,very_serious")
                .OldAnnotation("Npgsql:Enum:public.fault_source_enum", "manual,system_escalation,biometric_clock")
                .OldAnnotation("Npgsql:Enum:public.fault_status_enum", "open,sanction_applied,prescribed,cancelled")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.inventory_outputs_status_enum", "output_pending,dispatched,in_progress,rejected")
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
                .OldAnnotation("Npgsql:Enum:public.personnel_action_scope_enum", "individual,group,by_area")
                .OldAnnotation("Npgsql:Enum:public.personnel_action_status_enum", "draft,pending_approval,approved,rejected,applied,cancelled")
                .OldAnnotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .OldAnnotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .OldAnnotation("Npgsql:Enum:public.product_status_enum", "active,inactive,low_process")
                .OldAnnotation("Npgsql:Enum:public.product_stock_status_enum", "stable,low_balance,empty")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "administrative,operational")
                .OldAnnotation("Npgsql:Enum:public.purchase_order_status_enum", "pending,generated")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.reason_use_enum", "sale,operation")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.sanction_status_enum", "applied,cancelled,pending")
                .OldAnnotation("Npgsql:Enum:public.sanction_type_enum", "verbal_warning,memorandum,suspension,commitment_letter,termination")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .OldAnnotation("Npgsql:Enum:public.supplier_type_enum", "international,ordinary")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .OldAnnotation("Npgsql:Enum:public.termination_status_enum", "pending,closed,cancelled")
                .OldAnnotation("Npgsql:Enum:public.termination_type_enum", "voluntary_resignation,mutual_agreement,justified_dismissal,unjustified_dismissal,contract_expiration,work_completion,employee_death,retirement")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AddColumn<DateOnly>(
                name: "closed_at",
                schema: "public",
                table: "payrolls",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "closed_by_user_id",
                schema: "public",
                table: "payrolls",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "christmas_bonus_days",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(9,4)",
                precision: 9,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<int>(
                name: "accrual_month",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "accrual_year",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "accrued_amount",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "accrued_amount_in_dollars",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "base_salary_snapshot",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "christmas_bonus_period_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "covered_from",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "covered_to",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<decimal>(
                name: "eligible_days",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(9,4)",
                precision: 9,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "christmas_bonus_periods",
                schema: "public",
                columns: table => new
                {
                    christmas_bonus_period_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    end_year = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<int>(type: "christmas_bonus_period_status_enum", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_christmas_bonus_periods", x => x.christmas_bonus_period_id);
                    table.CheckConstraint("ck_christmas_bonus_periods_dates", "\"end_date\" >= \"start_date\"");
                    table.ForeignKey(
                        name: "FK_christmas_bonus_periods_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exchange_rate_histories",
                schema: "public",
                columns: table => new
                {
                    exchange_rate_history_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    currency = table.Column<int>(type: "currency_enum", nullable: false),
                    rate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    effective_from = table.Column<DateOnly>(type: "date", nullable: false),
                    effective_to = table.Column<DateOnly>(type: "date", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exchange_rate_histories", x => x.exchange_rate_history_id);
                    table.CheckConstraint("ck_exchange_rate_histories_dates", "\"effective_to\" IS NULL OR \"effective_to\" >= \"effective_from\"");
                    table.CheckConstraint("ck_exchange_rate_histories_rate", "\"rate\" > 0");
                });

            migrationBuilder.CreateTable(
                name: "christmas_bonus_advances",
                schema: "public",
                columns: table => new
                {
                    christmas_bonus_advance_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    christmas_bonus_period_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: true),
                    currency = table.Column<int>(type: "currency_enum", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    status = table.Column<int>(type: "christmas_bonus_advance_status_enum", nullable: false),
                    requested_at = table.Column<DateOnly>(type: "date", nullable: false),
                    requested_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    approved_at = table.Column<DateOnly>(type: "date", nullable: true),
                    approved_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    paid_at = table.Column<DateOnly>(type: "date", nullable: true),
                    paid_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    cancelled_at = table.Column<DateOnly>(type: "date", nullable: true),
                    cancelled_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    cancellation_reason = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_christmas_bonus_advances", x => x.christmas_bonus_advance_id);
                    table.CheckConstraint("ck_christmas_bonus_advances_amount", "\"amount\" > 0");
                    table.ForeignKey(
                        name: "FK_christmas_bonus_advances_christmas_bonus_periods_christmas_~",
                        column: x => x.christmas_bonus_period_id,
                        principalSchema: "public",
                        principalTable: "christmas_bonus_periods",
                        principalColumn: "christmas_bonus_period_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_advances_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_advances_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_advances_users_approved_by_id",
                        column: x => x.approved_by_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_advances_users_cancelled_by_id",
                        column: x => x.cancelled_by_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_advances_users_paid_by_id",
                        column: x => x.paid_by_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_advances_users_requested_by_id",
                        column: x => x.requested_by_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "christmas_bonus_settlements",
                schema: "public",
                columns: table => new
                {
                    christmas_bonus_settlement_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    christmas_bonus_period_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: true),
                    type = table.Column<int>(type: "christmas_bonus_settlement_type_enum", nullable: false),
                    status = table.Column<int>(type: "christmas_bonus_settlement_status_enum", nullable: false),
                    cutoff_date = table.Column<DateOnly>(type: "date", nullable: false),
                    salary_type_snapshot = table.Column<int>(type: "salary_type_enum", nullable: false),
                    reference_salary = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    eligible_days = table.Column<decimal>(type: "numeric(9,4)", precision: 9, scale: 4, nullable: false),
                    christmas_bonus_days = table.Column<decimal>(type: "numeric(9,4)", precision: 9, scale: 4, nullable: false),
                    gross_entitlement = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    advances_paid = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    child_support_withholding = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    amount_to_pay = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    amount_to_pay_in_dollars = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: true),
                    paid_at = table.Column<DateOnly>(type: "date", nullable: true),
                    paid_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_christmas_bonus_settlements", x => x.christmas_bonus_settlement_id);
                    table.CheckConstraint("ck_christmas_bonus_settlements_advances", "\"advances_paid\" >= 0");
                    table.CheckConstraint("ck_christmas_bonus_settlements_amount_to_pay", "\"amount_to_pay\" >= 0");
                    table.CheckConstraint("ck_christmas_bonus_settlements_amount_to_pay_dollars", "\"amount_to_pay_in_dollars\" IS NULL OR \"amount_to_pay_in_dollars\" >= 0");
                    table.CheckConstraint("ck_christmas_bonus_settlements_child_support", "\"child_support_withholding\" >= 0");
                    table.CheckConstraint("ck_christmas_bonus_settlements_days", "\"christmas_bonus_days\" >= 0");
                    table.CheckConstraint("ck_christmas_bonus_settlements_eligible_days", "\"eligible_days\" >= 0");
                    table.CheckConstraint("ck_christmas_bonus_settlements_gross", "\"gross_entitlement\" >= 0");
                    table.CheckConstraint("ck_christmas_bonus_settlements_reference_salary", "\"reference_salary\" >= 0");
                    table.ForeignKey(
                        name: "FK_christmas_bonus_settlements_christmas_bonus_periods_christm~",
                        column: x => x.christmas_bonus_period_id,
                        principalSchema: "public",
                        principalTable: "christmas_bonus_periods",
                        principalColumn: "christmas_bonus_period_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_settlements_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_settlements_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_settlements_users_paid_by_id",
                        column: x => x.paid_by_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_salaries_collaborator_dates",
                schema: "public",
                table: "salaries",
                columns: new[] { "collaborator_id", "start_date", "end_date" });

            migrationBuilder.CreateIndex(
                name: "ux_salaries_collaborator_active",
                schema: "public",
                table: "salaries",
                column: "collaborator_id",
                unique: true,
                filter: "\"end_date\" IS NULL AND \"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_payrolls_closed_by_user_id",
                schema: "public",
                table: "payrolls",
                column: "closed_by_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_accruals_collaborator_period",
                schema: "public",
                table: "christmas_bonus_accruals",
                columns: new[] { "collaborator_id", "christmas_bonus_period_id" });

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_accruals_period_year_month",
                schema: "public",
                table: "christmas_bonus_accruals",
                columns: new[] { "christmas_bonus_period_id", "accrual_year", "accrual_month" });

            migrationBuilder.CreateIndex(
                name: "ux_christmas_bonus_accruals_period_collaborator_year_month",
                schema: "public",
                table: "christmas_bonus_accruals",
                columns: new[] { "christmas_bonus_period_id", "collaborator_id", "accrual_year", "accrual_month" },
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.AddCheckConstraint(
                name: "ck_christmas_bonus_accruals_amount",
                schema: "public",
                table: "christmas_bonus_accruals",
                sql: "\"accrued_amount\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "ck_christmas_bonus_accruals_amount_in_dollars",
                schema: "public",
                table: "christmas_bonus_accruals",
                sql: "\"accrued_amount_in_dollars\" IS NULL OR \"accrued_amount_in_dollars\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "ck_christmas_bonus_accruals_base_salary",
                schema: "public",
                table: "christmas_bonus_accruals",
                sql: "\"base_salary_snapshot\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "ck_christmas_bonus_accruals_covered_dates",
                schema: "public",
                table: "christmas_bonus_accruals",
                sql: "\"covered_to\" >= \"covered_from\"");

            migrationBuilder.AddCheckConstraint(
                name: "ck_christmas_bonus_accruals_days",
                schema: "public",
                table: "christmas_bonus_accruals",
                sql: "\"christmas_bonus_days\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "ck_christmas_bonus_accruals_eligible_days",
                schema: "public",
                table: "christmas_bonus_accruals",
                sql: "\"eligible_days\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "ck_christmas_bonus_accruals_month",
                schema: "public",
                table: "christmas_bonus_accruals",
                sql: "\"accrual_month\" >= 1 AND \"accrual_month\" <= 12");

            migrationBuilder.AddCheckConstraint(
                name: "ck_christmas_bonus_accruals_year",
                schema: "public",
                table: "christmas_bonus_accruals",
                sql: "\"accrual_year\" > 0");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_advances_approved_by_id",
                schema: "public",
                table: "christmas_bonus_advances",
                column: "approved_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_advances_cancelled_by_id",
                schema: "public",
                table: "christmas_bonus_advances",
                column: "cancelled_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_advances_christmas_bonus_period_id",
                schema: "public",
                table: "christmas_bonus_advances",
                column: "christmas_bonus_period_id");

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_advances_collaborator_period_status",
                schema: "public",
                table: "christmas_bonus_advances",
                columns: new[] { "collaborator_id", "christmas_bonus_period_id", "status" });

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_advances_paid_by_id",
                schema: "public",
                table: "christmas_bonus_advances",
                column: "paid_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_advances_payroll_id",
                schema: "public",
                table: "christmas_bonus_advances",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_advances_requested_by_id",
                schema: "public",
                table: "christmas_bonus_advances",
                column: "requested_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_periods_company_id_dates",
                schema: "public",
                table: "christmas_bonus_periods",
                columns: new[] { "company_id", "start_date", "end_date" });

            migrationBuilder.CreateIndex(
                name: "ux_christmas_bonus_periods_company_id_end_year",
                schema: "public",
                table: "christmas_bonus_periods",
                columns: new[] { "company_id", "end_year" },
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_settlements_collaborator_id",
                schema: "public",
                table: "christmas_bonus_settlements",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_settlements_paid_by_id",
                schema: "public",
                table: "christmas_bonus_settlements",
                column: "paid_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_settlements_payroll_id",
                schema: "public",
                table: "christmas_bonus_settlements",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ux_christmas_bonus_settlements_period_collaborator",
                schema: "public",
                table: "christmas_bonus_settlements",
                columns: new[] { "christmas_bonus_period_id", "collaborator_id" },
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "ix_exchange_rate_histories_currency_dates",
                schema: "public",
                table: "exchange_rate_histories",
                columns: new[] { "currency", "effective_from", "effective_to" });

            migrationBuilder.CreateIndex(
                name: "ux_exchange_rate_histories_currency_effective_from",
                schema: "public",
                table: "exchange_rate_histories",
                columns: new[] { "currency", "effective_from" },
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_christmas_bonus_accruals_christmas_bonus_periods_christmas_~",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "christmas_bonus_period_id",
                principalSchema: "public",
                principalTable: "christmas_bonus_periods",
                principalColumn: "christmas_bonus_period_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_christmas_bonus_accruals_collaborators_collaborator_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_christmas_bonus_accruals_payrolls_payroll_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "payroll_id",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payrolls_users_closed_by_user_id",
                schema: "public",
                table: "payrolls",
                column: "closed_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_collaborators_collaborator_id",
                schema: "public",
                table: "salaries",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_christmas_bonus_accruals_christmas_bonus_periods_christmas_~",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropForeignKey(
                name: "FK_christmas_bonus_accruals_collaborators_collaborator_id",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropForeignKey(
                name: "FK_christmas_bonus_accruals_payrolls_payroll_id",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropForeignKey(
                name: "FK_payrolls_users_closed_by_user_id",
                schema: "public",
                table: "payrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_salaries_collaborators_collaborator_id",
                schema: "public",
                table: "salaries");

            migrationBuilder.DropTable(
                name: "christmas_bonus_advances",
                schema: "public");

            migrationBuilder.DropTable(
                name: "christmas_bonus_settlements",
                schema: "public");

            migrationBuilder.DropTable(
                name: "exchange_rate_histories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "christmas_bonus_periods",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_salaries_collaborator_dates",
                schema: "public",
                table: "salaries");

            migrationBuilder.DropIndex(
                name: "ux_salaries_collaborator_active",
                schema: "public",
                table: "salaries");

            migrationBuilder.DropIndex(
                name: "IX_payrolls_closed_by_user_id",
                schema: "public",
                table: "payrolls");

            migrationBuilder.DropIndex(
                name: "ix_christmas_bonus_accruals_collaborator_period",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropIndex(
                name: "ix_christmas_bonus_accruals_period_year_month",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropIndex(
                name: "ux_christmas_bonus_accruals_period_collaborator_year_month",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropCheckConstraint(
                name: "ck_christmas_bonus_accruals_amount",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropCheckConstraint(
                name: "ck_christmas_bonus_accruals_amount_in_dollars",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropCheckConstraint(
                name: "ck_christmas_bonus_accruals_base_salary",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropCheckConstraint(
                name: "ck_christmas_bonus_accruals_covered_dates",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropCheckConstraint(
                name: "ck_christmas_bonus_accruals_days",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropCheckConstraint(
                name: "ck_christmas_bonus_accruals_eligible_days",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropCheckConstraint(
                name: "ck_christmas_bonus_accruals_month",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropCheckConstraint(
                name: "ck_christmas_bonus_accruals_year",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "closed_at",
                schema: "public",
                table: "payrolls");

            migrationBuilder.DropColumn(
                name: "closed_by_user_id",
                schema: "public",
                table: "payrolls");

            migrationBuilder.DropColumn(
                name: "accrual_month",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "accrual_year",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "accrued_amount",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "accrued_amount_in_dollars",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "base_salary_snapshot",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "christmas_bonus_period_id",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "covered_from",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "covered_to",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "eligible_days",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.RenameIndex(
                name: "ix_christmas_bonus_accruals_payroll_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                newName: "IX_christmas_bonus_accruals_payroll_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.absence_source_enum", "manual,biometric_clock")
                .Annotation("Npgsql:Enum:public.absence_status_enum", "pending,applied,cancelled")
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.assignment_collaborators_roles_enum", "warehouse_assistant,forklift_operator")
                .Annotation("Npgsql:Enum:public.assignment_operational_status_enum", "none,pending,in_progress,on_hold,downloaded")
                .Annotation("Npgsql:Enum:public.bank_account_type_enum", "savings,checking")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments,purchase_rejection_reasons")
                .Annotation("Npgsql:Enum:public.category_type_enum", "administrative,operational")
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
                .Annotation("Npgsql:Enum:public.equipment_status_enum", "available,in_use,in_maintenance,out_of_service")
                .Annotation("Npgsql:Enum:public.equipment_type_enum", "forklift,wheel_loader,truck,pickup,conveyor,brush_cutter,generator,pressure_washer,blower,water_pump")
                .Annotation("Npgsql:Enum:public.family_relationship_enum", "none,spouse,child,parent,sibling,other")
                .Annotation("Npgsql:Enum:public.fault_severity_enum", "minor,serious,very_serious")
                .Annotation("Npgsql:Enum:public.fault_source_enum", "manual,system_escalation,biometric_clock")
                .Annotation("Npgsql:Enum:public.fault_status_enum", "open,sanction_applied,prescribed,cancelled")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.inventory_outputs_status_enum", "output_pending,dispatched,in_progress,rejected")
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
                .Annotation("Npgsql:Enum:public.personnel_action_scope_enum", "individual,group,by_area")
                .Annotation("Npgsql:Enum:public.personnel_action_status_enum", "draft,pending_approval,approved,rejected,applied,cancelled")
                .Annotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .Annotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .Annotation("Npgsql:Enum:public.product_status_enum", "active,inactive,low_process")
                .Annotation("Npgsql:Enum:public.product_stock_status_enum", "stable,low_balance,empty")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "administrative,operational")
                .Annotation("Npgsql:Enum:public.purchase_order_status_enum", "pending,generated")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.reason_use_enum", "sale,operation")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.sanction_status_enum", "applied,cancelled,pending")
                .Annotation("Npgsql:Enum:public.sanction_type_enum", "verbal_warning,memorandum,suspension,commitment_letter,termination")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .Annotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .Annotation("Npgsql:Enum:public.supplier_type_enum", "international,ordinary")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .Annotation("Npgsql:Enum:public.termination_status_enum", "pending,closed,cancelled")
                .Annotation("Npgsql:Enum:public.termination_type_enum", "voluntary_resignation,mutual_agreement,justified_dismissal,unjustified_dismissal,contract_expiration,work_completion,employee_death,retirement")
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
                .OldAnnotation("Npgsql:Enum:public.category_type_enum", "administrative,operational")
                .OldAnnotation("Npgsql:Enum:public.christmas_bonus_advance_status_enum", "pending,approved,paid,cancelled")
                .OldAnnotation("Npgsql:Enum:public.christmas_bonus_period_status_enum", "active,completed,settled")
                .OldAnnotation("Npgsql:Enum:public.christmas_bonus_settlement_status_enum", "calculated,paid")
                .OldAnnotation("Npgsql:Enum:public.christmas_bonus_settlement_type_enum", "annual,employment_termination")
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
                .OldAnnotation("Npgsql:Enum:public.equipment_status_enum", "available,in_use,in_maintenance,out_of_service")
                .OldAnnotation("Npgsql:Enum:public.equipment_type_enum", "forklift,wheel_loader,truck,pickup,conveyor,brush_cutter,generator,pressure_washer,blower,water_pump")
                .OldAnnotation("Npgsql:Enum:public.family_relationship_enum", "none,spouse,child,parent,sibling,other")
                .OldAnnotation("Npgsql:Enum:public.fault_severity_enum", "minor,serious,very_serious")
                .OldAnnotation("Npgsql:Enum:public.fault_source_enum", "manual,system_escalation,biometric_clock")
                .OldAnnotation("Npgsql:Enum:public.fault_status_enum", "open,sanction_applied,prescribed,cancelled")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.inventory_outputs_status_enum", "output_pending,dispatched,in_progress,rejected")
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
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services,christmas_bonus")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay,judicial_appointment,marriage_leave,birth_leave,bereavement_leave")
                .OldAnnotation("Npgsql:Enum:public.permit_beneficiary_scope_enum", "none,own,family_nucleus")
                .OldAnnotation("Npgsql:Enum:public.personnel_action_scope_enum", "individual,group,by_area")
                .OldAnnotation("Npgsql:Enum:public.personnel_action_status_enum", "draft,pending_approval,approved,rejected,applied,cancelled")
                .OldAnnotation("Npgsql:Enum:public.priority_level_enum", "none,critical,unforeseen,normal,printed_stationery")
                .OldAnnotation("Npgsql:Enum:public.product_quality_enum", "excellent,good,regular,poor,damaged")
                .OldAnnotation("Npgsql:Enum:public.product_status_enum", "active,inactive,low_process")
                .OldAnnotation("Npgsql:Enum:public.product_stock_status_enum", "stable,low_balance,empty")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "administrative,operational")
                .OldAnnotation("Npgsql:Enum:public.purchase_order_status_enum", "pending,generated")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked,reserved")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.reason_use_enum", "sale,operation")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.sanction_status_enum", "applied,cancelled,pending")
                .OldAnnotation("Npgsql:Enum:public.sanction_type_enum", "verbal_warning,memorandum,suspension,commitment_letter,termination")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .OldAnnotation("Npgsql:Enum:public.supplier_type_enum", "international,ordinary")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .OldAnnotation("Npgsql:Enum:public.termination_status_enum", "pending,closed,cancelled")
                .OldAnnotation("Npgsql:Enum:public.termination_type_enum", "voluntary_resignation,mutual_agreement,justified_dismissal,unjustified_dismissal,contract_expiration,work_completion,employee_death,retirement")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<decimal>(
                name: "christmas_bonus_days",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(9,4)",
                oldPrecision: 9,
                oldScale: 4);

            migrationBuilder.AddColumn<decimal>(
                name: "base_salary",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "equivalent_quantity",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "equivalent_quantity_in_dollars",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_salaries_collaborator_id",
                schema: "public",
                table: "salaries",
                column: "collaborator_id",
                unique: true,
                filter: "\"end_date\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_collaborator_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_christmas_bonus_accruals_collaborators_collaborator_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_christmas_bonus_accruals_payrolls_payroll_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "payroll_id",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_collaborators_collaborator_id",
                schema: "public",
                table: "salaries",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
