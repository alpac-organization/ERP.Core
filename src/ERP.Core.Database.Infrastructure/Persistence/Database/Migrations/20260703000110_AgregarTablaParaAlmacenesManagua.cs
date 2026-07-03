using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablaParaAlmacenesManagua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discrepancies_managua_products_product_id",
                schema: "public",
                table: "discrepancies_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_managua_ducat_registry_headers_manag~",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_headers_managua_record_entrances_managua_rec~",
                schema: "public",
                table: "ducat_registry_headers_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_entrance_ducats_managua_record_entrances_managua_record_ent~",
                schema: "public",
                table: "entrance_ducats_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_racks_managua_zones_managua_zone_id",
                schema: "public",
                table: "racks_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_reception_details_managua_record_entrances_managua_record_e~",
                schema: "public",
                table: "reception_details_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_managua_manifest_cancellations_managua_Man~",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_managua_unloading_details_managua_Unloadin~",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_managua_warehouse_receipts_managua_Warehou~",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_managua_warehouses_warehouse_id",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_step_execution_logs_managua_record_entrances_managua_record~",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_step_execution_logs_managua_workflow_step_definitions_workf~",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_managua_products_product_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_managua_racks_managua_rack_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_managua_racks_managua_rack_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_managua_record_entrances_managua_reco~",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_managua_warehouses_warehouse_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropIndex(
                name: "IX_zones_managua_warehouse_id_code",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse_receipts_managua",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse_assignments_managua",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_unloading_details_managua",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropIndex(
                name: "IX_stocks_managua_product_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_managua_ManifestCancellationRecordEntrance~",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_managua_movement_number",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_managua_UnloadingDetailsRecordEntranceMana~",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_managua_WarehouseReceiptRecordEntranceMana~",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reception_details_managua",
                schema: "public",
                table: "reception_details_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_manifest_cancellations_managua",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ducat_registry_headers_managua",
                schema: "public",
                table: "ducat_registry_headers_managua");

            migrationBuilder.DropColumn(
                name: "prepared_pallets_per_hour",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "quantity",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropColumn(
                name: "ManifestCancellationRecordEntranceManaguaId",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropColumn(
                name: "UnloadingDetailsRecordEntranceManaguaId",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropColumn(
                name: "WarehouseReceiptRecordEntranceManaguaId",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropColumn(
                name: "movement_number",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropColumn(
                name: "is_occupied",
                schema: "public",
                table: "racks_managua");

            migrationBuilder.DropColumn(
                name: "personnel_type",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropColumn(
                name: "ducat_number",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropColumn(
                name: "sender_name",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropColumn(
                name: "aduana",
                schema: "public",
                table: "ducat_registry_headers_managua");

            migrationBuilder.DropColumn(
                name: "consignee",
                schema: "public",
                table: "ducat_registry_headers_managua");

            migrationBuilder.DropColumn(
                name: "entry_time",
                schema: "public",
                table: "ducat_registry_headers_managua");

            migrationBuilder.DropColumn(
                name: "transportista",
                schema: "public",
                table: "ducat_registry_headers_managua");

            migrationBuilder.RenameTable(
                name: "ducat_registry_headers_managua",
                schema: "public",
                newName: "ducat_registry_managua",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "zones_managua_id",
                schema: "public",
                table: "zones_managua",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "workflow_step_definition_id",
                schema: "public",
                table: "workflow_step_definitions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "warehouse_receipts_managua",
                newName: "record_entrance_managua_id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                newName: "record_entrance_managua_id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "unloading_details_managua",
                newName: "record_entrance_managua_id");

            migrationBuilder.RenameColumn(
                name: "rack_id",
                schema: "public",
                table: "stocks_managua",
                newName: "zone_managua_id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "public",
                table: "stocks_managua",
                newName: "warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_stocks_managua_rack_id",
                schema: "public",
                table: "stocks_managua",
                newName: "IX_stocks_managua_zone_managua_id");

            migrationBuilder.RenameColumn(
                name: "log_id",
                schema: "public",
                table: "step_execution_logs_managua",
                newName: "step_execution_logs_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "record_entrances_managua",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "medium",
                schema: "public",
                table: "reception_details_managua",
                newName: "medio");

            migrationBuilder.RenameColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "reception_details_managua",
                newName: "record_entrance_managua_id");

            migrationBuilder.RenameColumn(
                name: "entry_date_time",
                schema: "public",
                table: "reception_details_managua",
                newName: "gate_entrance_time");

            migrationBuilder.RenameColumn(
                name: "racks_managua_id",
                schema: "public",
                table: "racks_managua",
                newName: "racks_id");

            migrationBuilder.RenameColumn(
                name: "container_dimension",
                schema: "public",
                table: "manifest_cancellations_managua",
                newName: "ContainerDimension");

            migrationBuilder.RenameColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "manifest_cancellations_managua",
                newName: "record_entrance_managua_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "entrance_ducats_managua",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "ducat_registry_details_managua",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "package_count",
                schema: "public",
                table: "ducat_registry_details_managua",
                newName: "total_bultos");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "public",
                table: "discrepancies_managua",
                newName: "entrance_ducats_id");

            migrationBuilder.RenameIndex(
                name: "IX_discrepancies_managua_product_id",
                schema: "public",
                table: "discrepancies_managua",
                newName: "IX_discrepancies_managua_entrance_ducats_id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_id",
                schema: "public",
                table: "ducat_registry_managua",
                newName: "record_entrance_managua_id");

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
                .Annotation("Npgsql:Enum:public.os_status_enum", "pendding,in_progress,completed,canceled")
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
                .Annotation("Npgsql:Enum:public.warehouse_mga_status_enum", "in_tail,in_unloading,completed,abandoned")
                .Annotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<string>(
                name: "zone_name",
                schema: "public",
                table: "zones_managua",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "zones_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<decimal>(
                name: "heigth_metres",
                schema: "public",
                table: "zones_managua",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "zones_managua",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "length_metres",
                schema: "public",
                table: "zones_managua",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "max_weight_capacity_kg",
                schema: "public",
                table: "zones_managua",
                type: "numeric(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "total_colume_capacity_m3",
                schema: "public",
                table: "zones_managua",
                type: "numeric(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "width_metres",
                schema: "public",
                table: "zones_managua",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "workflow_step_definitions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            // --- FIX APLICADO AQUI ---
            // Se agrega DROP DEFAULT antes de la conversion de tipo y SET DEFAULT despues,
            // porque Postgres no puede castear automaticamente el DEFAULT entero (integer)
            // hacia el nuevo tipo warehouse_type_enum (error 42804).
            migrationBuilder.Sql("""
                ALTER TABLE public.warehouses
                ALTER COLUMN warehouse_type DROP DEFAULT;

                ALTER TABLE public.warehouses
                ALTER COLUMN warehouse_type
                TYPE warehouse_type_enum
                USING (
                    CASE warehouse_type
                        WHEN 1 THEN 'general'
                        WHEN 2 THEN 'fiscal'
                        WHEN 3 THEN 'galeron_techado'
                        WHEN 4 THEN 'patio_contenedores'
                        WHEN 5 THEN 'predio_abierto'
                        WHEN 6 THEN 'granel'
                    END
                )::warehouse_type_enum;

                ALTER TABLE public.warehouses
                ALTER COLUMN warehouse_type SET DEFAULT 'general'::warehouse_type_enum;
                """);
            // --- FIN DEL FIX ---
            // NOTA: los valores del enum warehouse_type_enum son snake_case en minusculas
            // (general, fiscal, galeron_techado, patio_contenedores, predio_abierto, granel),
            // segun la anotacion Npgsql:Enum:public.warehouse_type_enum definida mas arriba
            // en este mismo metodo Up(). Si el default numerico original no era 1 ("general"),
            // reemplaza 'general' arriba por el valor correcto del enum.

            migrationBuilder.AlterColumn<string>(
                name: "resa_number",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "receipt_number",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "customs_cif_value",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "customs_brokerage",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "zone_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "public",
                table: "warehouse_assignments_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "assigned_by_user_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "warehouse_assignments_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "warehouse_assignments_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "warehouse_chief_user_id",
                schema: "public",
                table: "unloading_details_managua",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "unloading_end_time",
                schema: "public",
                table: "unloading_details_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "unloading_details_managua_id",
                schema: "public",
                table: "unloading_details_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "unloading_details_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "unloading_details_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "prepared_pallets",
                schema: "public",
                table: "unloading_details_managua",
                type: "numeric(2,0)",
                precision: 2,
                scale: 0,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "warehouse_assignments_managua_id",
                schema: "public",
                table: "unloading_details_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "category_product_id",
                schema: "public",
                table: "stocks_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "stocks_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "current_bultos",
                schema: "public",
                table: "stocks_managua",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "current_weight_kg",
                schema: "public",
                table: "stocks_managua",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "stocks_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "entrance_ducats_managua_id",
                schema: "public",
                table: "stocks_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "racks_managua_id",
                schema: "public",
                table: "stocks_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "step_execution_logs_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "step_execution_logs_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "processed_by_user_id",
                schema: "public",
                table: "step_execution_logs_managua",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");


            migrationBuilder.Sql("""
                ALTER TABLE public.service_orders
                ALTER COLUMN status DROP DEFAULT;

                ALTER TABLE public.service_orders    
                ALTER COLUMN status
                TYPE os_status_enum
                USING (
                    CASE status
                        WHEN 1 THEN 'pendding'
                        WHEN 2 THEN 'in_progress'
                        WHEN 3 THEN 'completed'
                        WHEN 4 THEN 'canceled'
                    END
                )::os_status_enum;

                ALTER TABLE public.service_orders
                ALTER COLUMN status SET DEFAULT 'pendding'::os_status_enum;
            """);

          migrationBuilder.Sql("""
                ALTER TABLE public.record_entrances_managua
                ALTER COLUMN status DROP DEFAULT;

                ALTER TABLE public.record_entrances_managua
                ALTER COLUMN status
                TYPE warehouse_mga_status_enum
                USING (
                    CASE status
                        WHEN 'InTail' THEN 'in_tail'
                        WHEN 'InUnloading' THEN 'in_unloading'
                        WHEN 'Completed' THEN 'completed'
                        WHEN 'Abandoned' THEN 'abandoned'
                    END
                )::warehouse_mga_status_enum;

                ALTER TABLE public.record_entrances_managua
                ALTER COLUMN status SET DEFAULT 'in_tail'::warehouse_mga_status_enum;
            """);


            migrationBuilder.AlterColumn<int>(
                name: "current_step_id",
                schema: "public",
                table: "record_entrances_managua",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_at",
                schema: "public",
                table: "record_entrances_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_consolidated",
                schema: "public",
                table: "record_entrances_managua",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "service_order_id",
                schema: "public",
                table: "record_entrances_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "transportista",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "trailer_chassis",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "plate_number",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "driver_name",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "driver_license",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "country_of_origin",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "consignee",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "aduana",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "medio",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "reception_details_managua_id",
                schema: "public",
                table: "reception_details_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "reception_details_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "reception_details_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "cost_per_position",
                schema: "public",
                table: "racks_managua",
                type: "numeric(12,4)",
                precision: 12,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "racks_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<bool>(
                name: "is_available",
                schema: "public",
                table: "racks_managua",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<decimal>(
                name: "max_height_metres",
                schema: "public",
                table: "racks_managua",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "max_weight_kg",
                schema: "public",
                table: "racks_managua",
                type: "numeric(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "holiday_pay",
                schema: "public",
                table: "ordinary_payrolls",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "number_of_holidays",
                schema: "public",
                table: "ordinary_payrolls",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "warehouse_chief_signature",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "manifest_number",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "customs_officer_signature",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ContainerDimension",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<Guid>(
                name: "manifest_cancellation_id",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_type",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "service_orders_id",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ducat_number",
                schema: "public",
                table: "entrance_ducats_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "entrance_ducats_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<decimal>(
                name: "total_weight",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "destination_area_observation",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<Guid>(
                name: "category_product_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<Guid>(
                name: "entrance_ducat_managua_id",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "remitente",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "discrepancy_type",
                schema: "public",
                table: "discrepancies_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "public",
                table: "discrepancies_managua",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<bool>(
                name: "IsDamage",
                schema: "public",
                table: "discrepancies_managua",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "discrepancies_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "discrepancies_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ducat_registtry_id",
                schema: "public",
                table: "ducat_registry_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "ducat_registry_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "ducat_registry_managua",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "general_observations",
                schema: "public",
                table: "ducat_registry_managua",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_in_transit",
                schema: "public",
                table: "ducat_registry_managua",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "registered_by_user_id",
                schema: "public",
                table: "ducat_registry_managua",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse_receipts_managua",
                schema: "public",
                table: "warehouse_receipts_managua",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse_assignments_managua",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_unloading_details_managua",
                schema: "public",
                table: "unloading_details_managua",
                column: "unloading_details_managua_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reception_details_managua",
                schema: "public",
                table: "reception_details_managua",
                column: "reception_details_managua_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_manifest_cancellations_managua",
                schema: "public",
                table: "manifest_cancellations_managua",
                column: "manifest_cancellation_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ducat_registry_managua",
                schema: "public",
                table: "ducat_registry_managua",
                column: "ducat_registtry_id");

            migrationBuilder.CreateTable(
                name: "pending_deduction_balances",
                schema: "public",
                columns: table => new
                {
                    pending_deduction_balance_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    origin_payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount_owed = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    reason = table.Column<string>(type: "text", nullable: true),
                    is_recovered = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pending_deduction_balances", x => x.pending_deduction_balance_id);
                    table.ForeignKey(
                        name: "FK_pending_deduction_balances_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pending_deduction_balances_payrolls_origin_payroll_id",
                        column: x => x.origin_payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unloading_crew_assignments_managua",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    unloading_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    persona_count = table.Column<int>(type: "integer", nullable: false),
                    tercerizada = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_crew_assignments_managua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_unloading_crew_assignments_managua_unloading_details_managu~",
                        column: x => x.unloading_details_managua_id,
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
                    unloading_machinery_assignment_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "IX_zones_managua_warehouse_id",
                schema: "public",
                table: "zones_managua",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_receipts_managua_record_entrance_managua_id",
                schema: "public",
                table: "warehouse_receipts_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_record_entrance_managua_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_managua_zone_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "zone_id");

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
                name: "IX_reception_details_managua_record_entrance_managua_id",
                schema: "public",
                table: "reception_details_managua",
                column: "record_entrance_managua_id",
                unique: true);

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
                name: "ix_discrepancy_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "discrepancy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ducat_registry_managua_record_entrance_managua_id",
                schema: "public",
                table: "ducat_registry_managua",
                column: "record_entrance_managua_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pending_deduction_balance_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "pending_deduction_balance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pending_deduction_balances_collaborator_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_pending_deduction_balances_origin_payroll_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "origin_payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_crew_assignments_managua_unloading_details_managu~",
                schema: "public",
                table: "unloading_crew_assignments_managua",
                column: "unloading_details_managua_id");

            migrationBuilder.CreateIndex(
                name: "IX_UnloadingMachineryAssignmentsManagua_unloading_details_mana~",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                column: "unloading_details_managua_id");

            migrationBuilder.AddForeignKey(
                name: "FK_discrepancies_managua_entrance_ducats_managua_entrance_duca~",
                schema: "public",
                table: "discrepancies_managua",
                column: "entrance_ducats_id",
                principalSchema: "public",
                principalTable: "entrance_ducats_managua",
                principalColumn: "entrance_ducat_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_managua_category_products_category_p~",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "category_product_id",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_managua_ducat_registry_managua_recor~",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "ducat_registry_managua",
                principalColumn: "ducat_registtry_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_managua_entrance_ducats_managua_entr~",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "entrance_ducat_managua_id",
                principalSchema: "public",
                principalTable: "entrance_ducats_managua",
                principalColumn: "entrance_ducat_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_managua_record_entrances_managua_record_entr~",
                schema: "public",
                table: "ducat_registry_managua",
                column: "record_entrance_managua_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entrance_ducats_managua_record_entrances_managua_record_ent~",
                schema: "public",
                table: "entrance_ducats_managua",
                column: "record_entrance_managua_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_manifest_cancellations_managua_service_orders_service_order~",
                schema: "public",
                table: "manifest_cancellations_managua",
                column: "service_orders_id",
                principalSchema: "public",
                principalTable: "service_orders",
                principalColumn: "os_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_racks_managua_zones_managua_zone_id",
                schema: "public",
                table: "racks_managua",
                column: "zone_id",
                principalSchema: "public",
                principalTable: "zones_managua",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_details_managua_record_entrances_managua_record_e~",
                schema: "public",
                table: "reception_details_managua",
                column: "record_entrance_managua_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_managua_warehouses_warehouse_id",
                schema: "public",
                table: "record_entrances_managua",
                column: "warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_step_execution_logs_managua_record_entrances_managua_record~",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_step_execution_logs_managua_workflow_step_definitions_workf~",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "workflow_step_definition_id",
                principalSchema: "public",
                principalTable: "workflow_step_definitions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_managua_category_products_category_product_id",
                schema: "public",
                table: "stocks_managua",
                column: "category_product_id",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_managua_entrance_ducats_managua_entrance_ducats_mana~",
                schema: "public",
                table: "stocks_managua",
                column: "entrance_ducats_managua_id",
                principalSchema: "public",
                principalTable: "entrance_ducats_managua",
                principalColumn: "entrance_ducat_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_managua_racks_managua_racks_managua_id",
                schema: "public",
                table: "stocks_managua",
                column: "racks_managua_id",
                principalSchema: "public",
                principalTable: "racks_managua",
                principalColumn: "racks_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_managua_zones_managua_zone_managua_id",
                schema: "public",
                table: "stocks_managua",
                column: "zone_managua_id",
                principalSchema: "public",
                principalTable: "zones_managua",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_unloading_details_managua_warehouse_assignments_managua_war~",
                schema: "public",
                table: "unloading_details_managua",
                column: "warehouse_assignments_managua_id",
                principalSchema: "public",
                principalTable: "warehouse_assignments_managua",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_managua_racks_managua_rack_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "rack_id",
                principalSchema: "public",
                principalTable: "racks_managua",
                principalColumn: "racks_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_managua_record_entrances_managua_reco~",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "record_entrance_managua_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_managua_warehouses_warehouse_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_managua_zones_managua_zone_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "zone_id",
                principalSchema: "public",
                principalTable: "zones_managua",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discrepancies_managua_entrance_ducats_managua_entrance_duca~",
                schema: "public",
                table: "discrepancies_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_managua_category_products_category_p~",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_managua_ducat_registry_managua_recor~",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_managua_entrance_ducats_managua_entr~",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_managua_record_entrances_managua_record_entr~",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_entrance_ducats_managua_record_entrances_managua_record_ent~",
                schema: "public",
                table: "entrance_ducats_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_manifest_cancellations_managua_service_orders_service_order~",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_racks_managua_zones_managua_zone_id",
                schema: "public",
                table: "racks_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_reception_details_managua_record_entrances_managua_record_e~",
                schema: "public",
                table: "reception_details_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_managua_warehouses_warehouse_id",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_step_execution_logs_managua_record_entrances_managua_record~",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_step_execution_logs_managua_workflow_step_definitions_workf~",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_managua_category_products_category_product_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_managua_entrance_ducats_managua_entrance_ducats_mana~",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_managua_racks_managua_racks_managua_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_managua_zones_managua_zone_managua_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_unloading_details_managua_warehouse_assignments_managua_war~",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_managua_racks_managua_rack_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_managua_record_entrances_managua_reco~",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_managua_warehouses_warehouse_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_managua_zones_managua_zone_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropTable(
                name: "pending_deduction_balances",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unloading_crew_assignments_managua",
                schema: "public");

            migrationBuilder.DropTable(
                name: "UnloadingMachineryAssignmentsManagua",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_zones_managua_warehouse_id",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse_receipts_managua",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_receipts_managua_record_entrance_managua_id",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse_assignments_managua",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_managua_record_entrance_managua_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_managua_zone_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_unloading_details_managua",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropIndex(
                name: "IX_unloading_details_managua_record_entrance_managua_id",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropIndex(
                name: "IX_unloading_details_managua_warehouse_assignments_managua_id",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropIndex(
                name: "IX_stocks_managua_category_product_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropIndex(
                name: "IX_stocks_managua_entrance_ducats_managua_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropIndex(
                name: "IX_stocks_managua_racks_managua_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reception_details_managua",
                schema: "public",
                table: "reception_details_managua");

            migrationBuilder.DropIndex(
                name: "IX_reception_details_managua_record_entrance_managua_id",
                schema: "public",
                table: "reception_details_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_manifest_cancellations_managua",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropIndex(
                name: "IX_manifest_cancellations_managua_record_entrance_managua_id",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropIndex(
                name: "IX_manifest_cancellations_managua_service_orders_id",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropIndex(
                name: "IX_ducat_registry_details_managua_category_product_id",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropIndex(
                name: "IX_ducat_registry_details_managua_entrance_ducat_managua_id",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropIndex(
                name: "ix_discrepancy_id",
                schema: "public",
                table: "discrepancies_managua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ducat_registry_managua",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.DropIndex(
                name: "IX_ducat_registry_managua_record_entrance_managua_id",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.DropColumn(
                name: "heigth_metres",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropColumn(
                name: "length_metres",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropColumn(
                name: "max_weight_capacity_kg",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropColumn(
                name: "total_colume_capacity_m3",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropColumn(
                name: "width_metres",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropColumn(
                name: "assigned_by_user_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropColumn(
                name: "unloading_details_managua_id",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "prepared_pallets",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "warehouse_assignments_managua_id",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "category_product_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropColumn(
                name: "current_bultos",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropColumn(
                name: "current_weight_kg",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropColumn(
                name: "entrance_ducats_managua_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropColumn(
                name: "racks_managua_id",
                schema: "public",
                table: "stocks_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropColumn(
                name: "processed_by_user_id",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.DropColumn(
                name: "is_consolidated",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropColumn(
                name: "service_order_id",
                schema: "public",
                table: "record_entrances_managua");

            migrationBuilder.DropColumn(
                name: "reception_details_managua_id",
                schema: "public",
                table: "reception_details_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "reception_details_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "reception_details_managua");

            migrationBuilder.DropColumn(
                name: "is_available",
                schema: "public",
                table: "racks_managua");

            migrationBuilder.DropColumn(
                name: "max_height_metres",
                schema: "public",
                table: "racks_managua");

            migrationBuilder.DropColumn(
                name: "max_weight_kg",
                schema: "public",
                table: "racks_managua");

            migrationBuilder.DropColumn(
                name: "holiday_pay",
                schema: "public",
                table: "ordinary_payrolls");

            migrationBuilder.DropColumn(
                name: "number_of_holidays",
                schema: "public",
                table: "ordinary_payrolls");

            migrationBuilder.DropColumn(
                name: "manifest_cancellation_id",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropColumn(
                name: "personal_type",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropColumn(
                name: "service_orders_id",
                schema: "public",
                table: "manifest_cancellations_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "entrance_ducats_managua");

            migrationBuilder.DropColumn(
                name: "category_product_id",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropColumn(
                name: "entrance_ducat_managua_id",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropColumn(
                name: "remitente",
                schema: "public",
                table: "ducat_registry_details_managua");

            migrationBuilder.DropColumn(
                name: "IsDamage",
                schema: "public",
                table: "discrepancies_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "discrepancies_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "discrepancies_managua");

            migrationBuilder.DropColumn(
                name: "ducat_registtry_id",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.DropColumn(
                name: "general_observations",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.DropColumn(
                name: "is_in_transit",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.DropColumn(
                name: "registered_by_user_id",
                schema: "public",
                table: "ducat_registry_managua");

            migrationBuilder.RenameTable(
                name: "ducat_registry_managua",
                schema: "public",
                newName: "ducat_registry_headers_managua",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "zones_managua",
                newName: "zones_managua_id");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "workflow_step_definitions",
                newName: "workflow_step_definition_id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_managua_id",
                schema: "public",
                table: "warehouse_receipts_managua",
                newName: "record_entrance_id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_managua_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                newName: "record_entrance_id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_managua_id",
                schema: "public",
                table: "unloading_details_managua",
                newName: "record_entrance_id");

            migrationBuilder.RenameColumn(
                name: "zone_managua_id",
                schema: "public",
                table: "stocks_managua",
                newName: "rack_id");

            migrationBuilder.RenameColumn(
                name: "warehouse_id",
                schema: "public",
                table: "stocks_managua",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_stocks_managua_zone_managua_id",
                schema: "public",
                table: "stocks_managua",
                newName: "IX_stocks_managua_rack_id");

            migrationBuilder.RenameColumn(
                name: "step_execution_logs_id",
                schema: "public",
                table: "step_execution_logs_managua",
                newName: "log_id");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "record_entrances_managua",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "record_entrance_managua_id",
                schema: "public",
                table: "reception_details_managua",
                newName: "record_entrance_id");

            migrationBuilder.RenameColumn(
                name: "medio",
                schema: "public",
                table: "reception_details_managua",
                newName: "medium");

            migrationBuilder.RenameColumn(
                name: "gate_entrance_time",
                schema: "public",
                table: "reception_details_managua",
                newName: "entry_date_time");

            migrationBuilder.RenameColumn(
                name: "racks_id",
                schema: "public",
                table: "racks_managua",
                newName: "racks_managua_id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_managua_id",
                schema: "public",
                table: "manifest_cancellations_managua",
                newName: "record_entrance_id");

            migrationBuilder.RenameColumn(
                name: "ContainerDimension",
                schema: "public",
                table: "manifest_cancellations_managua",
                newName: "container_dimension");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "entrance_ducats_managua",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "ducat_registry_details_managua",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "total_bultos",
                schema: "public",
                table: "ducat_registry_details_managua",
                newName: "package_count");

            migrationBuilder.RenameColumn(
                name: "entrance_ducats_id",
                schema: "public",
                table: "discrepancies_managua",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_discrepancies_managua_entrance_ducats_id",
                schema: "public",
                table: "discrepancies_managua",
                newName: "IX_discrepancies_managua_product_id");

            migrationBuilder.RenameColumn(
                name: "record_entrance_managua_id",
                schema: "public",
                table: "ducat_registry_headers_managua",
                newName: "record_entrance_id");

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
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:public.catalog_type_enum", "branches,work_areas,job_positions,document_types,banks,exchange_rates,departaments")
                .OldAnnotation("Npgsql:Enum:public.collaborator_status_enum", "active,inactive,vacation,subsidy,suspended,terminated,testing_process")
                .OldAnnotation("Npgsql:Enum:public.currency_enum", "nio,usd")
                .OldAnnotation("Npgsql:Enum:public.deduction_payment_status", "paid,pending")
                .OldAnnotation("Npgsql:Enum:public.deduction_status_enum", "progress,completed,pending,canceled")
                .OldAnnotation("Npgsql:Enum:public.deduction_type_enum", "loans,advance_christmas_bonus,late_arrivals,salary_advance,sanction,purisima,other_deductions")
                .OldAnnotation("Npgsql:Enum:public.gender_type_enum", "man,women")
                .OldAnnotation("Npgsql:Enum:public.identification_type_enum", "cedula,pasaporte,cedula_residencia")
                .OldAnnotation("Npgsql:Enum:public.marital_status_enum", "none,single,married,divorced,widowed,domestic_partner,separated,other")
                .OldAnnotation("Npgsql:Enum:public.os_status_enum", "pendding,in_progress,completed,canceled")
                .OldAnnotation("Npgsql:Enum:public.payroll_period_enum", "first_period,second_period")
                .OldAnnotation("Npgsql:Enum:public.payroll_status_enum", "progress,closed,cancelled,completed")
                .OldAnnotation("Npgsql:Enum:public.payroll_type_enum", "none,ordinary,provided,professional_services")
                .OldAnnotation("Npgsql:Enum:public.permission_type_enum", "read,create,update,delete")
                .OldAnnotation("Npgsql:Enum:public.permit_application_status_enum", "pending,approved,rejected,cancelled")
                .OldAnnotation("Npgsql:Enum:public.permit_application_type_enum", "vacation,medical_appointment,compensatory_time,paid_leave,unpaid_leave,special_leave,donated_vacations,vacation_pay")
                .OldAnnotation("Npgsql:Enum:public.role_type_enum", "administrator,supervisor,manager,operator")
                .OldAnnotation("Npgsql:Enum:public.salary_type_enum", "fixed,variable,professional_services")
                .OldAnnotation("Npgsql:Enum:public.source_deduction_payment_enum", "payroll,cash")
                .OldAnnotation("Npgsql:Enum:public.tax_type_enum", "inss,inss_patronal,exchange_rate,inatec,inss_patronal2")
                .OldAnnotation("Npgsql:Enum:public.user_status_enum", "active,inactive,locked")
                .OldAnnotation("Npgsql:Enum:public.user_type_enum", "standard_user,employee_self_service")
                .OldAnnotation("Npgsql:Enum:public.warehouse_mga_status_enum", "in_tail,in_unloading,completed,abandoned")
                .OldAnnotation("Npgsql:Enum:public.warehouse_type_enum", "general,fiscal,galeron_techado,patio_contenedores,predio_abierto,granel")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<string>(
                name: "zone_name",
                schema: "public",
                table: "zones_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "zones_managua",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "workflow_step_definitions",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "warehouse_type_enum");

            migrationBuilder.AlterColumn<string>(
                name: "resa_number",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "receipt_number",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "customs_cif_value",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "customs_brokerage",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<Guid>(
                name: "zone_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "warehouse_chief_user_id",
                schema: "public",
                table: "unloading_details_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<DateTime>(
                name: "unloading_end_time",
                schema: "public",
                table: "unloading_details_managua",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<decimal>(
                name: "prepared_pallets_per_hour",
                schema: "public",
                table: "unloading_details_managua",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "quantity",
                schema: "public",
                table: "stocks_managua",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "public",
                table: "step_execution_logs_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "public",
                table: "service_orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "os_status_enum");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "public",
                table: "record_entrances_managua",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "warehouse_mga_status_enum");

            migrationBuilder.AlterColumn<int>(
                name: "current_step_id",
                schema: "public",
                table: "record_entrances_managua",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_at",
                schema: "public",
                table: "record_entrances_managua",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestCancellationRecordEntranceManaguaId",
                schema: "public",
                table: "record_entrances_managua",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnloadingDetailsRecordEntranceManaguaId",
                schema: "public",
                table: "record_entrances_managua",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseReceiptRecordEntranceManaguaId",
                schema: "public",
                table: "record_entrances_managua",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "movement_number",
                schema: "public",
                table: "record_entrances_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "transportista",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "trailer_chassis",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "plate_number",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "driver_name",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "driver_license",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "country_of_origin",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "consignee",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "aduana",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "medium",
                schema: "public",
                table: "reception_details_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "cost_per_position",
                schema: "public",
                table: "racks_managua",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,4)",
                oldPrecision: 12,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "racks_managua",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "is_occupied",
                schema: "public",
                table: "racks_managua",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "warehouse_chief_signature",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "manifest_number",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "customs_officer_signature",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "container_dimension",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "personnel_type",
                schema: "public",
                table: "manifest_cancellations_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ducat_number",
                schema: "public",
                table: "entrance_ducats_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "total_weight",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "destination_area_observation",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "ducat_number",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sender_name",
                schema: "public",
                table: "ducat_registry_details_managua",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "discrepancy_type",
                schema: "public",
                table: "discrepancies_managua",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "public",
                table: "discrepancies_managua",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "aduana",
                schema: "public",
                table: "ducat_registry_headers_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "consignee",
                schema: "public",
                table: "ducat_registry_headers_managua",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "entry_time",
                schema: "public",
                table: "ducat_registry_headers_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "transportista",
                schema: "public",
                table: "ducat_registry_headers_managua",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse_receipts_managua",
                schema: "public",
                table: "warehouse_receipts_managua",
                column: "record_entrance_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse_assignments_managua",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "record_entrance_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_unloading_details_managua",
                schema: "public",
                table: "unloading_details_managua",
                column: "record_entrance_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reception_details_managua",
                schema: "public",
                table: "reception_details_managua",
                column: "record_entrance_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_manifest_cancellations_managua",
                schema: "public",
                table: "manifest_cancellations_managua",
                column: "record_entrance_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ducat_registry_headers_managua",
                schema: "public",
                table: "ducat_registry_headers_managua",
                column: "record_entrance_id");

            migrationBuilder.CreateIndex(
                name: "IX_zones_managua_warehouse_id_code",
                schema: "public",
                table: "zones_managua",
                columns: new[] { "warehouse_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stocks_managua_product_id",
                schema: "public",
                table: "stocks_managua",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_ManifestCancellationRecordEntrance~",
                schema: "public",
                table: "record_entrances_managua",
                column: "ManifestCancellationRecordEntranceManaguaId");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_movement_number",
                schema: "public",
                table: "record_entrances_managua",
                column: "movement_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_UnloadingDetailsRecordEntranceMana~",
                schema: "public",
                table: "record_entrances_managua",
                column: "UnloadingDetailsRecordEntranceManaguaId");

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_managua_WarehouseReceiptRecordEntranceMana~",
                schema: "public",
                table: "record_entrances_managua",
                column: "WarehouseReceiptRecordEntranceManaguaId");

            migrationBuilder.AddForeignKey(
                name: "FK_discrepancies_managua_products_product_id",
                schema: "public",
                table: "discrepancies_managua",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_managua_ducat_registry_headers_manag~",
                schema: "public",
                table: "ducat_registry_details_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "ducat_registry_headers_managua",
                principalColumn: "record_entrance_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_headers_managua_record_entrances_managua_rec~",
                schema: "public",
                table: "ducat_registry_headers_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entrance_ducats_managua_record_entrances_managua_record_ent~",
                schema: "public",
                table: "entrance_ducats_managua",
                column: "record_entrance_managua_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_racks_managua_zones_managua_zone_id",
                schema: "public",
                table: "racks_managua",
                column: "zone_id",
                principalSchema: "public",
                principalTable: "zones_managua",
                principalColumn: "zones_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_details_managua_record_entrances_managua_record_e~",
                schema: "public",
                table: "reception_details_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_managua_manifest_cancellations_managua_Man~",
                schema: "public",
                table: "record_entrances_managua",
                column: "ManifestCancellationRecordEntranceManaguaId",
                principalSchema: "public",
                principalTable: "manifest_cancellations_managua",
                principalColumn: "record_entrance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_managua_unloading_details_managua_Unloadin~",
                schema: "public",
                table: "record_entrances_managua",
                column: "UnloadingDetailsRecordEntranceManaguaId",
                principalSchema: "public",
                principalTable: "unloading_details_managua",
                principalColumn: "record_entrance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_managua_warehouse_receipts_managua_Warehou~",
                schema: "public",
                table: "record_entrances_managua",
                column: "WarehouseReceiptRecordEntranceManaguaId",
                principalSchema: "public",
                principalTable: "warehouse_receipts_managua",
                principalColumn: "record_entrance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_managua_warehouses_warehouse_id",
                schema: "public",
                table: "record_entrances_managua",
                column: "warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_step_execution_logs_managua_record_entrances_managua_record~",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_step_execution_logs_managua_workflow_step_definitions_workf~",
                schema: "public",
                table: "step_execution_logs_managua",
                column: "workflow_step_definition_id",
                principalSchema: "public",
                principalTable: "workflow_step_definitions",
                principalColumn: "workflow_step_definition_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_managua_products_product_id",
                schema: "public",
                table: "stocks_managua",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_managua_racks_managua_rack_id",
                schema: "public",
                table: "stocks_managua",
                column: "rack_id",
                principalSchema: "public",
                principalTable: "racks_managua",
                principalColumn: "racks_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_managua_racks_managua_rack_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "rack_id",
                principalSchema: "public",
                principalTable: "racks_managua",
                principalColumn: "racks_managua_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_managua_record_entrances_managua_reco~",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "record_entrance_id",
                principalSchema: "public",
                principalTable: "record_entrances_managua",
                principalColumn: "record_entrance_managua_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_managua_warehouses_warehouse_id",
                schema: "public",
                table: "warehouse_assignments_managua",
                column: "warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}