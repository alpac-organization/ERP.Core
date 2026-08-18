using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSectionMerchandiseRegistry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_ducat_registry_record_entrance_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "empresa",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.RenameColumn(
                name: "remitente",
                schema: "public",
                table: "ducat_registry_details",
                newName: "sender");

            migrationBuilder.RenameColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "ducat_registry_id");

            migrationBuilder.RenameColumn(
                name: "product_description",
                schema: "public",
                table: "ducat_registry_details",
                newName: "merchandise_description");

            migrationBuilder.RenameIndex(
                name: "IX_ducat_registry_details_record_entrance_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "IX_ducat_registry_details_ducat_registry_id");

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

            migrationBuilder.AddColumn<int>(
                name: "type",
                schema: "public",
                table: "ducat_registry_details",
                type: "duca_type_enum",
                nullable: false,
                defaultValueSql: "'duca_d'::duca_type_enum");

            migrationBuilder.AddColumn<Guid>(
                name: "ShippingCompaniesId",
                schema: "public",
                table: "ducat_registry",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "shipping_company_id",
                schema: "public",
                table: "ducat_registry",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "shipping_companies",
                schema: "public",
                columns: table => new
                {
                    shipping_company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_companies", x => x.shipping_company_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_shipping_company_id",
                schema: "public",
                table: "ducat_registry",
                column: "shipping_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_ShippingCompaniesId",
                schema: "public",
                table: "ducat_registry",
                column: "ShippingCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_companies_name",
                schema: "public",
                table: "shipping_companies",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_shipping_companies_ShippingCompaniesId",
                schema: "public",
                table: "ducat_registry",
                column: "ShippingCompaniesId",
                principalSchema: "public",
                principalTable: "shipping_companies",
                principalColumn: "shipping_company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_shipping_companies_shipping_company_id",
                schema: "public",
                table: "ducat_registry",
                column: "shipping_company_id",
                principalSchema: "public",
                principalTable: "shipping_companies",
                principalColumn: "shipping_company_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_ducat_registry_ducat_registry_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "ducat_registry_id",
                principalSchema: "public",
                principalTable: "ducat_registry",
                principalColumn: "ducat_registtry_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_shipping_companies_ShippingCompaniesId",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_shipping_companies_shipping_company_id",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_ducat_registry_ducat_registry_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropTable(
                name: "shipping_companies",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_ducat_registry_shipping_company_id",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropIndex(
                name: "IX_ducat_registry_ShippingCompaniesId",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "type",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "ShippingCompaniesId",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "shipping_company_id",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.RenameColumn(
                name: "sender",
                schema: "public",
                table: "ducat_registry_details",
                newName: "remitente");

            migrationBuilder.RenameColumn(
                name: "merchandise_description",
                schema: "public",
                table: "ducat_registry_details",
                newName: "product_description");

            migrationBuilder.RenameColumn(
                name: "ducat_registry_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "record_entrance_id");

            migrationBuilder.RenameIndex(
                name: "IX_ducat_registry_details_ducat_registry_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "IX_ducat_registry_details_record_entrance_id");

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

            migrationBuilder.AddColumn<string>(
                name: "empresa",
                schema: "public",
                table: "ducat_registry",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_ducat_registry_record_entrance_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "ducat_registry",
                principalColumn: "ducat_registtry_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
