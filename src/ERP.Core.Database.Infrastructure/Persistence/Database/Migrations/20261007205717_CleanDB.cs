using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CleanDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crew_assignments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry_details",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reassignment_session_ownership_log",
                schema: "public");

            migrationBuilder.DropTable(
                name: "stock_footprint_cells",
                schema: "public");

            migrationBuilder.DropTable(
                name: "stock_movement_events",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_pallets",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_position_reservations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_receipts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_task_events",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_task_ownership_log",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reassignment_memory_items",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_details",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_tasks",
                schema: "public");

            migrationBuilder.DropTable(
                name: "shipping_companies",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reassignment_sessions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "stocks",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_assignments",
                schema: "public");

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
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .Annotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .Annotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
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
                .OldAnnotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                .Annotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .Annotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
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
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "racks,lots,pallets,none")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.service_order_requisition_status_enum", "pending,approved,rejected,canceled")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.supplier_exclusive_status_enum", "none,pending_review,approved,rejected")
                .OldAnnotation("Npgsql:Enum:public.supplier_price_history_type_enum", "unit_price,preferential_price")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2,iva,imi,ir,ir_supplier_internation")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.transport_unit_enum", "container,van")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.unloading_merchandise_type_enum", "bulk,armed")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "fiscal,granel,nationalized")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "reassignment_sessions",
                schema: "public",
                columns: table => new
                {
                    reassignment_session_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    closed_at_date = table.Column<DateOnly>(type: "date", nullable: true),
                    closed_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    current_owner_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    opened_at_date = table.Column<DateOnly>(type: "date", nullable: false),
                    opened_at_Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    opened_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "reassignment_session_status_enum", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reassignment_sessions", x => x.reassignment_session_id);
                    table.ForeignKey(
                        name: "FK_reassignment_sessions_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shipping_companies",
                schema: "public",
                columns: table => new
                {
                    shipping_company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_companies", x => x.shipping_company_id);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                schema: "public",
                columns: table => new
                {
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    category_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    current_bultos = table.Column<int>(type: "integer", nullable: false),
                    current_weight_kg = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entrance_ducats_id = table.Column<Guid>(type: "uuid", nullable: false),
                    stored_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "warehouse_assignments",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    lots_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lots_positions_id = table.Column<Guid>(type: "uuid", nullable: true),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: true),
                    rack_positions_id = table.Column<Guid>(type: "uuid", nullable: true),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    assigned_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EntranceDucatId = table.Column<Guid>(type: "uuid", nullable: true),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    section_id = table.Column<Guid>(type: "uuid", nullable: true),
                    unloading_end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    unloading_start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    unloading_status = table.Column<int>(type: "unloading_status_enum", nullable: false, defaultValue: 1),
                    warehouse_keeper_user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_lots_lots_id",
                        column: x => x.lots_id,
                        principalSchema: "public",
                        principalTable: "lots",
                        principalColumn: "tramo_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_lots_positions_lots_positions_id",
                        column: x => x.lots_positions_id,
                        principalSchema: "public",
                        principalTable: "lots_positions",
                        principalColumn: "position_id");
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_rack_positions_rack_positions_id",
                        column: x => x.rack_positions_id,
                        principalSchema: "public",
                        principalTable: "rack_positions",
                        principalColumn: "position_id");
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_racks_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks",
                        principalColumn: "rack_id",
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
                name: "warehouse_receipts",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    customs_brokerage = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    customs_cif_value = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    receipt_cancellation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    receipt_creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    receipt_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    resa_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_receipts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_tasks",
                schema: "public",
                columns: table => new
                {
                    warehouse_task_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cancelled_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    closed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    current_owner_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    paused_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    started_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "warehouse_task_status_enum", nullable: false, defaultValue: 1),
                    task_type = table.Column<int>(type: "warehouse_task_type_enum", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_tasks", x => x.warehouse_task_id);
                    table.ForeignKey(
                        name: "FK_warehouse_tasks_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reassignment_session_ownership_log",
                schema: "public",
                columns: table => new
                {
                    reassignment_session_ownership_log_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    reassignment_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ended_at_date = table.Column<DateOnly>(type: "date", nullable: true),
                    ended_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    started_at_date = table.Column<DateOnly>(type: "date", nullable: false),
                    started_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reassignment_session_ownership_log", x => x.reassignment_session_ownership_log_id);
                    table.ForeignKey(
                        name: "FK_reassignment_session_ownership_log_reassignment_sessions_re~",
                        column: x => x.reassignment_session_id,
                        principalSchema: "public",
                        principalTable: "reassignment_sessions",
                        principalColumn: "reassignment_session_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry",
                schema: "public",
                columns: table => new
                {
                    ducat_registtry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    shipping_company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    general_observations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    is_in_transit = table.Column<bool>(type: "boolean", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    registered_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    registered_by_user_name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    registered_end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    registered_end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    registered_start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    registered_start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    status = table.Column<int>(type: "duca_status_enum", nullable: false, defaultValue: 1),
                    updated_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    updated_by_user_name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    updated_date = table.Column<DateOnly>(type: "date", nullable: true),
                    updated_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry", x => x.ducat_registtry_id);
                    table.ForeignKey(
                        name: "FK_ducat_registry_shipping_companies_shipping_company_id",
                        column: x => x.shipping_company_id,
                        principalSchema: "public",
                        principalTable: "shipping_companies",
                        principalColumn: "shipping_company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reassignment_memory_items",
                schema: "public",
                columns: table => new
                {
                    reassignment_memory_item_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    reassignment_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lifted_at_date = table.Column<DateOnly>(type: "date", nullable: false),
                    lifted_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    lifted_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    resolved_at_date = table.Column<DateOnly>(type: "date", nullable: true),
                    resolved_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    resolved_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    target_lot_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    target_rack_position_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reassignment_memory_items", x => x.reassignment_memory_item_id);
                    table.ForeignKey(
                        name: "FK_reassignment_memory_items_reassignment_sessions_reassignmen~",
                        column: x => x.reassignment_session_id,
                        principalSchema: "public",
                        principalTable: "reassignment_sessions",
                        principalColumn: "reassignment_session_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reassignment_memory_items_stocks_stock_id",
                        column: x => x.stock_id,
                        principalSchema: "public",
                        principalTable: "stocks",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stock_footprint_cells",
                schema: "public",
                columns: table => new
                {
                    stock_footprint_cell_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false),
                    column_offset = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    row_offset = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_footprint_cells", x => x.stock_footprint_cell_id);
                    table.ForeignKey(
                        name: "FK_stock_footprint_cells_stocks_stock_id",
                        column: x => x.stock_id,
                        principalSchema: "public",
                        principalTable: "stocks",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "crew_assignments",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_assignment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    invoice_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    is_outsourced = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    person_count = table.Column<int>(type: "integer", nullable: true),
                    provider_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
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
                name: "unloading_details",
                schema: "public",
                columns: table => new
                {
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_assignment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    merchandise_type = table.Column<int>(type: "unloading_merchandise_type_enum", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_details", x => x.unloading_details_id);
                    table.ForeignKey(
                        name: "FK_unloading_details_warehouse_assignments_warehouse_assignmen~",
                        column: x => x.warehouse_assignment_id,
                        principalSchema: "public",
                        principalTable: "warehouse_assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_position_reservations",
                schema: "public",
                columns: table => new
                {
                    unloading_position_reservations_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_assignment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lot_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    rack_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    reserved_at_date = table.Column<DateOnly>(type: "date", nullable: false),
                    reserved_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    reserved_by_user_id = table.Column<string>(type: "text", nullable: false),
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: true),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_position_reservations", x => x.unloading_position_reservations_id);
                    table.ForeignKey(
                        name: "FK_unloading_position_reservations_warehouse_assignments_wareh~",
                        column: x => x.warehouse_assignment_id,
                        principalSchema: "public",
                        principalTable: "warehouse_assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_task_events",
                schema: "public",
                columns: table => new
                {
                    warehouse_task_event_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_task_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    event_type = table.Column<int>(type: "warehouse_task_event_type_enum", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true),
                    occurred_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "warehouse_task_status_enum", nullable: true),
                    user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_task_events", x => x.warehouse_task_event_id);
                    table.ForeignKey(
                        name: "FK_warehouse_task_events_warehouse_tasks_warehouse_task_id",
                        column: x => x.warehouse_task_id,
                        principalSchema: "public",
                        principalTable: "warehouse_tasks",
                        principalColumn: "warehouse_task_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_task_ownership_log",
                schema: "public",
                columns: table => new
                {
                    warehouse_task_ownership_log_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_task_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    new_owner_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    previous_owner_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    transferred_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    transferred_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_task_ownership_log", x => x.warehouse_task_ownership_log_id);
                    table.ForeignKey(
                        name: "FK_warehouse_task_ownership_log_warehouse_tasks_warehouse_task~",
                        column: x => x.warehouse_task_id,
                        principalSchema: "public",
                        principalTable: "warehouse_tasks",
                        principalColumn: "warehouse_task_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry_details",
                schema: "public",
                columns: table => new
                {
                    ducat_registry_detail_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ducat_registry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    destination_area_observation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    merchandise_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    merchandise_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    registered_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    registered_by_user_name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    registered_end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    registered_end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    registered_start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    registered_start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    sender = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    total_bultos = table.Column<int>(type: "integer", nullable: false),
                    total_weight = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    type = table.Column<int>(type: "duca_type_enum", nullable: false, defaultValue: 2),
                    updated_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    updated_by_user_name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    updated_date = table.Column<DateOnly>(type: "date", nullable: true),
                    updated_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry_details", x => x.ducat_registry_detail_id);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_ducat_registry_ducat_registry_id",
                        column: x => x.ducat_registry_id,
                        principalSchema: "public",
                        principalTable: "ducat_registry",
                        principalColumn: "ducat_registtry_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stock_movement_events",
                schema: "public",
                columns: table => new
                {
                    stock_movement_event_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    reassignment_memory_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reassignment_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false),
                    confirmed_at_date = table.Column<DateOnly>(type: "date", nullable: false),
                    confirmed_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    confirmed_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_movement_events", x => x.stock_movement_event_id);
                    table.ForeignKey(
                        name: "FK_stock_movement_events_reassignment_memory_items_reassignmen~",
                        column: x => x.reassignment_memory_item_id,
                        principalSchema: "public",
                        principalTable: "reassignment_memory_items",
                        principalColumn: "reassignment_memory_item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_movement_events_reassignment_sessions_reassignment_se~",
                        column: x => x.reassignment_session_id,
                        principalSchema: "public",
                        principalTable: "reassignment_sessions",
                        principalColumn: "reassignment_session_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_movement_events_stocks_stock_id",
                        column: x => x.stock_id,
                        principalSchema: "public",
                        principalTable: "stocks",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_pallets",
                schema: "public",
                columns: table => new
                {
                    unloading_pallets_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    length_metres = table.Column<decimal>(type: "numeric(6,2)", nullable: true),
                    pallet_type = table.Column<int>(type: "pallet_type_enum", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    width_metres = table.Column<decimal>(type: "numeric(6,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_pallets", x => x.unloading_pallets_id);
                    table.ForeignKey(
                        name: "FK_unloading_pallets_unloading_details_unloading_details_id",
                        column: x => x.unloading_details_id,
                        principalSchema: "public",
                        principalTable: "unloading_details",
                        principalColumn: "unloading_details_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_crew_assignments_warehouse_assignment_id",
                schema: "public",
                table: "crew_assignments",
                column: "warehouse_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_shipping_company_id",
                schema: "public",
                table: "ducat_registry",
                column: "shipping_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_ducat_registry_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "ducat_registry_id");

            migrationBuilder.CreateIndex(
                name: "ix_reassignment_memory_items_session_id",
                schema: "public",
                table: "reassignment_memory_items",
                column: "reassignment_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_reassignment_memory_items_session_resolved_at",
                schema: "public",
                table: "reassignment_memory_items",
                columns: new[] { "reassignment_session_id", "resolved_at_date", "resolved_at_time" });

            migrationBuilder.CreateIndex(
                name: "ix_reassignment_memory_items_stock_id",
                schema: "public",
                table: "reassignment_memory_items",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_reassignment_session_ownership_log_session_id",
                schema: "public",
                table: "reassignment_session_ownership_log",
                column: "reassignment_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_reassignment_sessions_status",
                schema: "public",
                table: "reassignment_sessions",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_reassignment_sessions_warehouse_id",
                schema: "public",
                table: "reassignment_sessions",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_companies_name",
                schema: "public",
                table: "shipping_companies",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stock_footprint_cells_stock_id",
                schema: "public",
                table: "stock_footprint_cells",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_footprint_cells_stock_id_offsets",
                schema: "public",
                table: "stock_footprint_cells",
                columns: new[] { "stock_id", "row_offset", "column_offset" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_movement_events_reassignment_memory_item_id",
                schema: "public",
                table: "stock_movement_events",
                column: "reassignment_memory_item_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_movement_events_session_id",
                schema: "public",
                table: "stock_movement_events",
                column: "reassignment_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_movement_events_stock_id",
                schema: "public",
                table: "stock_movement_events",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_movement_events_stock_id_confirmed_at",
                schema: "public",
                table: "stock_movement_events",
                columns: new[] { "stock_id", "confirmed_at_date", "confirmed_at_time" });

            migrationBuilder.CreateIndex(
                name: "IX_stocks_category_product_id",
                schema: "public",
                table: "stocks",
                column: "category_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_details_warehouse_assignment_id",
                schema: "public",
                table: "unloading_details",
                column: "warehouse_assignment_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unloading_pallets_unloading_details_id",
                schema: "public",
                table: "unloading_pallets",
                column: "unloading_details_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_position_reservations_warehouse_assignment_id",
                schema: "public",
                table: "unloading_position_reservations",
                column: "warehouse_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_lots_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "lots_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_lots_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "lots_positions_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_rack_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "rack_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_rack_positions_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "rack_positions_id");

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
                name: "ix_warehouse_task_events_task_occurred_at",
                schema: "public",
                table: "warehouse_task_events",
                columns: new[] { "warehouse_task_id", "occurred_at" });

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_task_ownership_log_task_transferred_at",
                schema: "public",
                table: "warehouse_task_ownership_log",
                columns: new[] { "warehouse_task_id", "transferred_at" });

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_tasks_company_warehouse_status",
                schema: "public",
                table: "warehouse_tasks",
                columns: new[] { "warehouse_id", "status" });

            migrationBuilder.CreateIndex(
                name: "ux_warehouse_tasks_type_source",
                schema: "public",
                table: "warehouse_tasks",
                columns: new[] { "task_type", "source_id" },
                unique: true);
        }
    }
}
