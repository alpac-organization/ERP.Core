using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRefactorizacionTablasCotizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotes_details_products_product_id",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropForeignKey(
                name: "FK_quotes_details_units_measurement_unit_measure_id",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropColumn(
                name: "address",
                schema: "public",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "contact_email",
                schema: "public",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "contact_name",
                schema: "public",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "contact_phone_number",
                schema: "public",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "additional_data",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropColumn(
                name: "amount",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropColumn(
                name: "color",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropColumn(
                name: "observations",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.RenameColumn(
                name: "email_support",
                schema: "public",
                table: "suppliers",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "unit_measure_id",
                schema: "public",
                table: "quotes_details",
                newName: "UnitMeasureId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "public",
                table: "quotes_details",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "individual_price",
                schema: "public",
                table: "quotes_details",
                newName: "approximate_total_cost");

            migrationBuilder.RenameIndex(
                name: "IX_quotes_details_unit_measure_id",
                schema: "public",
                table: "quotes_details",
                newName: "IX_quotes_details_UnitMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_quotes_details_product_id",
                schema: "public",
                table: "quotes_details",
                newName: "IX_quotes_details_ProductId");

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
                .Annotation("Npgsql:Enum:public.quotation_status_enum", "pending,approved,canceled,rejected")
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
                name: "UnitMeasureId",
                schema: "public",
                table: "quotes_details",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                schema: "public",
                table: "quotes_details",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "quotation_status",
                schema: "public",
                table: "quotes_details",
                type: "quotation_status_enum",
                nullable: false,
                defaultValueSql: "'pending'::quotation_status_enum");

            migrationBuilder.CreateTable(
                name: "quoted_products",
                schema: "public",
                columns: table => new
                {
                    quoted_product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_wholesale = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    price_per_unit = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    price_wholesale = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    equivalent_quantity = table.Column<int>(type: "integer", nullable: true),
                    additional_data = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}"),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unit_measure_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quote_detail_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quoted_products", x => x.quoted_product_id);
                    table.ForeignKey(
                        name: "FK_quoted_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quoted_products_quotes_details_quote_detail_id",
                        column: x => x.quote_detail_id,
                        principalSchema: "public",
                        principalTable: "quotes_details",
                        principalColumn: "quote_detail_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quoted_products_units_measurement_unit_measure_id",
                        column: x => x.unit_measure_id,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers_details",
                schema: "public",
                columns: table => new
                {
                    supplier_detail_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    address = table.Column<string>(type: "text", nullable: true),
                    email_support = table.Column<string>(type: "text", nullable: true),
                    contact_name = table.Column<string>(type: "text", nullable: true),
                    contact_email = table.Column<string>(type: "text", nullable: true),
                    contact_phone_number = table.Column<string>(type: "text", nullable: true),
                    CreditDays = table.Column<int>(type: "integer", nullable: false),
                    HasCredit = table.Column<bool>(type: "boolean", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers_details", x => x.supplier_detail_id);
                    table.ForeignKey(
                        name: "FK_suppliers_details_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "public",
                        principalTable: "suppliers",
                        principalColumn: "suppliers_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quoted_products_product_id",
                schema: "public",
                table: "quoted_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_quoted_products_quote_detail_id",
                schema: "public",
                table: "quoted_products",
                column: "quote_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_quoted_products_unit_measure_id",
                schema: "public",
                table: "quoted_products",
                column: "unit_measure_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_details_SupplierId",
                schema: "public",
                table: "suppliers_details",
                column: "SupplierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_details_products_ProductId",
                schema: "public",
                table: "quotes_details",
                column: "ProductId",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_details_units_measurement_UnitMeasureId",
                schema: "public",
                table: "quotes_details",
                column: "UnitMeasureId",
                principalSchema: "public",
                principalTable: "units_measurement",
                principalColumn: "unit_measure_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotes_details_products_ProductId",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropForeignKey(
                name: "FK_quotes_details_units_measurement_UnitMeasureId",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.DropTable(
                name: "quoted_products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "suppliers_details",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "quotation_status",
                schema: "public",
                table: "quotes_details");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                schema: "public",
                table: "suppliers",
                newName: "email_support");

            migrationBuilder.RenameColumn(
                name: "UnitMeasureId",
                schema: "public",
                table: "quotes_details",
                newName: "unit_measure_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "public",
                table: "quotes_details",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "approximate_total_cost",
                schema: "public",
                table: "quotes_details",
                newName: "individual_price");

            migrationBuilder.RenameIndex(
                name: "IX_quotes_details_UnitMeasureId",
                schema: "public",
                table: "quotes_details",
                newName: "IX_quotes_details_unit_measure_id");

            migrationBuilder.RenameIndex(
                name: "IX_quotes_details_ProductId",
                schema: "public",
                table: "quotes_details",
                newName: "IX_quotes_details_product_id");

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
                .OldAnnotation("Npgsql:Enum:public.product_usage_type_enum", "insumo,operational_use")
                .OldAnnotation("Npgsql:Enum:public.quotation_status_enum", "pending,approved,canceled,rejected")
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

            migrationBuilder.AddColumn<string>(
                name: "address",
                schema: "public",
                table: "suppliers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contact_email",
                schema: "public",
                table: "suppliers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contact_name",
                schema: "public",
                table: "suppliers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contact_phone_number",
                schema: "public",
                table: "suppliers",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "unit_measure_id",
                schema: "public",
                table: "quotes_details",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "product_id",
                schema: "public",
                table: "quotes_details",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "additional_data",
                schema: "public",
                table: "quotes_details",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                schema: "public",
                table: "quotes_details",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "color",
                schema: "public",
                table: "quotes_details",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "observations",
                schema: "public",
                table: "quotes_details",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_details_products_product_id",
                schema: "public",
                table: "quotes_details",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_details_units_measurement_unit_measure_id",
                schema: "public",
                table: "quotes_details",
                column: "unit_measure_id",
                principalSchema: "public",
                principalTable: "units_measurement",
                principalColumn: "unit_measure_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
