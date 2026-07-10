CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TYPE public.catalog_type_enum AS ENUM ('branches', 'work_areas', 'job_positions', 'document_types', 'banks', 'exchange_rates', 'departaments');
CREATE TYPE public.collaborator_status_enum AS ENUM ('active', 'inactive', 'vacation', 'subsidy', 'suspended', 'terminated', 'testing_process');
CREATE TYPE public.currency_enum AS ENUM ('nio', 'usd');
CREATE TYPE public.deduction_payment_status AS ENUM ('paid', 'pending');
CREATE TYPE public.deduction_status_enum AS ENUM ('progress', 'completed', 'pending', 'canceled');
CREATE TYPE public.deduction_type_enum AS ENUM ('loans', 'advance_christmas_bonus', 'late_arrivals', 'salary_advance', 'sanction', 'purisima', 'other_deductions');
CREATE TYPE public.gender_type_enum AS ENUM ('man', 'women');
CREATE TYPE public.identification_type_enum AS ENUM ('cedula', 'pasaporte', 'cedula_residencia');
CREATE TYPE public.marital_status_enum AS ENUM ('none', 'single', 'married', 'divorced', 'widowed', 'domestic_partner', 'separated', 'other');
CREATE TYPE public.oss_status_enum AS ENUM ('pending', 'in_progress', 'completed', 'canceled');
CREATE TYPE public.payroll_period_enum AS ENUM ('first_period', 'second_period');
CREATE TYPE public.payroll_status_enum AS ENUM ('progress', 'closed', 'cancelled', 'completed');
CREATE TYPE public.payroll_type_enum AS ENUM ('none', 'ordinary', 'provided', 'professional_services');
CREATE TYPE public.permission_type_enum AS ENUM ('read', 'create', 'update', 'delete');
CREATE TYPE public.permit_application_status_enum AS ENUM ('pending', 'approved', 'rejected', 'cancelled');
CREATE TYPE public.permit_application_type_enum AS ENUM ('vacation', 'medical_appointment', 'compensatory_time', 'paid_leave', 'unpaid_leave', 'special_leave', 'donated_vacations', 'vacation_pay');
CREATE TYPE public.role_type_enum AS ENUM ('administrator', 'supervisor', 'manager', 'operator');
CREATE TYPE public.salary_type_enum AS ENUM ('fixed', 'variable', 'professional_services');
CREATE TYPE public.source_deduction_payment_enum AS ENUM ('payroll', 'cash');
CREATE TYPE public.tax_type_enum AS ENUM ('inss', 'inss_patronal', 'exchange_rate', 'inatec', 'inss_patronal2');
CREATE TYPE public.user_status_enum AS ENUM ('active', 'inactive', 'locked');
CREATE TYPE public.user_type_enum AS ENUM ('standard_user', 'employee_self_service');
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE public.category_products (
    category_product_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    name character varying(100) NOT NULL,
    code character varying(500),
    is_active boolean NOT NULL DEFAULT TRUE,
    parent_id uuid,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_category_products" PRIMARY KEY (category_product_id),
    CONSTRAINT "FK_category_products_category_products_parent_id" FOREIGN KEY (parent_id) REFERENCES public.category_products (category_product_id) ON DELETE RESTRICT
);

CREATE TABLE public.companies (
    company_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    ruc character varying(120),
    code character varying(50),
    is_active boolean NOT NULL DEFAULT TRUE,
    alias character varying(100),
    company_name character varying(200),
    image_url text,
    neutral_image_url text,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_companies" PRIMARY KEY (company_id)
);

CREATE TABLE public.customer_types (
    customer_type_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    code character varying(20) NOT NULL,
    name character varying(100) NOT NULL,
    is_active boolean NOT NULL DEFAULT TRUE,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_customer_types" PRIMARY KEY (customer_type_id)
);

CREATE TABLE public.holidays (
    holiday_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    branch_id uuid,
    holiday_name text NOT NULL,
    description text NOT NULL,
    day integer NOT NULL,
    month integer NOT NULL,
    is_global boolean NOT NULL,
    is_active boolean NOT NULL DEFAULT TRUE,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_holidays" PRIMARY KEY (holiday_id)
);

CREATE TABLE public.modules (
    module_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    is_active boolean NOT NULL DEFAULT TRUE,
    code text NOT NULL,
    description text,
    module_name character varying(180) NOT NULL,
    path_redirect text NOT NULL DEFAULT '/dashboard',
    image_url text,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_modules" PRIMARY KEY (module_id)
);

CREATE TABLE public.roles (
    role_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    role_name character varying(180) NOT NULL,
    description text,
    role_type role_type_enum NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_roles" PRIMARY KEY (role_id)
);

CREATE TABLE public.types_income (
    type_income_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    is_active boolean NOT NULL DEFAULT TRUE,
    income_code text,
    income_title text NOT NULL,
    income_description text NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_types_income" PRIMARY KEY (type_income_id)
);

CREATE TABLE public.types_subsidy (
    type_subsidy_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    subsidy_code text,
    subsidy_name text NOT NULL,
    description text NOT NULL,
    is_active boolean NOT NULL DEFAULT TRUE,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_types_subsidy" PRIMARY KEY (type_subsidy_id)
);

CREATE TABLE public.users (
    user_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    email text NOT NULL,
    user_name text NOT NULL,
    fullname text NOT NULL,
    password_hash text NOT NULL,
    identification_number text NOT NULL,
    area_id integer NOT NULL,
    user_type user_type_enum NOT NULL,
    user_status user_status_enum NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_users" PRIMARY KEY (user_id)
);

CREATE TABLE public.validity_deductions (
    validity_deduction_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    status boolean NOT NULL DEFAULT TRUE,
    start_date timestamp with time zone NOT NULL,
    end_date timestamp with time zone,
    value numeric(18,4) NOT NULL,
    title_tax text,
    description text,
    tax_type tax_type_enum NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_validity_deductions" PRIMARY KEY (validity_deduction_id)
);

CREATE TABLE public.workflow_step_definitions (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    code character varying(50) NOT NULL,
    name character varying(100) NOT NULL,
    execution_order integer NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_workflow_step_definitions" PRIMARY KEY (id)
);

CREATE TABLE public.branches (
    branch_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    branch_code character varying(50),
    phone_number text,
    branch_name character varying(100),
    company_alias text NOT NULL,
    branch_address character varying(500),
    is_active boolean NOT NULL DEFAULT TRUE,
    has_warehouse boolean NOT NULL DEFAULT FALSE,
    does_generate_seniority boolean NOT NULL DEFAULT FALSE,
    company_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_branches" PRIMARY KEY (branch_id),
    CONSTRAINT "FK_branches_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE CASCADE
);

CREATE TABLE public.catalogs (
    catalog_id integer GENERATED BY DEFAULT AS IDENTITY,
    is_active boolean NOT NULL DEFAULT TRUE,
    catalog_name character varying(150),
    description character varying(500),
    is_global boolean NOT NULL DEFAULT FALSE,
    catalog_type catalog_type_enum NOT NULL,
    company_id uuid,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_catalogs" PRIMARY KEY (catalog_id),
    CONSTRAINT "FK_catalogs_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE CASCADE
);

CREATE TABLE public.collaborators (
    collaborator_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    picture_url text,
    first_name text NOT NULL,
    first_lastname text NOT NULL,
    identification_number text NOT NULL,
    collaborator_code text NOT NULL,
    does_work_saturdays boolean NOT NULL,
    has_been_fired boolean NOT NULL,
    company_id uuid NOT NULL,
    second_name text,
    third_name text,
    second_lastname text,
    registered_by text NOT NULL,
    accounting_payroll_id uuid,
    gender gender_type_enum NOT NULL,
    status collaborator_status_enum NOT NULL,
    is_first_time_register boolean NOT NULL DEFAULT TRUE,
    identification_type identification_type_enum NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_collaborators" PRIMARY KEY (collaborator_id),
    CONSTRAINT "FK_collaborators_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE RESTRICT
);

CREATE TABLE public.job_positions (
    job_position_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    is_active boolean NOT NULL DEFAULT TRUE,
    description character varying(150),
    job_position_name character varying(100) NOT NULL,
    company_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_job_positions" PRIMARY KEY (job_position_id),
    CONSTRAINT "FK_job_positions_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE RESTRICT
);

CREATE TABLE public.locations (
    location_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    location_name character varying(180) NOT NULL,
    company_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_locations" PRIMARY KEY (location_id),
    CONSTRAINT "FK_locations_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE CASCADE
);

CREATE TABLE public.payment_fees (
    payment_fess_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    amount numeric NOT NULL,
    description character varying(255) DEFAULT 'Sin descripción',
    currency currency_enum NOT NULL,
    start_date date NOT NULL,
    end_date date,
    company_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_payment_fees" PRIMARY KEY (payment_fess_id),
    CONSTRAINT "FK_payment_fees_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE CASCADE
);

CREATE TABLE public.types_accounting_payroll (
    type_income_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    is_active boolean NOT NULL DEFAULT TRUE,
    description text NOT NULL,
    accounting_payroll_name text,
    accounting_payroll_code text NOT NULL,
    does_generate_seniority boolean NOT NULL,
    company_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_types_accounting_payroll" PRIMARY KEY (type_income_id),
    CONSTRAINT "FK_types_accounting_payroll_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE RESTRICT
);

CREATE TABLE public.work_areas (
    work_area_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    is_active boolean NOT NULL DEFAULT TRUE,
    work_area_code integer NOT NULL,
    description character varying(150),
    work_area_name character varying(100),
    company_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_work_areas" PRIMARY KEY (work_area_id),
    CONSTRAINT "FK_work_areas_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE RESTRICT
);

CREATE TABLE public.customers (
    customer_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    dni_ruc character varying(50) NOT NULL,
    legal_name character varying(150) NOT NULL,
    is_active boolean NOT NULL DEFAULT TRUE,
    picture_url text NOT NULL,
    customer_type_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_customers" PRIMARY KEY (customer_id),
    CONSTRAINT "FK_customers_customer_types_customer_type_id" FOREIGN KEY (customer_type_id) REFERENCES public.customer_types (customer_type_id) ON DELETE RESTRICT
);

CREATE TABLE public.permissions (
    permission_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    role_id uuid NOT NULL,
    description character varying(400),
    permission_name text,
    permission_type text NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_permissions" PRIMARY KEY (permission_id),
    CONSTRAINT "FK_permissions_roles_role_id" FOREIGN KEY (role_id) REFERENCES public.roles (role_id) ON DELETE CASCADE
);

CREATE TABLE public.sessions (
    session_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    user_id uuid NOT NULL,
    device text,
    ip_address text,
    refresh_token text NOT NULL,
    is_active boolean NOT NULL,
    company_code text NOT NULL,
    expires_at timestamp with time zone NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_sessions" PRIMARY KEY (session_id),
    CONSTRAINT "FK_sessions_users_user_id" FOREIGN KEY (user_id) REFERENCES public.users (user_id) ON DELETE CASCADE
);

CREATE TABLE public.users_profiles (
    user_profile_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    user_id uuid NOT NULL,
    company_id uuid NOT NULL,
    is_active boolean NOT NULL DEFAULT TRUE,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_users_profiles" PRIMARY KEY (user_profile_id),
    CONSTRAINT "FK_users_profiles_companies_company_id" FOREIGN KEY (company_id) REFERENCES public.companies (company_id) ON DELETE CASCADE,
    CONSTRAINT "FK_users_profiles_users_user_id" FOREIGN KEY (user_id) REFERENCES public.users (user_id) ON DELETE CASCADE
);

CREATE TABLE public.payrolls (
    payroll_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    payroll_period payroll_period_enum NOT NULL,
    payroll_type payroll_type_enum NOT NULL,
    payroll_status payroll_status_enum NOT NULL,
    end_date date NOT NULL,
    start_date date NOT NULL,
    company_branch_id uuid NOT NULL,
    type_accounting_id uuid,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_payrolls" PRIMARY KEY (payroll_id),
    CONSTRAINT "FK_payrolls_branches_company_branch_id" FOREIGN KEY (company_branch_id) REFERENCES public.branches (branch_id) ON DELETE RESTRICT
);

CREATE TABLE public.warehouses (
    warehouse_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    code character varying(20) NOT NULL,
    warehouse_name character varying(100) NOT NULL,
    is_active boolean NOT NULL DEFAULT TRUE,
    is_owner boolean NOT NULL DEFAULT TRUE,
    total_cubic_capacity numeric(18,2) NOT NULL,
    warehouse_type integer NOT NULL,
    total_area numeric(18,2) NOT NULL,
    net_storage_area numeric(18,2) NOT NULL,
    unusable_area numeric(18,2) NOT NULL,
    max_height numeric(18,2) NOT NULL,
    min_height numeric(18,2) NOT NULL,
    rampas_count numeric(5,1) NOT NULL,
    parking_spaces_count numeric(5,1) NOT NULL,
    parent_warehouse_id uuid,
    branch_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_warehouses" PRIMARY KEY (warehouse_id),
    CONSTRAINT "FK_warehouses_branches_branch_id" FOREIGN KEY (branch_id) REFERENCES public.branches (branch_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_warehouses_warehouses_parent_warehouse_id" FOREIGN KEY (parent_warehouse_id) REFERENCES public.warehouses (warehouse_id) ON DELETE RESTRICT
);

CREATE TABLE public.sub_catalogs (
    sub_catalog_id integer GENERATED BY DEFAULT AS IDENTITY,
    is_active boolean NOT NULL DEFAULT TRUE,
    catalog_name character varying(150),
    description character varying(500),
    catalog_id integer NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_sub_catalogs" PRIMARY KEY (sub_catalog_id),
    CONSTRAINT "FK_sub_catalogs_catalogs_catalog_id" FOREIGN KEY (catalog_id) REFERENCES public.catalogs (catalog_id) ON DELETE CASCADE
);

CREATE TABLE public.assigned_travel_expenses (
    assigned_travel_expense_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    amount_in_dollars numeric(18,2) NOT NULL,
    amount_in_local_currency numeric(18,2) NOT NULL,
    currency integer NOT NULL,
    collaborator_id uuid NOT NULL,
    type_income_id uuid NOT NULL,
    start_date timestamp with time zone NOT NULL,
    end_date timestamp with time zone,
    updated_at timestamp with time zone,
    updated_by text,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_assigned_travel_expenses" PRIMARY KEY (assigned_travel_expense_id),
    CONSTRAINT "FK_assigned_travel_expenses_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE CASCADE,
    CONSTRAINT "FK_assigned_travel_expenses_types_income_type_income_id" FOREIGN KEY (type_income_id) REFERENCES public.types_income (type_income_id) ON DELETE RESTRICT
);

CREATE TABLE public.deductions (
    deduction_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    currency currency_enum NOT NULL,
    deduction_type deduction_type_enum NOT NULL,
    status deduction_status_enum NOT NULL,
    description text,
    number_fortnights integer,
    number_fortnights_paid integer,
    fortnightly_amount numeric(18,2),
    fortnightly_amount_in_dollars numeric(18,2),
    amount numeric,
    percentage integer,
    total_balance numeric(18,2),
    total_balance_in_dollars numeric(18,2),
    amount_paid numeric(18,2),
    amount_paid_in_dollars numeric(18,2),
    total_amount numeric(18,2) NOT NULL,
    total_amount_in_dollars numeric(18,2) NOT NULL,
    collaborator_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_deductions" PRIMARY KEY (deduction_id),
    CONSTRAINT "FK_deductions_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT
);

CREATE TABLE public.permit_applications_pending (
    permit_application_pending_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    collaborator_id uuid NOT NULL,
    is_active boolean NOT NULL,
    description text,
    start_date date NOT NULL,
    end_date date NOT NULL,
    start_time time without time zone,
    end_time time without time zone,
    permit_application_type permit_application_type_enum NOT NULL,
    additional_data jsonb NOT NULL,
    requested_by text NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_permit_applications_pending" PRIMARY KEY (permit_application_pending_id),
    CONSTRAINT "FK_permit_applications_pending_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT
);

CREATE TABLE public.salaries (
    salary_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    collaborator_id uuid NOT NULL,
    amount_in_local numeric(18,2) NOT NULL,
    amount_in_foreign numeric(18,2) NOT NULL,
    amount_salary numeric(18,2) NOT NULL,
    bank_id integer NOT NULL,
    currency currency_enum NOT NULL,
    salary_type salary_type_enum NOT NULL,
    start_date timestamp with time zone NOT NULL,
    end_date timestamp with time zone,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_salaries" PRIMARY KEY (salary_id),
    CONSTRAINT "FK_salaries_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE CASCADE
);

CREATE TABLE public.vacations (
    vacation_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    collaborator_id uuid NOT NULL,
    available_vacations numeric(18,4) NOT NULL,
    genered_vacation numeric(18,4) NOT NULL,
    enjoyed_vacation numeric(18,4) NOT NULL,
    donated_vacation numeric(18,4) NOT NULL DEFAULT 0.0,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_vacations" PRIMARY KEY (vacation_id),
    CONSTRAINT "FK_vacations_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE CASCADE
);

CREATE TABLE public.cost_centers (
    cost_center_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    is_active boolean NOT NULL DEFAULT TRUE,
    description character varying(150),
    cost_center_name character varying(100),
    coil_code integer NOT NULL,
    cost_center_code integer NOT NULL,
    work_area_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_cost_centers" PRIMARY KEY (cost_center_id),
    CONSTRAINT "FK_cost_centers_work_areas_work_area_id" FOREIGN KEY (work_area_id) REFERENCES public.work_areas (work_area_id) ON DELETE RESTRICT
);

CREATE TABLE public.products (
    product_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    product_sku character varying(50) NOT NULL,
    name character varying(100) NOT NULL,
    description text,
    unit_of_measure character varying(20) NOT NULL,
    is_active boolean NOT NULL DEFAULT TRUE,
    category_id uuid NOT NULL,
    customer_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_products" PRIMARY KEY (product_id),
    CONSTRAINT "FK_products_category_products_category_id" FOREIGN KEY (category_id) REFERENCES public.category_products (category_product_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_products_customers_customer_id" FOREIGN KEY (customer_id) REFERENCES public.customers (customer_id) ON DELETE RESTRICT
);

CREATE TABLE public.service_orders (
    service_order_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    code character varying(50) NOT NULL,
    oos_status oss_status_enum NOT NULL,
    observations character varying(500),
    customer_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_service_orders" PRIMARY KEY (service_order_id),
    CONSTRAINT "FK_service_orders_customers_customer_id" FOREIGN KEY (customer_id) REFERENCES public.customers (customer_id) ON DELETE RESTRICT
);

CREATE TABLE public.user_module_roles (
    user_module_role_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    role_id uuid NOT NULL,
    user_profile_id uuid NOT NULL,
    module_id uuid NOT NULL,
    is_active boolean NOT NULL DEFAULT TRUE,
    module_code text NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_user_module_roles" PRIMARY KEY (user_module_role_id),
    CONSTRAINT "FK_user_module_roles_modules_module_id" FOREIGN KEY (module_id) REFERENCES public.modules (module_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_user_module_roles_roles_role_id" FOREIGN KEY (role_id) REFERENCES public.roles (role_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_user_module_roles_users_profiles_user_profile_id" FOREIGN KEY (user_profile_id) REFERENCES public.users_profiles (user_profile_id) ON DELETE CASCADE
);

CREATE TABLE public.christmas_bonus_accruals (
    christmas_bonus_accrual_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    base_salary numeric(18,2) NOT NULL,
    equivalent_quantity numeric(18,2) NOT NULL,
    christmas_bonus_days numeric(18,2) NOT NULL,
    equivalent_quantity_in_dollars numeric(18,2) NOT NULL,
    collaborator_id uuid NOT NULL,
    payroll_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_christmas_bonus_accruals" PRIMARY KEY (christmas_bonus_accrual_id),
    CONSTRAINT "FK_christmas_bonus_accruals_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE CASCADE,
    CONSTRAINT "FK_christmas_bonus_accruals_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE CASCADE
);

CREATE TABLE public.income_tax_accrual (
    income_tax_accrual_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    salary_earned numeric(18,2) NOT NULL,
    accumulated_ir numeric(18,2) NOT NULL,
    accumulated_seniority numeric(18,2) NOT NULL,
    accumulated_ir_by_fornight numeric(18,2) NOT NULL,
    salary_earned_by_fornight numeric(18,2) NOT NULL,
    accumulated_ir_monthly numeric(18,2) NOT NULL,
    salary_earned_monthly numeric(18,2) NOT NULL,
    flag_salary_earned numeric(18,2) NOT NULL,
    flag_accumulated_ir numeric(18,2) NOT NULL,
    number_of_fortnights integer NOT NULL,
    flag_number_of_fortnights integer NOT NULL,
    payroll_id uuid NOT NULL,
    collaborator_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_income_tax_accrual" PRIMARY KEY (income_tax_accrual_id),
    CONSTRAINT "FK_income_tax_accrual_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_income_tax_accrual_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE CASCADE
);

CREATE TABLE public.incomes (
    income_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    amount_in_local numeric(18,2) NOT NULL,
    amount_in_dollars numeric(18,2) NOT NULL,
    description text NOT NULL,
    currency integer NOT NULL,
    collaborator_id uuid NOT NULL,
    income_type_id uuid NOT NULL,
    payroll_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_incomes" PRIMARY KEY (income_id),
    CONSTRAINT "FK_incomes_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_incomes_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_incomes_types_income_income_type_id" FOREIGN KEY (income_type_id) REFERENCES public.types_income (type_income_id) ON DELETE RESTRICT
);

CREATE TABLE public.inss_accounting_information (
    inss_information_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    total numeric(18,2) NOT NULL,
    inatec numeric(18,2) NOT NULL,
    absence numeric(18,2) NOT NULL,
    inss_labor numeric(18,2) NOT NULL,
    inss_patronal numeric(18,2) NOT NULL,
    income numeric(18,2) NOT NULL,
    days_absence integer NOT NULL,
    payroll_id uuid NOT NULL,
    collaborator_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_inss_accounting_information" PRIMARY KEY (inss_information_id),
    CONSTRAINT "FK_inss_accounting_information_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_inss_accounting_information_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE RESTRICT
);

CREATE TABLE public.ordinary_payrolls (
    ordinary_payroll_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    biweekly_salary numeric(18,2) NOT NULL,
    deductions_additional_data jsonb NOT NULL,
    total_deductions numeric(18,2) NOT NULL,
    antique numeric(18,2) NOT NULL,
    year_antique integer NOT NULL DEFAULT 0,
    percent_antique integer NOT NULL DEFAULT 0,
    bonus numeric(18,2) NOT NULL,
    overtimes numeric(18,2) NOT NULL,
    commissions numeric(18,2) NOT NULL,
    number_overtime numeric(18,2) NOT NULL,
    amount_days_vacation numeric(18,2) NOT NULL DEFAULT 0.0,
    total_income numeric(18,2) NOT NULL,
    transport numeric(18,2) NOT NULL,
    feeding numeric(18,2) NOT NULL,
    lodging numeric(18,2) NOT NULL,
    total_travel_expenses numeric(18,2) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    ir numeric(18,2) NOT NULL,
    inss numeric(18,2) NOT NULL,
    vacations numeric(18,2) NOT NULL,
    christmas_bonus numeric(18,2) NOT NULL,
    total_legal_deductions numeric(18,2) NOT NULL,
    gross_salary numeric(18,2) NOT NULL,
    total_to_pay numeric(18,2) NOT NULL,
    payroll_id uuid NOT NULL,
    collaborator_id uuid NOT NULL,
    CONSTRAINT "PK_ordinary_payrolls" PRIMARY KEY (ordinary_payroll_id),
    CONSTRAINT "FK_ordinary_payrolls_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_ordinary_payrolls_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE CASCADE
);

CREATE TABLE public.permit_applications (
    permit_application_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    collaborator_code text NOT NULL,
    collaborator_id uuid NOT NULL,
    payroll_id uuid NOT NULL,
    permit_application_type permit_application_type_enum NOT NULL,
    status permit_application_status_enum NOT NULL,
    is_with_range_date boolean NOT NULL DEFAULT TRUE,
    additional_data jsonb NOT NULL,
    first_step_approved boolean,
    second_step_approved boolean,
    manager_fullname text,
    administrator_fullname text,
    amount_days numeric(18,4) NOT NULL,
    identification_collaborator_to_receive text,
    requested_by text NOT NULL,
    description text,
    start_date date NOT NULL,
    end_date date NOT NULL,
    start_time time without time zone,
    end_time time without time zone,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_permit_applications" PRIMARY KEY (permit_application_id),
    CONSTRAINT "FK_permit_applications_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_permit_applications_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE RESTRICT
);

CREATE TABLE public.professional_services_payrolls (
    professional_services_payroll_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    vigemsa_additional_data jsonb NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    ir numeric(18,2) NOT NULL,
    inss numeric(18,2) NOT NULL,
    vacations numeric(18,2) NOT NULL,
    christmas_bonus numeric(18,2) NOT NULL,
    total_legal_deductions numeric(18,2) NOT NULL,
    gross_salary numeric(18,2) NOT NULL,
    total_to_pay numeric(18,2) NOT NULL,
    payroll_id uuid NOT NULL,
    collaborator_id uuid NOT NULL,
    CONSTRAINT "PK_professional_services_payrolls" PRIMARY KEY (professional_services_payroll_id),
    CONSTRAINT "FK_professional_services_payrolls_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_professional_services_payrolls_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE CASCADE
);

CREATE TABLE public.records_travel_expense_payments (
    records_travel_expense_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    paid_days integer NOT NULL,
    lodging numeric(18,2) NOT NULL,
    feeding numeric(18,2) NOT NULL,
    transport numeric(18,2) NOT NULL,
    payroll_id uuid NOT NULL,
    collaborator_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_records_travel_expense_payments" PRIMARY KEY (records_travel_expense_id),
    CONSTRAINT "FK_records_travel_expense_payments_collaborators_collaborator_~" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_records_travel_expense_payments_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE RESTRICT
);

CREATE TABLE public.subsidies (
    subsidy_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    start_date timestamp with time zone NOT NULL,
    end_date timestamp with time zone NOT NULL,
    amount_days integer NOT NULL,
    percentage numeric(5,2) NOT NULL,
    reference_number character varying(100) NOT NULL,
    observations character varying(500),
    payroll_id uuid NOT NULL,
    type_subsidy_id uuid NOT NULL,
    collaborator_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_subsidies" PRIMARY KEY (subsidy_id),
    CONSTRAINT "FK_subsidies_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_subsidies_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE CASCADE,
    CONSTRAINT "FK_subsidies_types_subsidy_type_subsidy_id" FOREIGN KEY (type_subsidy_id) REFERENCES public.types_subsidy (type_subsidy_id) ON DELETE RESTRICT
);

CREATE TABLE public.vacations_accruals (
    vacation_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    final_balance numeric(18,2) NOT NULL,
    beginning_balance numeric(18,2) NOT NULL,
    available_vacations numeric(18,2) NOT NULL,
    equivalent_quantity numeric(18,2) NOT NULL,
    equivalent_quantity_in_dollars numeric(18,2) NOT NULL,
    collaborator_id uuid NOT NULL,
    payroll_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_vacations_accruals" PRIMARY KEY (vacation_id),
    CONSTRAINT "FK_vacations_accruals_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_vacations_accruals_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE RESTRICT
);

CREATE TABLE public.record_entrances_managua (
    record_entrance_managua_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    service_order_id uuid NOT NULL,
    warehouse_id uuid NOT NULL,
    current_step_id integer NOT NULL,
    status integer NOT NULL,
    closed_at timestamp with time zone NOT NULL,
    is_consolidated boolean NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_record_entrances_managua" PRIMARY KEY (record_entrance_managua_id),
    CONSTRAINT "FK_record_entrances_managua_warehouses_warehouse_id" FOREIGN KEY (warehouse_id) REFERENCES public.warehouses (warehouse_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_record_entrances_managua_workflow_step_definitions_current_~" FOREIGN KEY (current_step_id) REFERENCES public.workflow_step_definitions (id) ON DELETE RESTRICT
);

CREATE TABLE public.zones_managua (
    id uuid NOT NULL DEFAULT (gen_random_uuid()),
    code character varying(50) NOT NULL,
    zone_name character varying(150) NOT NULL,
    width_metres numeric(10,2) NOT NULL,
    length_metres numeric(10,2) NOT NULL,
    heigth_metres numeric(10,2) NOT NULL,
    total_colume_capacity_m3 numeric(12,3) NOT NULL,
    max_weight_capacity_kg numeric(14,2) NOT NULL,
    is_active boolean NOT NULL,
    warehouse_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_zones_managua" PRIMARY KEY (id),
    CONSTRAINT "FK_zones_managua_warehouses_warehouse_id" FOREIGN KEY (warehouse_id) REFERENCES public.warehouses (warehouse_id) ON DELETE RESTRICT
);

CREATE TABLE public.personal_informations (
    personal_information_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    collaborator_id uuid NOT NULL,
    personal_email text,
    personal_phone_number text,
    address text,
    departament_id integer,
    birthdate timestamp with time zone NOT NULL,
    marital_status marital_status_enum NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_personal_informations" PRIMARY KEY (personal_information_id),
    CONSTRAINT "FK_personal_informations_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE CASCADE,
    CONSTRAINT "FK_personal_informations_sub_catalogs_departament_id" FOREIGN KEY (departament_id) REFERENCES public.sub_catalogs (sub_catalog_id) ON DELETE RESTRICT
);

CREATE TABLE public.work_position_histories (
    work_position_history_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    collaborator_id uuid NOT NULL,
    work_position_id integer NOT NULL,
    job_position_id uuid NOT NULL,
    start_date timestamp with time zone NOT NULL,
    end_date timestamp with time zone,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_work_position_histories" PRIMARY KEY (work_position_history_id),
    CONSTRAINT "FK_work_position_histories_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE CASCADE,
    CONSTRAINT "FK_work_position_histories_sub_catalogs_work_position_id" FOREIGN KEY (work_position_id) REFERENCES public.sub_catalogs (sub_catalog_id) ON DELETE RESTRICT
);

CREATE TABLE public.working_information (
    working_information_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    daem text,
    work_email text,
    inss_number text,
    work_phone_number text,
    bank_account_number text,
    work_position_id integer NOT NULL,
    company_branch_id uuid NOT NULL,
    area_id uuid NOT NULL,
    branch_id uuid,
    job_position_id uuid,
    entry_date date NOT NULL,
    departure_date date,
    collaborator_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_working_information" PRIMARY KEY (working_information_id),
    CONSTRAINT "FK_working_information_branches_company_branch_id" FOREIGN KEY (company_branch_id) REFERENCES public.branches (branch_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_working_information_collaborators_collaborator_id" FOREIGN KEY (collaborator_id) REFERENCES public.collaborators (collaborator_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_working_information_sub_catalogs_work_position_id" FOREIGN KEY (work_position_id) REFERENCES public.sub_catalogs (sub_catalog_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_working_information_work_areas_area_id" FOREIGN KEY (area_id) REFERENCES public.work_areas (work_area_id) ON DELETE RESTRICT
);

CREATE TABLE public.deductions_payment_histories (
    payment_history_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    payment_date timestamp with time zone NOT NULL,
    currency currency_enum NOT NULL,
    amount_paid numeric(18,2) NOT NULL,
    amount_paid_in_dollars numeric(18,2) NOT NULL,
    status deduction_payment_status NOT NULL,
    origin source_deduction_payment_enum NOT NULL,
    payroll_id uuid NOT NULL,
    deduction_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_deductions_payment_histories" PRIMARY KEY (payment_history_id),
    CONSTRAINT "FK_deductions_payment_histories_deductions_deduction_id" FOREIGN KEY (deduction_id) REFERENCES public.deductions (deduction_id) ON DELETE CASCADE,
    CONSTRAINT "FK_deductions_payment_histories_payrolls_payroll_id" FOREIGN KEY (payroll_id) REFERENCES public.payrolls (payroll_id) ON DELETE CASCADE
);

CREATE TABLE public.assistance_control (
    assistance_control_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    shift_date date NOT NULL,
    amount_hours numeric(18,2) NOT NULL,
    professioal_payroll_id uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_assistance_control" PRIMARY KEY (assistance_control_id),
    CONSTRAINT "FK_assistance_control_professional_services_payrolls_professio~" FOREIGN KEY (professioal_payroll_id) REFERENCES public.professional_services_payrolls (professional_services_payroll_id) ON DELETE RESTRICT
);

CREATE TABLE public.ducat_registry_managua (
    ducat_registtry_id uuid NOT NULL,
    record_entrance_managua_id uuid NOT NULL,
    registry_date timestamp with time zone NOT NULL,
    trailer_identifier character varying(50) NOT NULL,
    empresa character varying(150) NOT NULL,
    registered_by_user_id character varying(450) NOT NULL,
    general_observations character varying(1000),
    is_in_transit boolean NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_ducat_registry_managua" PRIMARY KEY (ducat_registtry_id),
    CONSTRAINT "FK_ducat_registry_managua_record_entrances_managua_record_entr~" FOREIGN KEY (record_entrance_managua_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE RESTRICT
);

CREATE TABLE public.entrance_ducats_managua (
    entrance_ducat_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    record_entrance_managua_id uuid NOT NULL,
    ducat_number character varying(100) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_entrance_ducats_managua" PRIMARY KEY (entrance_ducat_id),
    CONSTRAINT "FK_entrance_ducats_managua_record_entrances_managua_record_ent~" FOREIGN KEY (record_entrance_managua_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE RESTRICT
);

CREATE TABLE public.manifest_cancellations_managua (
    manifest_cancellation_id uuid NOT NULL,
    service_orders_id uuid NOT NULL,
    record_entrance_managua_id uuid NOT NULL,
    manifest_number character varying(100) NOT NULL,
    container_count integer NOT NULL,
    container_dimension text NOT NULL,
    personal_type character varying(500) NOT NULL,
    customs_officer_signature character varying(250) NOT NULL,
    warehouse_chief_signature character varying(250) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_manifest_cancellations_managua" PRIMARY KEY (manifest_cancellation_id),
    CONSTRAINT "FK_manifest_cancellations_managua_record_entrances_managua_rec~" FOREIGN KEY (record_entrance_managua_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_manifest_cancellations_managua_service_orders_service_order~" FOREIGN KEY (service_orders_id) REFERENCES public.service_orders (service_order_id) ON DELETE RESTRICT
);

CREATE TABLE public.reception_details_managua (
    reception_details_managua_id uuid NOT NULL,
    record_entrance_managua_id uuid NOT NULL,
    country_of_origin character varying(100) NOT NULL,
    aduana character varying(150) NOT NULL,
    gate_entrance_time timestamp with time zone NOT NULL,
    plate_number character varying(30) NOT NULL,
    trailer_chassis character varying(50) NOT NULL,
    driver_license character varying(50) NOT NULL,
    transportista character varying(150) NOT NULL,
    medio character varying(100) NOT NULL,
    driver_name character varying(200) NOT NULL,
    consignee character varying(200) NOT NULL,
    seal_number character varying(50) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_reception_details_managua" PRIMARY KEY (reception_details_managua_id),
    CONSTRAINT "FK_reception_details_managua_record_entrances_managua_record_e~" FOREIGN KEY (record_entrance_managua_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE RESTRICT
);

CREATE TABLE public.step_execution_logs_managua (
    step_execution_logs_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    record_entrance_id uuid NOT NULL,
    workflow_step_definition_id integer NOT NULL,
    start_time timestamp with time zone NOT NULL,
    end_time timestamp with time zone,
    processed_by_user_id character varying(450) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_step_execution_logs_managua" PRIMARY KEY (step_execution_logs_id),
    CONSTRAINT "FK_step_execution_logs_managua_record_entrances_managua_record~" FOREIGN KEY (record_entrance_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_step_execution_logs_managua_workflow_step_definitions_workf~" FOREIGN KEY (workflow_step_definition_id) REFERENCES public.workflow_step_definitions (id) ON DELETE RESTRICT
);

CREATE TABLE public.warehouse_receipts_managua (
    id uuid NOT NULL,
    record_entrance_managua_id uuid NOT NULL,
    receipt_number character varying(100) NOT NULL,
    resa_number character varying(100) NOT NULL,
    customs_cif_value numeric(18,4) NOT NULL,
    customs_brokerage character varying(150) NOT NULL,
    receipt_creation_date timestamp with time zone NOT NULL,
    receipt_cancellation_date timestamp with time zone,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_warehouse_receipts_managua" PRIMARY KEY (id),
    CONSTRAINT "FK_warehouse_receipts_managua_record_entrances_managua_record_~" FOREIGN KEY (record_entrance_managua_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE RESTRICT
);

CREATE TABLE public.racks_managua (
    racks_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    zone_id uuid NOT NULL,
    code character varying(50) NOT NULL,
    row_number integer NOT NULL,
    level_number integer NOT NULL,
    cost_per_position numeric(12,4) NOT NULL,
    is_available boolean NOT NULL DEFAULT TRUE,
    max_weight_kg numeric(12,2) NOT NULL,
    max_height_metres numeric(10,2) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_racks_managua" PRIMARY KEY (racks_id),
    CONSTRAINT "FK_racks_managua_zones_managua_zone_id" FOREIGN KEY (zone_id) REFERENCES public.zones_managua (id) ON DELETE RESTRICT
);

CREATE TABLE public.discrepancies_managua (
    discrepancy_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    discrepancy_type character varying(50) NOT NULL,
    declared_quantity numeric(18,2) NOT NULL,
    found_quantity numeric(18,2) NOT NULL,
    customs_letter_reference character varying(100),
    description character varying(1000) NOT NULL,
    is_damage boolean NOT NULL,
    record_entrance_id uuid NOT NULL,
    entrance_ducats_id uuid NOT NULL,
    "RecordEntranceManaguaId1" uuid,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_discrepancies_managua" PRIMARY KEY (discrepancy_id),
    CONSTRAINT "FK_discrepancies_managua_entrance_ducats_managua_entrance_duca~" FOREIGN KEY (entrance_ducats_id) REFERENCES public.entrance_ducats_managua (entrance_ducat_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_discrepancies_managua_record_entrances_managua_RecordEntran~" FOREIGN KEY ("RecordEntranceManaguaId1") REFERENCES public.record_entrances_managua (record_entrance_managua_id),
    CONSTRAINT "FK_discrepancies_managua_record_entrances_managua_record_entra~" FOREIGN KEY (record_entrance_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE RESTRICT
);

CREATE TABLE public.ducat_registry_details_managua (
    ducat_registry_detail_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    record_entrance_id uuid NOT NULL,
    entrance_ducat_managua_id uuid NOT NULL,
    category_product_id uuid NOT NULL,
    total_bultos integer NOT NULL,
    total_weight numeric(18,4) NOT NULL,
    product_description character varying(500) NOT NULL,
    remitente character varying(200) NOT NULL,
    destination_area_observation character varying(500) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_ducat_registry_details_managua" PRIMARY KEY (ducat_registry_detail_id),
    CONSTRAINT "FK_ducat_registry_details_managua_category_products_category_p~" FOREIGN KEY (category_product_id) REFERENCES public.category_products (category_product_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_ducat_registry_details_managua_ducat_registry_managua_recor~" FOREIGN KEY (record_entrance_id) REFERENCES public.ducat_registry_managua (ducat_registtry_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_ducat_registry_details_managua_entrance_ducats_managua_entr~" FOREIGN KEY (entrance_ducat_managua_id) REFERENCES public.entrance_ducats_managua (entrance_ducat_id) ON DELETE RESTRICT
);

CREATE TABLE public.stocks_managua (
    stock_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    warehouse_id uuid NOT NULL,
    entrance_ducats_managua_id uuid NOT NULL,
    zone_managua_id uuid NOT NULL,
    racks_managua_id uuid NOT NULL,
    category_product_id uuid NOT NULL,
    current_bultos integer NOT NULL,
    current_weight_kg numeric(18,4) NOT NULL,
    stored_at timestamp with time zone NOT NULL,
    row_version bytea NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_stocks_managua" PRIMARY KEY (stock_id),
    CONSTRAINT "FK_stocks_managua_category_products_category_product_id" FOREIGN KEY (category_product_id) REFERENCES public.category_products (category_product_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_stocks_managua_entrance_ducats_managua_entrance_ducats_mana~" FOREIGN KEY (entrance_ducats_managua_id) REFERENCES public.entrance_ducats_managua (entrance_ducat_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_stocks_managua_racks_managua_racks_managua_id" FOREIGN KEY (racks_managua_id) REFERENCES public.racks_managua (racks_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_stocks_managua_zones_managua_zone_managua_id" FOREIGN KEY (zone_managua_id) REFERENCES public.zones_managua (id) ON DELETE RESTRICT
);

CREATE TABLE public.warehouse_assignments_managua (
    id uuid NOT NULL,
    record_entrance_managua_id uuid NOT NULL,
    warehouse_id uuid NOT NULL,
    zone_id uuid NOT NULL,
    rack_id uuid NOT NULL,
    assigned_at timestamp with time zone NOT NULL,
    assigned_by_user_id character varying(450) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_warehouse_assignments_managua" PRIMARY KEY (id),
    CONSTRAINT "FK_warehouse_assignments_managua_racks_managua_rack_id" FOREIGN KEY (rack_id) REFERENCES public.racks_managua (racks_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_warehouse_assignments_managua_record_entrances_managua_reco~" FOREIGN KEY (record_entrance_managua_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE CASCADE,
    CONSTRAINT "FK_warehouse_assignments_managua_warehouses_warehouse_id" FOREIGN KEY (warehouse_id) REFERENCES public.warehouses (warehouse_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_warehouse_assignments_managua_zones_managua_zone_id" FOREIGN KEY (zone_id) REFERENCES public.zones_managua (id) ON DELETE RESTRICT
);

CREATE TABLE public.unloading_details_managua (
    unloading_details_managua_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    record_entrance_managua_id uuid NOT NULL,
    warehouse_assignments_managua_id uuid NOT NULL,
    unloading_start_time timestamp with time zone NOT NULL,
    unloading_end_time timestamp with time zone NOT NULL,
    warehouse_chief_user_id character varying(450) NOT NULL,
    prepared_pallets numeric(2,0) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_unloading_details_managua" PRIMARY KEY (unloading_details_managua_id),
    CONSTRAINT "FK_unloading_details_managua_record_entrances_managua_record_e~" FOREIGN KEY (record_entrance_managua_id) REFERENCES public.record_entrances_managua (record_entrance_managua_id) ON DELETE RESTRICT,
    CONSTRAINT "FK_unloading_details_managua_warehouse_assignments_managua_war~" FOREIGN KEY (warehouse_assignments_managua_id) REFERENCES public.warehouse_assignments_managua (id) ON DELETE RESTRICT
);

CREATE TABLE public.unloading_crew_assignments_managua (
    unloading_details_managua_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    assigned_at timestamp with time zone NOT NULL,
    persona_count integer NOT NULL,
    tercerizada boolean NOT NULL,
    "UnloadingDetailsManaguaId" uuid NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_unloading_crew_assignments_managua" PRIMARY KEY (unloading_details_managua_id),
    CONSTRAINT "FK_unloading_crew_assignments_managua_unloading_details_managu~" FOREIGN KEY ("UnloadingDetailsManaguaId") REFERENCES public.unloading_details_managua (unloading_details_managua_id) ON DELETE RESTRICT
);

CREATE TABLE public."UnloadingMachineryAssignmentsManagua" (
    unloading_machinery_assignment_id uuid NOT NULL DEFAULT (gen_random_uuid()),
    unloading_details_managua_id uuid NOT NULL,
    machinery_code uuid NOT NULL,
    machinery_type uuid NOT NULL,
    start_time timestamp with time zone NOT NULL,
    end_time timestamp with time zone NOT NULL,
    assigned_by_user_id character varying(450) NOT NULL,
    deleted_at timestamp with time zone,
    created_at timestamp with time zone NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "PK_UnloadingMachineryAssignmentsManagua" PRIMARY KEY (unloading_machinery_assignment_id),
    CONSTRAINT "FK_UnloadingMachineryAssignmentsManagua_unloading_details_mana~" FOREIGN KEY (unloading_details_managua_id) REFERENCES public.unloading_details_managua (unloading_details_managua_id) ON DELETE RESTRICT
);

CREATE INDEX "IX_assigned_travel_expenses_collaborator_id" ON public.assigned_travel_expenses (collaborator_id);

CREATE INDEX "IX_assigned_travel_expenses_type_income_id" ON public.assigned_travel_expenses (type_income_id);

CREATE INDEX "IX_assistance_control_professioal_payroll_id" ON public.assistance_control (professioal_payroll_id);

CREATE INDEX "IX_branches_company_id" ON public.branches (company_id);

CREATE UNIQUE INDEX "IX_catalogs_company_type" ON public.catalogs (company_id, catalog_name, catalog_type);

CREATE INDEX "IX_category_products_parent_id" ON public.category_products (parent_id);

CREATE INDEX "IX_christmas_bonus_accruals_payroll_id" ON public.christmas_bonus_accruals (payroll_id);

CREATE UNIQUE INDEX ix_christmas_bonus_collaborator_id ON public.christmas_bonus_accruals (collaborator_id);

CREATE UNIQUE INDEX "IX_collaborator_id" ON public.collaborators (collaborator_id);

CREATE UNIQUE INDEX "IX_collaborators_collaborator_code" ON public.collaborators (collaborator_code);

CREATE INDEX "IX_collaborators_company_id" ON public.collaborators (company_id);

CREATE INDEX "IX_collaborators_identification_number" ON public.collaborators (identification_number);

CREATE UNIQUE INDEX "IX_companies_code" ON public.companies (code);

CREATE UNIQUE INDEX "IX_companies_id" ON public.companies (company_id);

CREATE UNIQUE INDEX "IX_cost_center_id" ON public.cost_centers (cost_center_id);

CREATE INDEX "IX_cost_centers_work_area_id" ON public.cost_centers (work_area_id);

CREATE UNIQUE INDEX ix_customer_id ON public.customers (customer_id);

CREATE INDEX "IX_customers_customer_type_id" ON public.customers (customer_type_id);

CREATE UNIQUE INDEX ux_customer_dni_ruc ON public.customers (dni_ruc);

CREATE UNIQUE INDEX ix_deduction_id ON public.deductions (deduction_id);

CREATE INDEX "IX_deductions_collaborator_id" ON public.deductions (collaborator_id);

CREATE INDEX "IX_deductions_payment_histories_deduction_id" ON public.deductions_payment_histories (deduction_id);

CREATE INDEX "IX_deductions_payment_histories_payroll_id" ON public.deductions_payment_histories (payroll_id);

CREATE UNIQUE INDEX ix_payment_id ON public.deductions_payment_histories (payment_history_id);

CREATE INDEX "IX_discrepancies_managua_entrance_ducats_id" ON public.discrepancies_managua (entrance_ducats_id);

CREATE INDEX "IX_discrepancies_managua_record_entrance_id" ON public.discrepancies_managua (record_entrance_id);

CREATE INDEX "IX_discrepancies_managua_RecordEntranceManaguaId1" ON public.discrepancies_managua ("RecordEntranceManaguaId1");

CREATE UNIQUE INDEX ix_discrepancy_id ON public.discrepancies_managua (discrepancy_id);

CREATE INDEX "IX_ducat_registry_details_managua_category_product_id" ON public.ducat_registry_details_managua (category_product_id);

CREATE UNIQUE INDEX "IX_ducat_registry_details_managua_entrance_ducat_managua_id" ON public.ducat_registry_details_managua (entrance_ducat_managua_id);

CREATE INDEX "IX_ducat_registry_details_managua_record_entrance_id" ON public.ducat_registry_details_managua (record_entrance_id);

CREATE UNIQUE INDEX "IX_ducat_registry_managua_record_entrance_managua_id" ON public.ducat_registry_managua (record_entrance_managua_id);

CREATE INDEX "IX_entrance_ducats_managua_record_entrance_managua_id" ON public.entrance_ducats_managua (record_entrance_managua_id);

CREATE UNIQUE INDEX ix_holiday_id ON public.holidays (holiday_id);

CREATE INDEX "IX_income_tax_accrual_collaborator_id" ON public.income_tax_accrual (collaborator_id);

CREATE INDEX "IX_income_tax_accrual_payroll_id" ON public.income_tax_accrual (payroll_id);

CREATE UNIQUE INDEX ix_income_tax_id ON public.income_tax_accrual (income_tax_accrual_id);

CREATE UNIQUE INDEX ix_income_id ON public.incomes (income_id);

CREATE INDEX "IX_incomes_collaborator_id" ON public.incomes (collaborator_id);

CREATE INDEX "IX_incomes_income_type_id" ON public.incomes (income_type_id);

CREATE INDEX "IX_incomes_payroll_id" ON public.incomes (payroll_id);

CREATE INDEX "IX_inss_accounting_information_collaborator_id" ON public.inss_accounting_information (collaborator_id);

CREATE INDEX "IX_inss_accounting_information_payroll_id" ON public.inss_accounting_information (payroll_id);

CREATE UNIQUE INDEX ix_inss_information_id ON public.inss_accounting_information (inss_information_id);

CREATE UNIQUE INDEX "IX_job_position_id" ON public.job_positions (job_position_id);

CREATE INDEX "IX_job_positions_company_id" ON public.job_positions (company_id);

CREATE INDEX ix_location_id ON public.locations (location_id);

CREATE INDEX "IX_locations_company_id" ON public.locations (company_id);

CREATE UNIQUE INDEX "IX_manifest_cancellations_managua_record_entrance_managua_id" ON public.manifest_cancellations_managua (record_entrance_managua_id);

CREATE INDEX "IX_manifest_cancellations_managua_service_orders_id" ON public.manifest_cancellations_managua (service_orders_id);

CREATE INDEX ix_modules_company_code ON public.modules (code);

CREATE UNIQUE INDEX ix_ordinary_payroll_id ON public.ordinary_payrolls (ordinary_payroll_id);

CREATE INDEX "IX_ordinary_payrolls_collaborator_id" ON public.ordinary_payrolls (collaborator_id);

CREATE INDEX "IX_ordinary_payrolls_payroll_id" ON public.ordinary_payrolls (payroll_id);

CREATE INDEX "IX_payment_fees_company_id" ON public.payment_fees (company_id);

CREATE INDEX ix_payment_fees_id ON public.payment_fees (payment_fess_id);

CREATE UNIQUE INDEX ix_payroll_id ON public.payrolls (payroll_id);

CREATE INDEX "IX_payrolls_company_branch_id" ON public.payrolls (company_branch_id);

CREATE INDEX ix_permission_id ON public.permissions (permission_id);

CREATE INDEX "IX_permissions_role_id" ON public.permissions (role_id);

CREATE UNIQUE INDEX ix_permit_application_id ON public.permit_applications (permit_application_id);

CREATE INDEX "IX_permit_applications_collaborator_id" ON public.permit_applications (collaborator_id);

CREATE INDEX "IX_permit_applications_payroll_id" ON public.permit_applications (payroll_id);

CREATE UNIQUE INDEX ix_permit_application_pending_id ON public.permit_applications_pending (permit_application_pending_id);

CREATE INDEX "IX_permit_applications_pending_collaborator_id" ON public.permit_applications_pending (collaborator_id);

CREATE UNIQUE INDEX "IX_personal_informations_collaborator_id" ON public.personal_informations (collaborator_id);

CREATE INDEX "IX_personal_informations_departament_id" ON public.personal_informations (departament_id);

CREATE UNIQUE INDEX ix_product_id ON public.products (product_id);

CREATE INDEX "IX_products_category_id" ON public.products (category_id);

CREATE INDEX "IX_products_customer_id" ON public.products (customer_id);

CREATE UNIQUE INDEX ix_prof_services_payroll_ordinary_payroll_id ON public.professional_services_payrolls (professional_services_payroll_id);

CREATE INDEX "IX_professional_services_payrolls_collaborator_id" ON public.professional_services_payrolls (collaborator_id);

CREATE INDEX "IX_professional_services_payrolls_payroll_id" ON public.professional_services_payrolls (payroll_id);

CREATE INDEX "IX_racks_managua_zone_id" ON public.racks_managua (zone_id);

CREATE UNIQUE INDEX "IX_reception_details_managua_record_entrance_managua_id" ON public.reception_details_managua (record_entrance_managua_id);

CREATE INDEX "IX_record_entrances_managua_current_step_id" ON public.record_entrances_managua (current_step_id);

CREATE INDEX "IX_record_entrances_managua_warehouse_id" ON public.record_entrances_managua (warehouse_id);

CREATE INDEX "IX_records_travel_expense_payments_collaborator_id" ON public.records_travel_expense_payments (collaborator_id);

CREATE INDEX "IX_records_travel_expense_payments_payroll_id" ON public.records_travel_expense_payments (payroll_id);

CREATE INDEX ix_role_id ON public.roles (role_id);

CREATE UNIQUE INDEX "IX_salaries_collaborator_id" ON public.salaries (collaborator_id);

CREATE UNIQUE INDEX ix_os_code ON public.service_orders (code);

CREATE INDEX "IX_service_orders_customer_id" ON public.service_orders (customer_id);

CREATE UNIQUE INDEX ix_service_orders_id ON public.service_orders (service_order_id);

CREATE INDEX ix_session_id ON public.sessions (session_id);

CREATE INDEX "IX_sessions_user_id" ON public.sessions (user_id);

CREATE INDEX "IX_step_execution_logs_managua_record_entrance_id" ON public.step_execution_logs_managua (record_entrance_id);

CREATE INDEX "IX_step_execution_logs_managua_workflow_step_definition_id" ON public.step_execution_logs_managua (workflow_step_definition_id);

CREATE INDEX "IX_stocks_managua_category_product_id" ON public.stocks_managua (category_product_id);

CREATE INDEX "IX_stocks_managua_entrance_ducats_managua_id" ON public.stocks_managua (entrance_ducats_managua_id);

CREATE INDEX "IX_stocks_managua_racks_managua_id" ON public.stocks_managua (racks_managua_id);

CREATE INDEX "IX_stocks_managua_zone_managua_id" ON public.stocks_managua (zone_managua_id);

CREATE INDEX "IX_sub_catalogs_catalog_id" ON public.sub_catalogs (catalog_id);

CREATE INDEX "IX_subsidies_collaborator_id" ON public.subsidies (collaborator_id);

CREATE INDEX "IX_subsidies_payroll_id" ON public.subsidies (payroll_id);

CREATE INDEX "IX_subsidies_type_subsidy_id" ON public.subsidies (type_subsidy_id);

CREATE INDEX "IX_types_accounting_payroll_company_id" ON public.types_accounting_payroll (company_id);

CREATE INDEX "IX_unloading_crew_assignments_managua_UnloadingDetailsManaguaId" ON public.unloading_crew_assignments_managua ("UnloadingDetailsManaguaId");

CREATE UNIQUE INDEX "IX_unloading_details_managua_record_entrance_managua_id" ON public.unloading_details_managua (record_entrance_managua_id);

CREATE UNIQUE INDEX "IX_unloading_details_managua_warehouse_assignments_managua_id" ON public.unloading_details_managua (warehouse_assignments_managua_id);

CREATE INDEX "IX_UnloadingMachineryAssignmentsManagua_unloading_details_mana~" ON public."UnloadingMachineryAssignmentsManagua" (unloading_details_managua_id);

CREATE UNIQUE INDEX "IX_Unique_User_Module_Role" ON public.user_module_roles (user_profile_id, module_code);

CREATE INDEX "IX_user_module_roles_module_id" ON public.user_module_roles (module_id);

CREATE INDEX "IX_user_module_roles_role_id" ON public.user_module_roles (role_id);

CREATE INDEX "IX_users_profiles_company_id" ON public.users_profiles (company_id);

CREATE INDEX "IX_users_profiles_user_id" ON public.users_profiles (user_id);

CREATE UNIQUE INDEX "IX_vacations_collaborator_id" ON public.vacations (collaborator_id);

CREATE UNIQUE INDEX "IX_vacations_accruals_collaborator_id" ON public.vacations_accruals (collaborator_id);

CREATE INDEX "IX_vacations_accruals_payroll_id" ON public.vacations_accruals (payroll_id);

CREATE INDEX "IX_warehouse_assignments_managua_rack_id" ON public.warehouse_assignments_managua (rack_id);

CREATE UNIQUE INDEX "IX_warehouse_assignments_managua_record_entrance_managua_id" ON public.warehouse_assignments_managua (record_entrance_managua_id);

CREATE INDEX "IX_warehouse_assignments_managua_warehouse_id" ON public.warehouse_assignments_managua (warehouse_id);

CREATE INDEX "IX_warehouse_assignments_managua_zone_id" ON public.warehouse_assignments_managua (zone_id);

CREATE UNIQUE INDEX "IX_warehouse_receipts_managua_receipt_number" ON public.warehouse_receipts_managua (receipt_number);

CREATE UNIQUE INDEX "IX_warehouse_receipts_managua_record_entrance_managua_id" ON public.warehouse_receipts_managua (record_entrance_managua_id);

CREATE UNIQUE INDEX ix_warehouse_id ON public.warehouses (warehouse_id);

CREATE INDEX "IX_warehouses_branch_id" ON public.warehouses (branch_id);

CREATE INDEX "IX_warehouses_parent_warehouse_id" ON public.warehouses (parent_warehouse_id);

CREATE UNIQUE INDEX "IX_work_area_id" ON public.work_areas (work_area_id);

CREATE INDEX "IX_work_areas_company_id" ON public.work_areas (company_id);

CREATE INDEX "IX_work_position_histories_collaborator_id" ON public.work_position_histories (collaborator_id);

CREATE INDEX "IX_work_position_histories_work_position_id" ON public.work_position_histories (work_position_id);

CREATE INDEX "IX_working_information_area_id" ON public.working_information (area_id);

CREATE UNIQUE INDEX "IX_working_information_collaborator_id" ON public.working_information (collaborator_id);

CREATE INDEX "IX_working_information_company_branch_id" ON public.working_information (company_branch_id);

CREATE INDEX "IX_working_information_work_position_id" ON public.working_information (work_position_id);

CREATE INDEX "IX_zones_managua_warehouse_id" ON public.zones_managua (warehouse_id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260710204033_InitialMigrations', '9.0.0');

COMMIT;

