using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRefactorFinalSolicitudesCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_requests_users_user_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_quotes_branches_branch_id",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_quotes_users_created_by_user_id",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropTable(
                name: "quoted_products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "request_quoted_purchases",
                schema: "public");

            migrationBuilder.DropTable(
                name: "requested_products",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "PK_quotes",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropColumn(
                name: "observations",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropColumn(
                name: "quotation_code",
                schema: "public",
                table: "quotes");

            migrationBuilder.RenameTable(
                name: "quotes",
                schema: "public",
                newName: "quotations",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "public",
                table: "purchase_requests",
                newName: "registered_by_user_id");

            migrationBuilder.RenameColumn(
                name: "justification",
                schema: "public",
                table: "purchase_requests",
                newName: "observations");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_requests_user_id",
                schema: "public",
                table: "purchase_requests",
                newName: "IX_purchase_requests_registered_by_user_id");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "quotations",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "branch_id",
                schema: "public",
                table: "quotations",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "created_by_user_id",
                schema: "public",
                table: "quotations",
                newName: "supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_quotes_created_by_user_id",
                schema: "public",
                table: "quotations",
                newName: "IX_quotations_supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_quotes_branch_id",
                schema: "public",
                table: "quotations",
                newName: "IX_quotations_BranchId");

            migrationBuilder.AlterDatabase()
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
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.quotation_status_enum", "pending,revised")
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
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
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
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
                name: "BranchId",
                schema: "public",
                table: "quotations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "brand_product",
                schema: "public",
                table: "quotations",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "delivery_time",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "delivery_time_type",
                schema: "public",
                table: "quotations",
                type: "time_type_enum",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_delivery",
                schema: "public",
                table: "quotations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "has_guarantee",
                schema: "public",
                table: "quotations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "iva",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "price_total",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "price_unit",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "purchase_request_id",
                schema: "public",
                table: "quotations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "warranty_period",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "warranty_period_time_type",
                schema: "public",
                table: "quotations",
                type: "time_type_enum",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_quotations",
                schema: "public",
                table: "quotations",
                column: "quotation_id");

            migrationBuilder.CreateTable(
                name: "purchase_request_items",
                schema: "public",
                columns: table => new
                {
                    purchase_request_item_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    quantity_unit = table.Column<int>(type: "integer", nullable: true),
                    HasQuotation = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    justification = table.Column<string>(type: "text", nullable: true),
                    unit_measure_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchase_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_request_items", x => x.purchase_request_item_id);
                    table.ForeignKey(
                        name: "FK_purchase_request_items_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchase_request_items_purchase_requests_purchase_request_id",
                        column: x => x.purchase_request_id,
                        principalSchema: "public",
                        principalTable: "purchase_requests",
                        principalColumn: "purchase_request_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchase_request_items_units_measurement_unit_measure_id",
                        column: x => x.unit_measure_id,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_user_revision_id",
                schema: "public",
                table: "purchase_requests",
                column: "user_revision_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_purchase_request_id",
                schema: "public",
                table: "quotations",
                column: "purchase_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_request_items_product_id",
                schema: "public",
                table: "purchase_request_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_request_items_purchase_request_id",
                schema: "public",
                table: "purchase_request_items",
                column: "purchase_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_request_items_unit_measure_id",
                schema: "public",
                table: "purchase_request_items",
                column: "unit_measure_id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_requests_users_registered_by_user_id",
                schema: "public",
                table: "purchase_requests",
                column: "registered_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_requests_users_user_revision_id",
                schema: "public",
                table: "purchase_requests",
                column: "user_revision_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_quotations_branches_BranchId",
                schema: "public",
                table: "quotations",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotations_purchase_request_items_purchase_request_id",
                schema: "public",
                table: "quotations",
                column: "purchase_request_id",
                principalSchema: "public",
                principalTable: "purchase_request_items",
                principalColumn: "purchase_request_item_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_quotations_suppliers_supplier_id",
                schema: "public",
                table: "quotations",
                column: "supplier_id",
                principalSchema: "public",
                principalTable: "suppliers",
                principalColumn: "suppliers_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_requests_users_registered_by_user_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_requests_users_user_revision_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_quotations_branches_BranchId",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_quotations_purchase_request_items_purchase_request_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_quotations_suppliers_supplier_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropTable(
                name: "purchase_request_items",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_purchase_requests_user_revision_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_quotations",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropIndex(
                name: "IX_quotations_purchase_request_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "brand_product",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "delivery_time",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "delivery_time_type",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "has_delivery",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "has_guarantee",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "iva",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "price",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "price_total",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "price_unit",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "purchase_request_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "warranty_period",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "warranty_period_time_type",
                schema: "public",
                table: "quotations");

            migrationBuilder.RenameTable(
                name: "quotations",
                schema: "public",
                newName: "quotes",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "registered_by_user_id",
                schema: "public",
                table: "purchase_requests",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "observations",
                schema: "public",
                table: "purchase_requests",
                newName: "justification");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_requests_registered_by_user_id",
                schema: "public",
                table: "purchase_requests",
                newName: "IX_purchase_requests_user_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "quotes",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                schema: "public",
                table: "quotes",
                newName: "branch_id");

            migrationBuilder.RenameColumn(
                name: "supplier_id",
                schema: "public",
                table: "quotes",
                newName: "created_by_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_quotations_supplier_id",
                schema: "public",
                table: "quotes",
                newName: "IX_quotes_created_by_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_quotations_BranchId",
                schema: "public",
                table: "quotes",
                newName: "IX_quotes_branch_id");

            migrationBuilder.AlterDatabase()
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
                .Annotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled")
                .Annotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .Annotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
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
                .OldAnnotation("Npgsql:Enum:public.purchase_request_status_enum", "pending,approved,rejected,canceled")
                .OldAnnotation("Npgsql:Enum:public.purchase_request_type_enum", "requisition,eventual,monthly")
                .OldAnnotation("Npgsql:Enum:public.quotation_status_enum", "pending,revised")
                .OldAnnotation("Npgsql:Enum:public.record_entrance_status_enum", "queue,unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.time_type_enum", "day,month,year")
                .OldAnnotation("Npgsql:Enum:public.unit_measure_type_enum", "weight,volume,length,area,unit,time")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "quotes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "quotes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "observations",
                schema: "public",
                table: "quotes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "quotation_code",
                schema: "public",
                table: "quotes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_quotes",
                schema: "public",
                table: "quotes",
                column: "quotation_id");

            migrationBuilder.CreateTable(
                name: "quoted_products",
                schema: "public",
                columns: table => new
                {
                    quoted_product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quotation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unit_measure_id = table.Column<Guid>(type: "uuid", nullable: false),
                    additional_data = table.Column<string>(type: "jsonb", nullable: true, defaultValue: "{}"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ProductBrand = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity_per_unit = table.Column<decimal>(type: "numeric", nullable: true)
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
                        name: "FK_quoted_products_quotes_quotation_id",
                        column: x => x.quotation_id,
                        principalSchema: "public",
                        principalTable: "quotes",
                        principalColumn: "quotation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quoted_products_units_measurement_unit_measure_id",
                        column: x => x.unit_measure_id,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "request_quoted_purchases",
                schema: "public",
                columns: table => new
                {
                    request_quoted_purchases_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    purchase_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quotation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request_quoted_purchases", x => x.request_quoted_purchases_id);
                    table.ForeignKey(
                        name: "FK_request_quoted_purchases_purchase_requests_purchase_request~",
                        column: x => x.purchase_request_id,
                        principalSchema: "public",
                        principalTable: "purchase_requests",
                        principalColumn: "purchase_request_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_request_quoted_purchases_quotes_quotation_id",
                        column: x => x.quotation_id,
                        principalSchema: "public",
                        principalTable: "quotes",
                        principalColumn: "quotation_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "requested_products",
                schema: "public",
                columns: table => new
                {
                    requested_product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchase_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unit_measure_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    justification = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    quantity_unit = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requested_products", x => x.requested_product_id);
                    table.ForeignKey(
                        name: "FK_requested_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requested_products_purchase_requests_purchase_request_id",
                        column: x => x.purchase_request_id,
                        principalSchema: "public",
                        principalTable: "purchase_requests",
                        principalColumn: "purchase_request_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requested_products_units_measurement_unit_measure_id",
                        column: x => x.unit_measure_id,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quoted_products_product_id",
                schema: "public",
                table: "quoted_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_quoted_products_quotation_id",
                schema: "public",
                table: "quoted_products",
                column: "quotation_id");

            migrationBuilder.CreateIndex(
                name: "IX_quoted_products_unit_measure_id",
                schema: "public",
                table: "quoted_products",
                column: "unit_measure_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_quoted_purchases_purchase_request_id",
                schema: "public",
                table: "request_quoted_purchases",
                column: "purchase_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_quoted_purchases_quotation_id",
                schema: "public",
                table: "request_quoted_purchases",
                column: "quotation_id");

            migrationBuilder.CreateIndex(
                name: "IX_requested_products_product_id",
                schema: "public",
                table: "requested_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_requested_products_purchase_request_id",
                schema: "public",
                table: "requested_products",
                column: "purchase_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_requested_products_unit_measure_id",
                schema: "public",
                table: "requested_products",
                column: "unit_measure_id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_requests_users_user_id",
                schema: "public",
                table: "purchase_requests",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_branches_branch_id",
                schema: "public",
                table: "quotes",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_users_created_by_user_id",
                schema: "public",
                table: "quotes",
                column: "created_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
