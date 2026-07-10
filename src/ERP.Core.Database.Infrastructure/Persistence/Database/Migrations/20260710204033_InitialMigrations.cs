using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .Annotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .Annotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .Annotation("Npgsql:Enum:public.deduction_payment_status", "paid,pending")
                .Annotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .Annotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions")
                .Annotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .Annotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia")
                .Annotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .Annotation("Npgsql:Enum:public.oss_status_enum", "pending,in_progress,completed,canceled")
                .Annotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .Annotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .Annotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .Annotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .Annotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .Annotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .Annotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .Annotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .Annotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .Annotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .Annotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .Annotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "category_products",
                schema: "public",
                columns: table => new
                {
                    category_product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_products", x => x.category_product_id);
                    table.ForeignKey(
                        name: "FK_category_products_category_products_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                schema: "public",
                columns: table => new
                {
                    company_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ruc = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    alias = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    company_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    neutral_image_url = table.Column<string>(type: "text", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.company_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_types",
                schema: "public",
                columns: table => new
                {
                    customer_type_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_types", x => x.customer_type_id);
                });

            migrationBuilder.CreateTable(
                name: "holidays",
                schema: "public",
                columns: table => new
                {
                    holiday_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: true),
                    holiday_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    day = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    is_global = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holidays", x => x.holiday_id);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                schema: "public",
                columns: table => new
                {
                    module_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    module_name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    path_redirect = table.Column<string>(type: "text", nullable: false, defaultValue: "/dashboard"),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.module_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "public",
                columns: table => new
                {
                    role_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    role_name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    role_type = table.Column<int>(type: "role_type_enum", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "types_income",
                schema: "public",
                columns: table => new
                {
                    type_income_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    income_code = table.Column<string>(type: "text", nullable: true),
                    income_title = table.Column<string>(type: "text", nullable: false),
                    income_description = table.Column<string>(type: "text", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types_income", x => x.type_income_id);
                });

            migrationBuilder.CreateTable(
                name: "types_subsidy",
                schema: "public",
                columns: table => new
                {
                    type_subsidy_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    subsidy_code = table.Column<string>(type: "text", nullable: true),
                    subsidy_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types_subsidy", x => x.type_subsidy_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    email = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    identification_number = table.Column<string>(type: "text", nullable: false),
                    area_id = table.Column<int>(type: "integer", nullable: false),
                    user_type = table.Column<int>(type: "user_type_enum", nullable: false),
                    user_status = table.Column<int>(type: "user_status_enum", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "validity_deductions",
                schema: "public",
                columns: table => new
                {
                    validity_deduction_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    value = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    title_tax = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    tax_type = table.Column<int>(type: "tax_type_enum", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_validity_deductions", x => x.validity_deduction_id);
                });

            migrationBuilder.CreateTable(
                name: "workflow_step_definitions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    execution_order = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow_step_definitions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                schema: "public",
                columns: table => new
                {
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    branch_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    branch_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    company_alias = table.Column<string>(type: "text", nullable: false),
                    branch_address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    has_warehouse = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    does_generate_seniority = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.branch_id);
                    table.ForeignKey(
                        name: "FK_branches_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "catalogs",
                schema: "public",
                columns: table => new
                {
                    catalog_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    catalog_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_global = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    catalog_type = table.Column<int>(type: "catalog_type_enum", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogs", x => x.catalog_id);
                    table.ForeignKey(
                        name: "FK_catalogs_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "collaborators",
                schema: "public",
                columns: table => new
                {
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    picture_url = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    first_lastname = table.Column<string>(type: "text", nullable: false),
                    identification_number = table.Column<string>(type: "text", nullable: false),
                    collaborator_code = table.Column<string>(type: "text", nullable: false),
                    does_work_saturdays = table.Column<bool>(type: "boolean", nullable: false),
                    has_been_fired = table.Column<bool>(type: "boolean", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    second_name = table.Column<string>(type: "text", nullable: true),
                    third_name = table.Column<string>(type: "text", nullable: true),
                    second_lastname = table.Column<string>(type: "text", nullable: true),
                    registered_by = table.Column<string>(type: "text", nullable: false),
                    accounting_payroll_id = table.Column<Guid>(type: "uuid", nullable: true),
                    gender = table.Column<int>(type: "gender_type_enum", nullable: false),
                    status = table.Column<int>(type: "collaborator_status_enum", nullable: false),
                    is_first_time_register = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    identification_type = table.Column<int>(type: "identification_type_enum", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collaborators", x => x.collaborator_id);
                    table.ForeignKey(
                        name: "FK_collaborators_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_positions",
                schema: "public",
                columns: table => new
                {
                    job_position_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    job_position_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_positions", x => x.job_position_id);
                    table.ForeignKey(
                        name: "FK_job_positions_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                schema: "public",
                columns: table => new
                {
                    location_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    location_name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.location_id);
                    table.ForeignKey(
                        name: "FK_locations_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment_fees",
                schema: "public",
                columns: table => new
                {
                    payment_fess_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    amount = table.Column<decimal>(type: "numeric", maxLength: 180, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValue: "Sin descripción"),
                    currency = table.Column<int>(type: "currency_enum", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_fees", x => x.payment_fess_id);
                    table.ForeignKey(
                        name: "FK_payment_fees_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "types_accounting_payroll",
                schema: "public",
                columns: table => new
                {
                    type_income_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    accounting_payroll_name = table.Column<string>(type: "text", nullable: true),
                    accounting_payroll_code = table.Column<string>(type: "text", nullable: false),
                    does_generate_seniority = table.Column<bool>(type: "boolean", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types_accounting_payroll", x => x.type_income_id);
                    table.ForeignKey(
                        name: "FK_types_accounting_payroll_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "work_areas",
                schema: "public",
                columns: table => new
                {
                    work_area_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    work_area_code = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    work_area_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_areas", x => x.work_area_id);
                    table.ForeignKey(
                        name: "FK_work_areas_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "public",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    dni_ruc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    legal_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    picture_url = table.Column<string>(type: "text", nullable: false),
                    customer_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_customers_customer_types_customer_type_id",
                        column: x => x.customer_type_id,
                        principalSchema: "public",
                        principalTable: "customer_types",
                        principalColumn: "customer_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "public",
                columns: table => new
                {
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    permission_name = table.Column<string>(type: "text", nullable: true),
                    permission_type = table.Column<string>(type: "text", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.permission_id);
                    table.ForeignKey(
                        name: "FK_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                schema: "public",
                columns: table => new
                {
                    session_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    device = table.Column<string>(type: "text", nullable: true),
                    ip_address = table.Column<string>(type: "text", nullable: true),
                    refresh_token = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    company_code = table.Column<string>(type: "text", nullable: false),
                    expires_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions", x => x.session_id);
                    table.ForeignKey(
                        name: "FK_sessions_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users_profiles",
                schema: "public",
                columns: table => new
                {
                    user_profile_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_profiles", x => x.user_profile_id);
                    table.ForeignKey(
                        name: "FK_users_profiles_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_profiles_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payrolls",
                schema: "public",
                columns: table => new
                {
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    payroll_period = table.Column<int>(type: "payroll_period_enum", nullable: false),
                    payroll_type = table.Column<int>(type: "payroll_type_enum", nullable: false),
                    payroll_status = table.Column<int>(type: "payroll_status_enum", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    company_branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_accounting_id = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payrolls", x => x.payroll_id);
                    table.ForeignKey(
                        name: "FK_payrolls_branches_company_branch_id",
                        column: x => x.company_branch_id,
                        principalSchema: "public",
                        principalTable: "branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouses",
                schema: "public",
                columns: table => new
                {
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    warehouse_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_owner = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    total_cubic_capacity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    warehouse_type = table.Column<int>(type: "integer", nullable: false),
                    total_area = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    net_storage_area = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    unusable_area = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    max_height = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    min_height = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    rampas_count = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: false),
                    parking_spaces_count = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: false),
                    parent_warehouse_id = table.Column<Guid>(type: "uuid", nullable: true),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouses", x => x.warehouse_id);
                    table.ForeignKey(
                        name: "FK_warehouses_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "public",
                        principalTable: "branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouses_warehouses_parent_warehouse_id",
                        column: x => x.parent_warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sub_catalogs",
                schema: "public",
                columns: table => new
                {
                    sub_catalog_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    catalog_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    catalog_id = table.Column<int>(type: "integer", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_catalogs", x => x.sub_catalog_id);
                    table.ForeignKey(
                        name: "FK_sub_catalogs_catalogs_catalog_id",
                        column: x => x.catalog_id,
                        principalSchema: "public",
                        principalTable: "catalogs",
                        principalColumn: "catalog_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assigned_travel_expenses",
                schema: "public",
                columns: table => new
                {
                    assigned_travel_expense_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    amount_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    amount_in_local_currency = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<int>(type: "integer", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_income_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assigned_travel_expenses", x => x.assigned_travel_expense_id);
                    table.ForeignKey(
                        name: "FK_assigned_travel_expenses_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assigned_travel_expenses_types_income_type_income_id",
                        column: x => x.type_income_id,
                        principalSchema: "public",
                        principalTable: "types_income",
                        principalColumn: "type_income_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "deductions",
                schema: "public",
                columns: table => new
                {
                    deduction_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    currency = table.Column<int>(type: "currency_enum", nullable: false),
                    deduction_type = table.Column<int>(type: "deduction_type_enum", nullable: false),
                    status = table.Column<int>(type: "deduction_status_enum", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    number_fortnights = table.Column<int>(type: "integer", nullable: true),
                    number_fortnights_paid = table.Column<int>(type: "integer", nullable: true),
                    fortnightly_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    fortnightly_amount_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: true),
                    percentage = table.Column<int>(type: "integer", nullable: true),
                    total_balance = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    total_balance_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    amount_paid = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    amount_paid_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    total_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_amount_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deductions", x => x.deduction_id);
                    table.ForeignKey(
                        name: "FK_deductions_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "permit_applications_pending",
                schema: "public",
                columns: table => new
                {
                    permit_application_pending_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    permit_application_type = table.Column<int>(type: "permit_application_type_enum", nullable: false),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false),
                    requested_by = table.Column<string>(type: "text", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permit_applications_pending", x => x.permit_application_pending_id);
                    table.ForeignKey(
                        name: "FK_permit_applications_pending_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salaries",
                schema: "public",
                columns: table => new
                {
                    salary_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount_in_local = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    amount_in_foreign = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    amount_salary = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    bank_id = table.Column<int>(type: "integer", nullable: false),
                    currency = table.Column<int>(type: "currency_enum", nullable: false),
                    salary_type = table.Column<int>(type: "salary_type_enum", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaries", x => x.salary_id);
                    table.ForeignKey(
                        name: "FK_salaries_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacations",
                schema: "public",
                columns: table => new
                {
                    vacation_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    available_vacations = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    genered_vacation = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    enjoyed_vacation = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    donated_vacation = table.Column<decimal>(type: "numeric(18,4)", nullable: false, defaultValue: 0m),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacations", x => x.vacation_id);
                    table.ForeignKey(
                        name: "FK_vacations_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cost_centers",
                schema: "public",
                columns: table => new
                {
                    cost_center_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    cost_center_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    coil_code = table.Column<int>(type: "integer", nullable: false),
                    cost_center_code = table.Column<int>(type: "integer", nullable: false),
                    work_area_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cost_centers", x => x.cost_center_id);
                    table.ForeignKey(
                        name: "FK_cost_centers_work_areas_work_area_id",
                        column: x => x.work_area_id,
                        principalSchema: "public",
                        principalTable: "work_areas",
                        principalColumn: "work_area_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "public",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    product_sku = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    unit_of_measure = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_category_products_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "service_orders",
                schema: "public",
                columns: table => new
                {
                    service_order_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    oos_status = table.Column<int>(type: "oss_status_enum", nullable: false),
                    observations = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_orders", x => x.service_order_id);
                    table.ForeignKey(
                        name: "FK_service_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_module_roles",
                schema: "public",
                columns: table => new
                {
                    user_module_role_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    module_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    module_code = table.Column<string>(type: "text", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_module_roles", x => x.user_module_role_id);
                    table.ForeignKey(
                        name: "FK_user_module_roles_modules_module_id",
                        column: x => x.module_id,
                        principalSchema: "public",
                        principalTable: "modules",
                        principalColumn: "module_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_module_roles_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_module_roles_users_profiles_user_profile_id",
                        column: x => x.user_profile_id,
                        principalSchema: "public",
                        principalTable: "users_profiles",
                        principalColumn: "user_profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "christmas_bonus_accruals",
                schema: "public",
                columns: table => new
                {
                    christmas_bonus_accrual_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    base_salary = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    equivalent_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    christmas_bonus_days = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    equivalent_quantity_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_christmas_bonus_accruals", x => x.christmas_bonus_accrual_id);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_accruals_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_accruals_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "income_tax_accrual",
                schema: "public",
                columns: table => new
                {
                    income_tax_accrual_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    salary_earned = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    accumulated_ir = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    accumulated_seniority = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    accumulated_ir_by_fornight = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    salary_earned_by_fornight = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    accumulated_ir_monthly = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    salary_earned_monthly = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    flag_salary_earned = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    flag_accumulated_ir = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    number_of_fortnights = table.Column<int>(type: "integer", nullable: false),
                    flag_number_of_fortnights = table.Column<int>(type: "integer", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income_tax_accrual", x => x.income_tax_accrual_id);
                    table.ForeignKey(
                        name: "FK_income_tax_accrual_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_income_tax_accrual_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incomes",
                schema: "public",
                columns: table => new
                {
                    income_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    amount_in_local = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    amount_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    currency = table.Column<int>(type: "integer", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    income_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incomes", x => x.income_id);
                    table.ForeignKey(
                        name: "FK_incomes_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_incomes_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_incomes_types_income_income_type_id",
                        column: x => x.income_type_id,
                        principalSchema: "public",
                        principalTable: "types_income",
                        principalColumn: "type_income_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inss_accounting_information",
                schema: "public",
                columns: table => new
                {
                    inss_information_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    total = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    inatec = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    absence = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    inss_labor = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    inss_patronal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    income = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    days_absence = table.Column<int>(type: "integer", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inss_accounting_information", x => x.inss_information_id);
                    table.ForeignKey(
                        name: "FK_inss_accounting_information_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inss_accounting_information_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ordinary_payrolls",
                schema: "public",
                columns: table => new
                {
                    ordinary_payroll_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    biweekly_salary = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    deductions_additional_data = table.Column<string>(type: "jsonb", nullable: false),
                    total_deductions = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    antique = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    year_antique = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    percent_antique = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    bonus = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    overtimes = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    commissions = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    number_overtime = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    amount_days_vacation = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0.0m),
                    total_income = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    transport = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    feeding = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    lodging = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_travel_expenses = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ir = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    inss = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    vacations = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    christmas_bonus = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_legal_deductions = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    gross_salary = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_to_pay = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordinary_payrolls", x => x.ordinary_payroll_id);
                    table.ForeignKey(
                        name: "FK_ordinary_payrolls_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ordinary_payrolls_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permit_applications",
                schema: "public",
                columns: table => new
                {
                    permit_application_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_code = table.Column<string>(type: "text", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permit_application_type = table.Column<int>(type: "permit_application_type_enum", nullable: false),
                    status = table.Column<int>(type: "permit_application_status_enum", nullable: false),
                    is_with_range_date = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false),
                    first_step_approved = table.Column<bool>(type: "boolean", nullable: true),
                    second_step_approved = table.Column<bool>(type: "boolean", nullable: true),
                    manager_fullname = table.Column<string>(type: "text", nullable: true),
                    administrator_fullname = table.Column<string>(type: "text", nullable: true),
                    amount_days = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    identification_collaborator_to_receive = table.Column<string>(type: "text", nullable: true),
                    requested_by = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permit_applications", x => x.permit_application_id);
                    table.ForeignKey(
                        name: "FK_permit_applications_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_permit_applications_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "professional_services_payrolls",
                schema: "public",
                columns: table => new
                {
                    professional_services_payroll_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    vigemsa_additional_data = table.Column<string>(type: "jsonb", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ir = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    inss = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    vacations = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    christmas_bonus = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_legal_deductions = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    gross_salary = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_to_pay = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional_services_payrolls", x => x.professional_services_payroll_id);
                    table.ForeignKey(
                        name: "FK_professional_services_payrolls_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_professional_services_payrolls_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "records_travel_expense_payments",
                schema: "public",
                columns: table => new
                {
                    records_travel_expense_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    paid_days = table.Column<int>(type: "integer", nullable: false),
                    lodging = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    feeding = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    transport = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_records_travel_expense_payments", x => x.records_travel_expense_id);
                    table.ForeignKey(
                        name: "FK_records_travel_expense_payments_collaborators_collaborator_~",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_records_travel_expense_payments_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subsidies",
                schema: "public",
                columns: table => new
                {
                    subsidy_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    amount_days = table.Column<int>(type: "integer", nullable: false),
                    percentage = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    reference_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    observations = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_subsidy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subsidies", x => x.subsidy_id);
                    table.ForeignKey(
                        name: "FK_subsidies_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subsidies_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subsidies_types_subsidy_type_subsidy_id",
                        column: x => x.type_subsidy_id,
                        principalSchema: "public",
                        principalTable: "types_subsidy",
                        principalColumn: "type_subsidy_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vacations_accruals",
                schema: "public",
                columns: table => new
                {
                    vacation_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    final_balance = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    beginning_balance = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    available_vacations = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    equivalent_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    equivalent_quantity_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacations_accruals", x => x.vacation_id);
                    table.ForeignKey(
                        name: "FK_vacations_accruals_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vacations_accruals_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "record_entrances_managua",
                schema: "public",
                columns: table => new
                {
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    service_order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_step_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    closed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_consolidated = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_entrances_managua", x => x.record_entrance_managua_id);
                    table.ForeignKey(
                        name: "FK_record_entrances_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_record_entrances_managua_workflow_step_definitions_current_~",
                        column: x => x.current_step_id,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zones_managua",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    zone_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    width_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    length_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    heigth_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    total_colume_capacity_m3 = table.Column<decimal>(type: "numeric(12,3)", precision: 12, scale: 3, nullable: false),
                    max_weight_capacity_kg = table.Column<decimal>(type: "numeric(14,2)", precision: 14, scale: 2, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones_managua", x => x.id);
                    table.ForeignKey(
                        name: "FK_zones_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal_informations",
                schema: "public",
                columns: table => new
                {
                    personal_information_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    personal_email = table.Column<string>(type: "text", nullable: true),
                    personal_phone_number = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    departament_id = table.Column<int>(type: "integer", nullable: true),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    marital_status = table.Column<int>(type: "marital_status_enum", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_informations", x => x.personal_information_id);
                    table.ForeignKey(
                        name: "FK_personal_informations_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personal_informations_sub_catalogs_departament_id",
                        column: x => x.departament_id,
                        principalSchema: "public",
                        principalTable: "sub_catalogs",
                        principalColumn: "sub_catalog_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "work_position_histories",
                schema: "public",
                columns: table => new
                {
                    work_position_history_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    work_position_id = table.Column<int>(type: "integer", nullable: false),
                    job_position_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_position_histories", x => x.work_position_history_id);
                    table.ForeignKey(
                        name: "FK_work_position_histories_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_work_position_histories_sub_catalogs_work_position_id",
                        column: x => x.work_position_id,
                        principalSchema: "public",
                        principalTable: "sub_catalogs",
                        principalColumn: "sub_catalog_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "working_information",
                schema: "public",
                columns: table => new
                {
                    working_information_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    daem = table.Column<string>(type: "text", nullable: true),
                    work_email = table.Column<string>(type: "text", nullable: true),
                    inss_number = table.Column<string>(type: "text", nullable: true),
                    work_phone_number = table.Column<string>(type: "text", nullable: true),
                    bank_account_number = table.Column<string>(type: "text", nullable: true),
                    work_position_id = table.Column<int>(type: "integer", nullable: false),
                    company_branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    area_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: true),
                    job_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    entry_date = table.Column<DateOnly>(type: "date", nullable: false),
                    departure_date = table.Column<DateOnly>(type: "date", nullable: true),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_working_information", x => x.working_information_id);
                    table.ForeignKey(
                        name: "FK_working_information_branches_company_branch_id",
                        column: x => x.company_branch_id,
                        principalSchema: "public",
                        principalTable: "branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_working_information_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_working_information_sub_catalogs_work_position_id",
                        column: x => x.work_position_id,
                        principalSchema: "public",
                        principalTable: "sub_catalogs",
                        principalColumn: "sub_catalog_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_working_information_work_areas_area_id",
                        column: x => x.area_id,
                        principalSchema: "public",
                        principalTable: "work_areas",
                        principalColumn: "work_area_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "deductions_payment_histories",
                schema: "public",
                columns: table => new
                {
                    payment_history_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    payment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    currency = table.Column<int>(type: "currency_enum", nullable: false),
                    amount_paid = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    amount_paid_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    status = table.Column<int>(type: "deduction_payment_status", nullable: false),
                    origin = table.Column<int>(type: "source_deduction_payment_enum", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deduction_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deductions_payment_histories", x => x.payment_history_id);
                    table.ForeignKey(
                        name: "FK_deductions_payment_histories_deductions_deduction_id",
                        column: x => x.deduction_id,
                        principalSchema: "public",
                        principalTable: "deductions",
                        principalColumn: "deduction_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deductions_payment_histories_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assistance_control",
                schema: "public",
                columns: table => new
                {
                    assistance_control_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    shift_date = table.Column<DateOnly>(type: "date", nullable: false),
                    amount_hours = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    professioal_payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assistance_control", x => x.assistance_control_id);
                    table.ForeignKey(
                        name: "FK_assistance_control_professional_services_payrolls_professio~",
                        column: x => x.professioal_payroll_id,
                        principalSchema: "public",
                        principalTable: "professional_services_payrolls",
                        principalColumn: "professional_services_payroll_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry_managua",
                schema: "public",
                columns: table => new
                {
                    ducat_registtry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    registry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    trailer_identifier = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    empresa = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    registered_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    general_observations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    is_in_transit = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry_managua", x => x.ducat_registtry_id);
                    table.ForeignKey(
                        name: "FK_ducat_registry_managua_record_entrances_managua_record_entr~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entrance_ducats_managua",
                schema: "public",
                columns: table => new
                {
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ducat_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrance_ducats_managua", x => x.entrance_ducat_id);
                    table.ForeignKey(
                        name: "FK_entrance_ducats_managua_record_entrances_managua_record_ent~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "manifest_cancellations_managua",
                schema: "public",
                columns: table => new
                {
                    manifest_cancellation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    service_orders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    manifest_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    container_count = table.Column<int>(type: "integer", nullable: false),
                    container_dimension = table.Column<string>(type: "text", nullable: false),
                    personal_type = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    customs_officer_signature = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    warehouse_chief_signature = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manifest_cancellations_managua", x => x.manifest_cancellation_id);
                    table.ForeignKey(
                        name: "FK_manifest_cancellations_managua_record_entrances_managua_rec~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_manifest_cancellations_managua_service_orders_service_order~",
                        column: x => x.service_orders_id,
                        principalSchema: "public",
                        principalTable: "service_orders",
                        principalColumn: "service_order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reception_details_managua",
                schema: "public",
                columns: table => new
                {
                    reception_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    country_of_origin = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    aduana = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    gate_entrance_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    plate_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    trailer_chassis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    driver_license = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    transportista = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    medio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    driver_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    consignee = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    seal_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception_details_managua", x => x.reception_details_managua_id);
                    table.ForeignKey(
                        name: "FK_reception_details_managua_record_entrances_managua_record_e~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "step_execution_logs_managua",
                schema: "public",
                columns: table => new
                {
                    step_execution_logs_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    workflow_step_definition_id = table.Column<int>(type: "integer", nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    processed_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_step_execution_logs_managua", x => x.step_execution_logs_id);
                    table.ForeignKey(
                        name: "FK_step_execution_logs_managua_record_entrances_managua_record~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_step_execution_logs_managua_workflow_step_definitions_workf~",
                        column: x => x.workflow_step_definition_id,
                        principalSchema: "public",
                        principalTable: "workflow_step_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_receipts_managua",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    receipt_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    resa_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    customs_cif_value = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    customs_brokerage = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    receipt_creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    receipt_cancellation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_receipts_managua", x => x.id);
                    table.ForeignKey(
                        name: "FK_warehouse_receipts_managua_record_entrances_managua_record_~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "racks_managua",
                schema: "public",
                columns: table => new
                {
                    racks_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    zone_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    row_number = table.Column<int>(type: "integer", nullable: false),
                    level_number = table.Column<int>(type: "integer", nullable: false),
                    cost_per_position = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    is_available = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    max_weight_kg = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    max_height_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racks_managua", x => x.racks_id);
                    table.ForeignKey(
                        name: "FK_racks_managua_zones_managua_zone_id",
                        column: x => x.zone_id,
                        principalSchema: "public",
                        principalTable: "zones_managua",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "discrepancies_managua",
                schema: "public",
                columns: table => new
                {
                    discrepancy_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    discrepancy_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    declared_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    found_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    customs_letter_reference = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    is_damage = table.Column<bool>(type: "boolean", nullable: false),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entrance_ducats_id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordEntranceManaguaId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discrepancies_managua", x => x.discrepancy_id);
                    table.ForeignKey(
                        name: "FK_discrepancies_managua_entrance_ducats_managua_entrance_duca~",
                        column: x => x.entrance_ducats_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats_managua",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_discrepancies_managua_record_entrances_managua_RecordEntran~",
                        column: x => x.RecordEntranceManaguaId1,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id");
                    table.ForeignKey(
                        name: "FK_discrepancies_managua_record_entrances_managua_record_entra~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ducat_registry_details_managua",
                schema: "public",
                columns: table => new
                {
                    ducat_registry_detail_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entrance_ducat_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_bultos = table.Column<int>(type: "integer", nullable: false),
                    total_weight = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    product_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    remitente = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    destination_area_observation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ducat_registry_details_managua", x => x.ducat_registry_detail_id);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_managua_category_products_category_p~",
                        column: x => x.category_product_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_managua_ducat_registry_managua_recor~",
                        column: x => x.record_entrance_id,
                        principalSchema: "public",
                        principalTable: "ducat_registry_managua",
                        principalColumn: "ducat_registtry_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ducat_registry_details_managua_entrance_ducats_managua_entr~",
                        column: x => x.entrance_ducat_managua_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats_managua",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stocks_managua",
                schema: "public",
                columns: table => new
                {
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entrance_ducats_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    zone_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    racks_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_bultos = table.Column<int>(type: "integer", nullable: false),
                    current_weight_kg = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    stored_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    row_version = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks_managua", x => x.stock_id);
                    table.ForeignKey(
                        name: "FK_stocks_managua_category_products_category_product_id",
                        column: x => x.category_product_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_managua_entrance_ducats_managua_entrance_ducats_mana~",
                        column: x => x.entrance_ducats_managua_id,
                        principalSchema: "public",
                        principalTable: "entrance_ducats_managua",
                        principalColumn: "entrance_ducat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_managua_racks_managua_racks_managua_id",
                        column: x => x.racks_managua_id,
                        principalSchema: "public",
                        principalTable: "racks_managua",
                        principalColumn: "racks_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_managua_zones_managua_zone_managua_id",
                        column: x => x.zone_managua_id,
                        principalSchema: "public",
                        principalTable: "zones_managua",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_assignments_managua",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    zone_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    assigned_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_assignments_managua", x => x.id);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_racks_managua_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks_managua",
                        principalColumn: "racks_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_record_entrances_managua_reco~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_assignments_managua_zones_managua_zone_id",
                        column: x => x.zone_id,
                        principalSchema: "public",
                        principalTable: "zones_managua",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_details_managua",
                schema: "public",
                columns: table => new
                {
                    unloading_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_assignments_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unloading_start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    unloading_end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    warehouse_chief_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    prepared_pallets = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_details_managua", x => x.unloading_details_managua_id);
                    table.ForeignKey(
                        name: "FK_unloading_details_managua_record_entrances_managua_record_e~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_unloading_details_managua_warehouse_assignments_managua_war~",
                        column: x => x.warehouse_assignments_managua_id,
                        principalSchema: "public",
                        principalTable: "warehouse_assignments_managua",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unloading_crew_assignments_managua",
                schema: "public",
                columns: table => new
                {
                    unloading_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    persona_count = table.Column<int>(type: "integer", nullable: false),
                    tercerizada = table.Column<bool>(type: "boolean", nullable: false),
                    UnloadingDetailsManaguaId = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_crew_assignments_managua", x => x.unloading_details_managua_id);
                    table.ForeignKey(
                        name: "FK_unloading_crew_assignments_managua_unloading_details_managu~",
                        column: x => x.UnloadingDetailsManaguaId,
                        principalSchema: "public",
                        principalTable: "unloading_details_managua",
                        principalColumn: "unloading_details_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnloadingMachineryAssignmentsManagua",
                schema: "public",
                columns: table => new
                {
                    unloading_machinery_assignment_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    unloading_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    machinery_code = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: false),
                    machinery_type = table.Column<Guid>(type: "uuid", maxLength: 150, nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    assigned_by_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnloadingMachineryAssignmentsManagua", x => x.unloading_machinery_assignment_id);
                    table.ForeignKey(
                        name: "FK_UnloadingMachineryAssignmentsManagua_unloading_details_mana~",
                        column: x => x.unloading_details_managua_id,
                        principalSchema: "public",
                        principalTable: "unloading_details_managua",
                        principalColumn: "unloading_details_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assigned_travel_expenses_collaborator_id",
                schema: "public",
                table: "assigned_travel_expenses",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_assigned_travel_expenses_type_income_id",
                schema: "public",
                table: "assigned_travel_expenses",
                column: "type_income_id");

            migrationBuilder.CreateIndex(
                name: "IX_assistance_control_professioal_payroll_id",
                schema: "public",
                table: "assistance_control",
                column: "professioal_payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_branches_company_id",
                schema: "public",
                table: "branches",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_catalogs_company_type",
                schema: "public",
                table: "catalogs",
                columns: new[] { "company_id", "catalog_name", "catalog_type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_category_products_parent_id",
                schema: "public",
                table: "category_products",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_accruals_payroll_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_collaborator_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_collaborator_id",
                schema: "public",
                table: "collaborators",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_collaborators_collaborator_code",
                schema: "public",
                table: "collaborators",
                column: "collaborator_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_collaborators_company_id",
                schema: "public",
                table: "collaborators",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_collaborators_identification_number",
                schema: "public",
                table: "collaborators",
                column: "identification_number");

            migrationBuilder.CreateIndex(
                name: "IX_companies_code",
                schema: "public",
                table: "companies",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_id",
                schema: "public",
                table: "companies",
                column: "company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cost_center_id",
                schema: "public",
                table: "cost_centers",
                column: "cost_center_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cost_centers_work_area_id",
                schema: "public",
                table: "cost_centers",
                column: "work_area_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_id",
                schema: "public",
                table: "customers",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_customer_type_id",
                schema: "public",
                table: "customers",
                column: "customer_type_id");

            migrationBuilder.CreateIndex(
                name: "ux_customer_dni_ruc",
                schema: "public",
                table: "customers",
                column: "dni_ruc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_deduction_id",
                schema: "public",
                table: "deductions",
                column: "deduction_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_deductions_collaborator_id",
                schema: "public",
                table: "deductions",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_deductions_payment_histories_deduction_id",
                schema: "public",
                table: "deductions_payment_histories",
                column: "deduction_id");

            migrationBuilder.CreateIndex(
                name: "IX_deductions_payment_histories_payroll_id",
                schema: "public",
                table: "deductions_payment_histories",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_id",
                schema: "public",
                table: "deductions_payment_histories",
                column: "payment_history_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_managua_entrance_ducats_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "entrance_ducats_id");

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_managua_record_entrance_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_discrepancies_managua_RecordEntranceManaguaId1",
                schema: "public",
                table: "discrepancies_managua",
                column: "RecordEntranceManaguaId1");

            migrationBuilder.CreateIndex(
                name: "ix_discrepancy_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "discrepancy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_managua_category_product_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "category_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_managua_entrance_ducat_managua_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "entrance_ducat_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_details_managua_record_entrance_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_managua_record_entrance_managua_id",
                schema: "public",
                table: "ducat_registry_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entrance_ducats_managua_record_entrance_managua_id",
                schema: "public",
                table: "entrance_ducats_managua",
                column: "record_entrance_managua_id");

            migrationBuilder.CreateIndex(
                name: "ix_holiday_id",
                schema: "public",
                table: "holidays",
                column: "holiday_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_income_tax_accrual_collaborator_id",
                schema: "public",
                table: "income_tax_accrual",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_income_tax_accrual_payroll_id",
                schema: "public",
                table: "income_tax_accrual",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_income_tax_id",
                schema: "public",
                table: "income_tax_accrual",
                column: "income_tax_accrual_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_income_id",
                schema: "public",
                table: "incomes",
                column: "income_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_incomes_collaborator_id",
                schema: "public",
                table: "incomes",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_incomes_income_type_id",
                schema: "public",
                table: "incomes",
                column: "income_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_incomes_payroll_id",
                schema: "public",
                table: "incomes",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_inss_accounting_information_collaborator_id",
                schema: "public",
                table: "inss_accounting_information",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_inss_accounting_information_payroll_id",
                schema: "public",
                table: "inss_accounting_information",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_inss_information_id",
                schema: "public",
                table: "inss_accounting_information",
                column: "inss_information_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_position_id",
                schema: "public",
                table: "job_positions",
                column: "job_position_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_positions_company_id",
                schema: "public",
                table: "job_positions",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_location_id",
                schema: "public",
                table: "locations",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_locations_company_id",
                schema: "public",
                table: "locations",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_manifest_cancellations_managua_record_entrance_managua_id",
                schema: "public",
                table: "manifest_cancellations_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_manifest_cancellations_managua_service_orders_id",
                schema: "public",
                table: "manifest_cancellations_managua",
                column: "service_orders_id");

            migrationBuilder.CreateIndex(
                name: "ix_modules_company_code",
                schema: "public",
                table: "modules",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "ix_ordinary_payroll_id",
                schema: "public",
                table: "ordinary_payrolls",
                column: "ordinary_payroll_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ordinary_payrolls_collaborator_id",
                schema: "public",
                table: "ordinary_payrolls",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_ordinary_payrolls_payroll_id",
                schema: "public",
                table: "ordinary_payrolls",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_fees_company_id",
                schema: "public",
                table: "payment_fees",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_fees_id",
                schema: "public",
                table: "payment_fees",
                column: "payment_fess_id");

            migrationBuilder.CreateIndex(
                name: "ix_payroll_id",
                schema: "public",
                table: "payrolls",
                column: "payroll_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payrolls_company_branch_id",
                schema: "public",
                table: "payrolls",
                column: "company_branch_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_id",
                schema: "public",
                table: "permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_role_id",
                schema: "public",
                table: "permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_permit_application_id",
                schema: "public",
                table: "permit_applications",
                column: "permit_application_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permit_applications_collaborator_id",
                schema: "public",
                table: "permit_applications",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_permit_applications_payroll_id",
                schema: "public",
                table: "permit_applications",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_permit_application_pending_id",
                schema: "public",
                table: "permit_applications_pending",
                column: "permit_application_pending_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permit_applications_pending_collaborator_id",
                schema: "public",
                table: "permit_applications_pending",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_informations_collaborator_id",
                schema: "public",
                table: "personal_informations",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personal_informations_departament_id",
                schema: "public",
                table: "personal_informations",
                column: "departament_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_id",
                schema: "public",
                table: "products",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                schema: "public",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_customer_id",
                schema: "public",
                table: "products",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_prof_services_payroll_ordinary_payroll_id",
                schema: "public",
                table: "professional_services_payrolls",
                column: "professional_services_payroll_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_professional_services_payrolls_collaborator_id",
                schema: "public",
                table: "professional_services_payrolls",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_professional_services_payrolls_payroll_id",
                schema: "public",
                table: "professional_services_payrolls",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_racks_managua_zone_id",
                schema: "public",
                table: "racks_managua",
                column: "zone_id");

            migrationBuilder.CreateIndex(
                name: "IX_reception_details_managua_record_entrance_managua_id",
                schema: "public",
                table: "reception_details_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_current_step_id",
                schema: "public",
                table: "record_entrances_managua",
                column: "current_step_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_warehouse_id",
                schema: "public",
                table: "record_entrances_managua",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_records_travel_expense_payments_collaborator_id",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_records_travel_expense_payments_payroll_id",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_id",
                schema: "public",
                table: "roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_salaries_collaborator_id",
                schema: "public",
                table: "salaries",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_os_code",
                schema: "public",
                table: "service_orders",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_orders_customer_id",
                schema: "public",
                table: "service_orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_service_orders_id",
                schema: "public",
                table: "service_orders",
                column: "service_order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_session_id",
                schema: "public",
                table: "sessions",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_user_id",
                schema: "public",
                table: "sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_managua_record_entrance_id",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_step_execution_logs_managua_workflow_step_definition_id",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "workflow_step_definition_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_category_product_id",
                schema: "public",
                table: "stocks_managua",
                column: "category_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_entrance_ducats_managua_id",
                schema: "public",
                table: "stocks_managua",
                column: "entrance_ducats_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_racks_managua_id",
                schema: "public",
                table: "stocks_managua",
                column: "racks_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_zone_managua_id",
                schema: "public",
                table: "stocks_managua",
                column: "zone_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_sub_catalogs_catalog_id",
                schema: "public",
                table: "sub_catalogs",
                column: "catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_subsidies_collaborator_id",
                schema: "public",
                table: "subsidies",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_subsidies_payroll_id",
                schema: "public",
                table: "subsidies",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_subsidies_type_subsidy_id",
                schema: "public",
                table: "subsidies",
                column: "type_subsidy_id");

            migrationBuilder.CreateIndex(
                name: "IX_types_accounting_payroll_company_id",
                schema: "public",
                table: "types_accounting_payroll",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_crew_assignments_managua_UnloadingDetailsManaguaId",
                schema: "public",
                table: "unloading_crew_assignments_managua",
                column: "UnloadingDetailsManaguaId");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_details_managua_record_entrance_managua_id",
                schema: "public",
                table: "unloading_details_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unloading_details_managua_warehouse_assignments_managua_id",
                schema: "public",
                table: "unloading_details_managua",
                column: "warehouse_assignments_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnloadingMachineryAssignmentsManagua_unloading_details_mana~",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                column: "unloading_details_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_User_Module_Role",
                schema: "public",
                table: "user_module_roles",
                columns: new[] { "user_profile_id", "module_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_module_roles_module_id",
                schema: "public",
                table: "user_module_roles",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_module_roles_role_id",
                schema: "public",
                table: "user_module_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_profiles_company_id",
                schema: "public",
                table: "users_profiles",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_profiles_user_id",
                schema: "public",
                table: "users_profiles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_collaborator_id",
                schema: "public",
                table: "vacations",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacations_accruals_collaborator_id",
                schema: "public",
                table: "vacations_accruals",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacations_accruals_payroll_id",
                schema: "public",
                table: "vacations_accruals",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_rack_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "rack_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_record_entrance_managua_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_warehouse_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_zone_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "zone_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_managua_receipt_number",
                schema: "public",
                table: "warehouse_receipts_managua",
                column: "receipt_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_managua_record_entrance_managua_id",
                schema: "public",
                table: "warehouse_receipts_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_id",
                schema: "public",
                table: "warehouses",
                column: "warehouse_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_branch_id",
                schema: "public",
                table: "warehouses",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                column: "parent_warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_work_area_id",
                schema: "public",
                table: "work_areas",
                column: "work_area_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_work_areas_company_id",
                schema: "public",
                table: "work_areas",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_work_position_histories_collaborator_id",
                schema: "public",
                table: "work_position_histories",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_work_position_histories_work_position_id",
                schema: "public",
                table: "work_position_histories",
                column: "work_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_working_information_area_id",
                schema: "public",
                table: "working_information",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_working_information_collaborator_id",
                schema: "public",
                table: "working_information",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_working_information_company_branch_id",
                schema: "public",
                table: "working_information",
                column: "company_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_working_information_work_position_id",
                schema: "public",
                table: "working_information",
                column: "work_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_zones_managua_warehouse_id",
                schema: "public",
                table: "zones_managua",
                column: "warehouse_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assigned_travel_expenses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "assistance_control",
                schema: "public");

            migrationBuilder.DropTable(
                name: "christmas_bonus_accruals",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cost_centers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "deductions_payment_histories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "discrepancies_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry_details_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "holidays",
                schema: "public");

            migrationBuilder.DropTable(
                name: "income_tax_accrual",
                schema: "public");

            migrationBuilder.DropTable(
                name: "incomes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "inss_accounting_information",
                schema: "public");

            migrationBuilder.DropTable(
                name: "job_positions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "locations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "manifest_cancellations_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ordinary_payrolls",
                schema: "public");

            migrationBuilder.DropTable(
                name: "payment_fees",
                schema: "public");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "permit_applications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "permit_applications_pending",
                schema: "public");

            migrationBuilder.DropTable(
                name: "personal_informations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reception_details_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "records_travel_expense_payments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "salaries",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sessions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "step_execution_logs_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "stocks_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "subsidies",
                schema: "public");

            migrationBuilder.DropTable(
                name: "types_accounting_payroll",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_crew_assignments_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "UnloadingMachineryAssignmentsManagua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_module_roles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vacations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vacations_accruals",
                schema: "public");

            migrationBuilder.DropTable(
                name: "validity_deductions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_receipts_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "work_position_histories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "working_information",
                schema: "public");

            migrationBuilder.DropTable(
                name: "professional_services_payrolls",
                schema: "public");

            migrationBuilder.DropTable(
                name: "deductions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ducat_registry_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "types_income",
                schema: "public");

            migrationBuilder.DropTable(
                name: "service_orders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "category_products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "entrance_ducats_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "types_subsidy",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_details_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "modules",
                schema: "public");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users_profiles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sub_catalogs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "work_areas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "payrolls",
                schema: "public");

            migrationBuilder.DropTable(
                name: "collaborators",
                schema: "public");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse_assignments_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "catalogs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "customer_types",
                schema: "public");

            migrationBuilder.DropTable(
                name: "racks_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "record_entrances_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "zones_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "workflow_step_definitions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "branches",
                schema: "public");

            migrationBuilder.DropTable(
                name: "companies",
                schema: "public");
        }
    }
}
