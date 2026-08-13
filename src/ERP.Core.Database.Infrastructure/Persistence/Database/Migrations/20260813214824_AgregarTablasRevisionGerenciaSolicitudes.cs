using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablasRevisionGerenciaSolicitudes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .Annotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .Annotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .Annotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .Annotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "empty,racks,lots")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
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
                .OldAnnotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .OldAnnotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "empty,racks,lots")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "requisition_management_reviews",
                schema: "public",
                columns: table => new
                {
                    requisition_management_review_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    comments = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    send_to_review_at = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "management_review_status_enum", nullable: false, defaultValueSql: "'pending'::management_review_status_enum"),
                    send_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reviewed_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    purchase_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisition_management_reviews", x => x.requisition_management_review_id);
                    table.ForeignKey(
                        name: "FK_requisition_management_reviews_purchase_requests_purchase_r~",
                        column: x => x.purchase_request_id,
                        principalSchema: "public",
                        principalTable: "purchase_requests",
                        principalColumn: "purchase_request_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisition_management_reviews_users_reviewed_by_user_id",
                        column: x => x.reviewed_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisition_management_reviews_users_send_by_user_id",
                        column: x => x.send_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requisition_management_reviews_purchase_request_id",
                schema: "public",
                table: "requisition_management_reviews",
                column: "purchase_request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requisition_management_reviews_reviewed_by_user_id",
                schema: "public",
                table: "requisition_management_reviews",
                column: "reviewed_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requisition_management_reviews_send_by_user_id",
                schema: "public",
                table: "requisition_management_reviews",
                column: "send_by_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requisition_management_reviews",
                schema: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.accounting_review_status_enum", "pending,approved,rejected,returned")
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
                .Annotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .Annotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .Annotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .Annotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .Annotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked")
                .Annotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.section_storage_type_enum", "empty,racks,lots")
                .Annotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
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
                .OldAnnotation("Npgsql:Enum:public.document_type_enum", "letter_collaborator_active,salary_letter,duca,customs_declaration")
                .OldAnnotation("Npgsql:Enum:public.duca_status_enum", "pending,completed")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia,ruc")
                .OldAnnotation("Npgsql:Enum:public.management_review_status_enum", "pending,approved,rejected,returned")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled,revision,finished")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.rack_status_enum", "available,occupied,under_maintenance,blocked")
                .OldAnnotation("Npgsql:Enum:public.rack_usage_profile_enum", "active_flow,static_hold")
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.section_storage_type_enum", "empty,racks,lots")
                .OldAnnotation("Npgsql:Enum:public.section_type_enum", "storage,aisle")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }
    }
}
