using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSincronizacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_customers_customer_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_quotation",
                schema: "public",
                table: "quotation");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_sku",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "unit_of_measure",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "additional_date",
                schema: "public",
                table: "quotation");

            migrationBuilder.DropColumn(
                name: "approximate_cost_total",
                schema: "public",
                table: "quotation");

            migrationBuilder.RenameTable(
                name: "quotation",
                schema: "public",
                newName: "quotes",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                schema: "public",
                table: "products",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_products_customer_id",
                schema: "public",
                table: "products",
                newName: "IX_products_CustomerId");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
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
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "in_tail,in_unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .Annotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
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
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "in_tail,in_unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "product_name",
                schema: "public",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "product_usage_type",
                schema: "public",
                table: "products",
                type: "product_usage_type_enum",
                nullable: false,
                defaultValueSql: "'insumo'::product_usage_type_enum");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                schema: "public",
                table: "quotes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "QuotationCode",
                schema: "public",
                table: "quotes",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_quotes",
                schema: "public",
                table: "quotes",
                column: "quotation_id");

            migrationBuilder.CreateTable(
                name: "quotes_details",
                schema: "public",
                columns: table => new
                {
                    quote_detail_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    individual_price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    observations = table.Column<string>(type: "text", nullable: true),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false),
                    unit_measure_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    supplier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quotation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotes_details", x => x.quote_detail_id);
                    table.ForeignKey(
                        name: "FK_quotes_details_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quotes_details_quotes_quotation_id",
                        column: x => x.quotation_id,
                        principalSchema: "public",
                        principalTable: "quotes",
                        principalColumn: "quotation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quotes_details_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalSchema: "public",
                        principalTable: "suppliers",
                        principalColumn: "suppliers_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quotes_details_units_measurement_unit_measure_id",
                        column: x => x.unit_measure_id,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quotes_BranchId",
                schema: "public",
                table: "quotes",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_details_product_id",
                schema: "public",
                table: "quotes_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_details_quotation_id",
                schema: "public",
                table: "quotes_details",
                column: "quotation_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_details_supplier_id",
                schema: "public",
                table: "quotes_details",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_details_unit_measure_id",
                schema: "public",
                table: "quotes_details",
                column: "unit_measure_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_customers_CustomerId",
                schema: "public",
                table: "products",
                column: "CustomerId",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_branches_BranchId",
                schema: "public",
                table: "quotes",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_customers_CustomerId",
                schema: "public",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_quotes_branches_BranchId",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropTable(
                name: "quotes_details",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "PK_quotes",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropIndex(
                name: "IX_quotes_BranchId",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropColumn(
                name: "product_name",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_usage_type",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropColumn(
                name: "QuotationCode",
                schema: "public",
                table: "quotes");

            migrationBuilder.RenameTable(
                name: "quotes",
                schema: "public",
                newName: "quotation",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "public",
                table: "products",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_products_CustomerId",
                schema: "public",
                table: "products",
                newName: "IX_products_customer_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
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
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "in_tail,in_unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .Annotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.constitution_type_enum", "natural,legal")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status_enum", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions,judicial_seizures")
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
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "in_tail,in_unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "public",
                table: "products",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_sku",
                schema: "public",
                table: "products",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "unit_of_measure",
                schema: "public",
                table: "products",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "additional_date",
                schema: "public",
                table: "quotation",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "approximate_cost_total",
                schema: "public",
                table: "quotation",
                type: "numeric(18,0)",
                precision: 18,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_quotation",
                schema: "public",
                table: "quotation",
                column: "quotation_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_customers_customer_id",
                schema: "public",
                table: "products",
                column: "customer_id",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
