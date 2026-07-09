using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ConfigsWarehouseMNG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE public.discrepancies_managua DROP CONSTRAINT IF EXISTS ""FK_discrepancies_managua_products_product_id"";");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_details_managua DROP CONSTRAINT IF EXISTS ""FK_ducat_registry_details_managua_ducat_registry_headers_manag~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_headers_managua DROP CONSTRAINT IF EXISTS ""FK_ducat_registry_headers_managua_record_entrances_managua_rec~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.entrance_ducats_managua DROP CONSTRAINT IF EXISTS ""FK_entrance_ducats_managua_record_entrances_managua_record_ent~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.racks_managua DROP CONSTRAINT IF EXISTS ""FK_racks_managua_zones_managua_zone_id"";");

            migrationBuilder.Sql(@"ALTER TABLE public.reception_details_managua DROP CONSTRAINT IF EXISTS ""FK_reception_details_managua_record_entrances_managua_record_e~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua DROP CONSTRAINT IF EXISTS ""FK_record_entrances_managua_manifest_cancellations_managua_Man~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua DROP CONSTRAINT IF EXISTS ""FK_record_entrances_managua_unloading_details_managua_Unloadin~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua DROP CONSTRAINT IF EXISTS ""FK_record_entrances_managua_warehouse_receipts_managua_Warehou~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua DROP CONSTRAINT IF EXISTS ""FK_record_entrances_managua_warehouses_warehouse_id"";");

            migrationBuilder.Sql(@"ALTER TABLE public.step_execution_logs_managua DROP CONSTRAINT IF EXISTS ""FK_step_execution_logs_managua_record_entrances_managua_record~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.step_execution_logs_managua DROP CONSTRAINT IF EXISTS ""FK_step_execution_logs_managua_workflow_step_definitions_workf~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua DROP CONSTRAINT IF EXISTS ""FK_stocks_managua_products_product_id"";");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua DROP CONSTRAINT IF EXISTS ""FK_stocks_managua_racks_managua_rack_id"";");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_assignments_managua DROP CONSTRAINT IF EXISTS ""FK_warehouse_assignments_managua_racks_managua_rack_id"";");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_assignments_managua DROP CONSTRAINT IF EXISTS ""FK_warehouse_assignments_managua_record_entrances_managua_reco~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_assignments_managua DROP CONSTRAINT IF EXISTS ""FK_warehouse_assignments_managua_warehouses_warehouse_id"";");

            migrationBuilder.Sql(@"DROP INDEX IF EXISTS public.""IX_zones_managua_warehouse_id_code"";");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_receipts_managua DROP CONSTRAINT IF EXISTS ""PK_warehouse_receipts_managua"";");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_assignments_managua DROP CONSTRAINT IF EXISTS ""PK_warehouse_assignments_managua"";");

            migrationBuilder.Sql(@"ALTER TABLE public.unloading_details_managua DROP CONSTRAINT IF EXISTS ""PK_unloading_details_managua"";");

            migrationBuilder.Sql(@"DROP INDEX IF EXISTS public.""IX_stocks_managua_product_id"";");

            migrationBuilder.Sql(@"DROP INDEX IF EXISTS public.""IX_record_entrances_managua_ManifestCancellationRecordEntrance~"";");

            migrationBuilder.Sql(@"DROP INDEX IF EXISTS public.""IX_record_entrances_managua_movement_number"";");

            migrationBuilder.Sql(@"DROP INDEX IF EXISTS public.""IX_record_entrances_managua_UnloadingDetailsRecordEntranceMana~"";");

            migrationBuilder.Sql(@"DROP INDEX IF EXISTS public.""IX_record_entrances_managua_WarehouseReceiptRecordEntranceMana~"";");

            migrationBuilder.Sql(@"ALTER TABLE public.reception_details_managua DROP CONSTRAINT IF EXISTS ""PK_reception_details_managua"";");

            migrationBuilder.Sql(@"ALTER TABLE public.manifest_cancellations_managua DROP CONSTRAINT IF EXISTS ""PK_manifest_cancellations_managua"";");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_headers_managua DROP CONSTRAINT IF EXISTS ""PK_ducat_registry_headers_managua"";");

            migrationBuilder.Sql(@"ALTER TABLE public.unloading_details_managua DROP COLUMN IF EXISTS prepared_pallets_per_hour;");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua DROP COLUMN IF EXISTS quantity;");

            migrationBuilder.Sql(@"ALTER TABLE public.step_execution_logs_managua DROP COLUMN IF EXISTS user_id;");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua DROP COLUMN IF EXISTS ""ManifestCancellationRecordEntranceManaguaId"";");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua DROP COLUMN IF EXISTS ""UnloadingDetailsRecordEntranceManaguaId"";");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua DROP COLUMN IF EXISTS ""WarehouseReceiptRecordEntranceManaguaId"";");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua DROP COLUMN IF EXISTS movement_number;");

            migrationBuilder.Sql(@"ALTER TABLE public.racks_managua DROP COLUMN IF EXISTS is_occupied;");

            migrationBuilder.Sql(@"ALTER TABLE public.manifest_cancellations_managua DROP COLUMN IF EXISTS personnel_type;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_details_managua DROP COLUMN IF EXISTS ducat_number;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_details_managua DROP COLUMN IF EXISTS sender_name;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_headers_managua DROP COLUMN IF EXISTS aduana;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_headers_managua DROP COLUMN IF EXISTS consignee;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_headers_managua DROP COLUMN IF EXISTS entry_time;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_headers_managua DROP COLUMN IF EXISTS transportista;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.tables
                        WHERE table_schema = 'public' AND table_name = 'ducat_registry_headers_managua'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.tables
                        WHERE table_schema = 'public' AND table_name = 'ducat_registry_managua'
                    ) THEN
                        ALTER TABLE public.ducat_registry_headers_managua RENAME TO ducat_registry_managua;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'zones_managua' AND column_name = 'zones_managua_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'zones_managua' AND column_name = 'id'
                    ) THEN
                        ALTER TABLE public.zones_managua RENAME COLUMN zones_managua_id TO id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'workflow_step_definitions' AND column_name = 'workflow_step_definition_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'workflow_step_definitions' AND column_name = 'id'
                    ) THEN
                        ALTER TABLE public.workflow_step_definitions RENAME COLUMN workflow_step_definition_id TO id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'warehouse_receipts_managua' AND column_name = 'record_entrance_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'warehouse_receipts_managua' AND column_name = 'record_entrance_managua_id'
                    ) THEN
                        ALTER TABLE public.warehouse_receipts_managua RENAME COLUMN record_entrance_id TO record_entrance_managua_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'warehouse_assignments_managua' AND column_name = 'record_entrance_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'warehouse_assignments_managua' AND column_name = 'record_entrance_managua_id'
                    ) THEN
                        ALTER TABLE public.warehouse_assignments_managua RENAME COLUMN record_entrance_id TO record_entrance_managua_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'unloading_details_managua' AND column_name = 'unloading_start_time'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'unloading_details_managua' AND column_name = 'UnloadingStartTime'
                    ) THEN
                        ALTER TABLE public.unloading_details_managua RENAME COLUMN unloading_start_time TO ""UnloadingStartTime"";
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'unloading_details_managua' AND column_name = 'record_entrance_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'unloading_details_managua' AND column_name = 'record_entrance_managua_id'
                    ) THEN
                        ALTER TABLE public.unloading_details_managua RENAME COLUMN record_entrance_id TO record_entrance_managua_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'stocks_managua' AND column_name = 'rack_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'stocks_managua' AND column_name = 'zone_managua_id'
                    ) THEN
                        ALTER TABLE public.stocks_managua RENAME COLUMN rack_id TO zone_managua_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'stocks_managua' AND column_name = 'product_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'stocks_managua' AND column_name = 'warehouse_id'
                    ) THEN
                        ALTER TABLE public.stocks_managua RENAME COLUMN product_id TO warehouse_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM pg_class c
                        JOIN pg_namespace n ON n.oid = c.relnamespace
                        WHERE n.nspname = 'public'
                          AND c.relkind = 'i'
                          AND c.relname = 'IX_stocks_managua_rack_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM pg_class c
                        JOIN pg_namespace n ON n.oid = c.relnamespace
                        WHERE n.nspname = 'public'
                          AND c.relkind = 'i'
                          AND c.relname = 'IX_stocks_managua_zone_managua_id'
                    ) THEN
                        ALTER INDEX public.""IX_stocks_managua_rack_id"" RENAME TO ""IX_stocks_managua_zone_managua_id"";
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'step_execution_logs_managua' AND column_name = 'log_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'step_execution_logs_managua' AND column_name = 'step_execution_logs_id'
                    ) THEN
                        ALTER TABLE public.step_execution_logs_managua RENAME COLUMN log_id TO step_execution_logs_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'record_entrances_managua' AND column_name = 'DeletedAt'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'record_entrances_managua' AND column_name = 'deleted_at'
                    ) THEN
                        ALTER TABLE public.record_entrances_managua RENAME COLUMN ""DeletedAt"" TO deleted_at;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'reception_details_managua' AND column_name = 'medium'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'reception_details_managua' AND column_name = 'medio'
                    ) THEN
                        ALTER TABLE public.reception_details_managua RENAME COLUMN medium TO medio;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'reception_details_managua' AND column_name = 'record_entrance_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'reception_details_managua' AND column_name = 'record_entrance_managua_id'
                    ) THEN
                        ALTER TABLE public.reception_details_managua RENAME COLUMN record_entrance_id TO record_entrance_managua_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'reception_details_managua' AND column_name = 'entry_date_time'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'reception_details_managua' AND column_name = 'gate_entrance_time'
                    ) THEN
                        ALTER TABLE public.reception_details_managua RENAME COLUMN entry_date_time TO gate_entrance_time;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'racks_managua' AND column_name = 'racks_managua_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'racks_managua' AND column_name = 'racks_id'
                    ) THEN
                        ALTER TABLE public.racks_managua RENAME COLUMN racks_managua_id TO racks_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'manifest_cancellations_managua' AND column_name = 'container_dimension'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'manifest_cancellations_managua' AND column_name = 'ContainerDimension'
                    ) THEN
                        ALTER TABLE public.manifest_cancellations_managua RENAME COLUMN container_dimension TO ""ContainerDimension"";
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'manifest_cancellations_managua' AND column_name = 'record_entrance_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'manifest_cancellations_managua' AND column_name = 'record_entrance_managua_id'
                    ) THEN
                        ALTER TABLE public.manifest_cancellations_managua RENAME COLUMN record_entrance_id TO record_entrance_managua_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'entrance_ducats_managua' AND column_name = 'DeletedAt'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'entrance_ducats_managua' AND column_name = 'deleted_at'
                    ) THEN
                        ALTER TABLE public.entrance_ducats_managua RENAME COLUMN ""DeletedAt"" TO deleted_at;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'ducat_registry_details_managua' AND column_name = 'DeletedAt'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'ducat_registry_details_managua' AND column_name = 'deleted_at'
                    ) THEN
                        ALTER TABLE public.ducat_registry_details_managua RENAME COLUMN ""DeletedAt"" TO deleted_at;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'ducat_registry_details_managua' AND column_name = 'package_count'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'ducat_registry_details_managua' AND column_name = 'total_bultos'
                    ) THEN
                        ALTER TABLE public.ducat_registry_details_managua RENAME COLUMN package_count TO total_bultos;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'discrepancies_managua' AND column_name = 'product_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'discrepancies_managua' AND column_name = 'entrance_ducats_id'
                    ) THEN
                        ALTER TABLE public.discrepancies_managua RENAME COLUMN product_id TO entrance_ducats_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM pg_class c
                        JOIN pg_namespace n ON n.oid = c.relnamespace
                        WHERE n.nspname = 'public'
                          AND c.relkind = 'i'
                          AND c.relname = 'IX_discrepancies_managua_product_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM pg_class c
                        JOIN pg_namespace n ON n.oid = c.relnamespace
                        WHERE n.nspname = 'public'
                          AND c.relkind = 'i'
                          AND c.relname = 'IX_discrepancies_managua_entrance_ducats_id'
                    ) THEN
                        ALTER INDEX public.""IX_discrepancies_managua_product_id"" RENAME TO ""IX_discrepancies_managua_entrance_ducats_id"";
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'ducat_registry_managua' AND column_name = 'record_entrance_id'
                    ) AND NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public' AND table_name = 'ducat_registry_managua' AND column_name = 'record_entrance_managua_id'
                    ) THEN
                        ALTER TABLE public.ducat_registry_managua RENAME COLUMN record_entrance_id TO record_entrance_managua_id;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                        AND table_name = 'zones_managua'
                        AND column_name = 'zone_name'
                    ) THEN
                        ALTER TABLE public.zones_managua
                            ALTER COLUMN zone_name TYPE character varying(150)
                            USING zone_name::character varying;
                        ALTER TABLE public.zones_managua
                            ALTER COLUMN zone_name SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                        AND table_name = 'zones_managua'
                        AND column_name = 'code'
                    ) THEN
                        ALTER TABLE public.zones_managua
                            ALTER COLUMN code TYPE character varying(50)
                            USING code::character varying;
                        ALTER TABLE public.zones_managua
                            ALTER COLUMN code SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.zones_managua ADD COLUMN IF NOT EXISTS heigth_metres numeric(10,2) NOT NULL DEFAULT 0;");
            
            migrationBuilder.Sql(@"ALTER TABLE public.zones_managua ADD COLUMN IF NOT EXISTS is_active boolean NOT NULL DEFAULT false;");            

            migrationBuilder.Sql(@"ALTER TABLE public.zones_managua ADD COLUMN IF NOT EXISTS length_metres numeric(10,2) NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"ALTER TABLE public.zones_managua ADD COLUMN IF NOT EXISTS max_weight_capacity_kg numeric(14,2) NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"ALTER TABLE public.zones_managua ADD COLUMN IF NOT EXISTS total_colume_capacity_m3 numeric(12,3) NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"ALTER TABLE public.zones_managua ADD COLUMN IF NOT EXISTS width_metres numeric(10,2) NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                        AND table_name = 'workflow_step_definitions'
                        AND column_name = 'code'
                    ) THEN
                        ALTER TABLE public.workflow_step_definitions
                            ALTER COLUMN code TYPE character varying(50)
                            USING code::character varying;
                        ALTER TABLE public.workflow_step_definitions
                            ALTER COLUMN code SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                        AND table_name = 'warehouse_receipts_managua'
                        AND column_name = 'resa_number'
                    ) THEN
                        ALTER TABLE public.warehouse_receipts_managua
                            ALTER COLUMN resa_number TYPE character varying(100)
                            USING resa_number::character varying;
                        ALTER TABLE public.warehouse_receipts_managua
                            ALTER COLUMN resa_number SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                        AND table_name = 'warehouse_receipts_managua'
                        AND column_name = 'receipt_number'
                    ) THEN
                        ALTER TABLE public.warehouse_receipts_managua
                            ALTER COLUMN receipt_number TYPE character varying(100)
                            USING receipt_number::character varying;
                        ALTER TABLE public.warehouse_receipts_managua
                            ALTER COLUMN receipt_number SET NOT NULL;
                    END IF;
                END $$;");
            
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                        AND table_name = 'warehouse_receipts_managua'
                        AND column_name = 'customs_cif_value'
                    ) THEN
                        ALTER TABLE public.warehouse_receipts_managua
                            ALTER COLUMN customs_cif_value TYPE numeric(18,4)
                            USING customs_cif_value::numeric;
                        ALTER TABLE public.warehouse_receipts_managua
                            ALTER COLUMN customs_cif_value SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                        AND table_name = 'warehouse_receipts_managua'
                        AND column_name = 'customs_brokerage'
                    ) THEN
                        ALTER TABLE public.warehouse_receipts_managua
                            ALTER COLUMN customs_brokerage TYPE character varying(150)
                            USING customs_brokerage::character varying;
                        ALTER TABLE public.warehouse_receipts_managua
                            ALTER COLUMN customs_brokerage SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_receipts_managua ADD COLUMN IF NOT EXISTS id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_receipts_managua ADD COLUMN IF NOT EXISTS ""DeletedAt"" timestamp with time zone NULL;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'warehouse_assignments_managua'
                          AND column_name = 'zone_id'
                    ) THEN
                        ALTER TABLE public.warehouse_assignments_managua ALTER COLUMN zone_id TYPE uuid USING zone_id::uuid;
                        ALTER TABLE public.warehouse_assignments_managua ALTER COLUMN zone_id SET DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;
                        UPDATE public.warehouse_assignments_managua SET zone_id = '00000000-0000-0000-0000-000000000000'::uuid WHERE zone_id IS NULL;
                        ALTER TABLE public.warehouse_assignments_managua ALTER COLUMN zone_id SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_assignments_managua ADD COLUMN IF NOT EXISTS id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_assignments_managua ADD COLUMN IF NOT EXISTS ""DeletedAt"" timestamp with time zone NULL;");

            migrationBuilder.Sql(@"ALTER TABLE public.warehouse_assignments_managua ADD COLUMN IF NOT EXISTS assigned_by_user_id character varying(450) NOT NULL DEFAULT '';");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'unloading_details_managua'
                          AND column_name = 'warehouse_chief_user_id'
                    ) THEN
                        ALTER TABLE public.unloading_details_managua ALTER COLUMN warehouse_chief_user_id TYPE character varying(450) USING warehouse_chief_user_id::character varying;
                        ALTER TABLE public.unloading_details_managua ALTER COLUMN warehouse_chief_user_id SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'unloading_details_managua'
                          AND column_name = 'unloading_end_time'
                    ) THEN
                        ALTER TABLE public.unloading_details_managua ALTER COLUMN unloading_end_time TYPE timestamp with time zone USING unloading_end_time::timestamp with time zone;
                        ALTER TABLE public.unloading_details_managua ALTER COLUMN unloading_end_time SET DEFAULT '0001-01-01 00:00:00+00';
                        UPDATE public.unloading_details_managua SET unloading_end_time = '0001-01-01 00:00:00+00' WHERE unloading_end_time IS NULL;
                        ALTER TABLE public.unloading_details_managua ALTER COLUMN unloading_end_time SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.unloading_details_managua ADD COLUMN IF NOT EXISTS unloading_details_managua_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.unloading_details_managua ADD COLUMN IF NOT EXISTS ""DeletedAt"" timestamp with time zone NULL;");

            migrationBuilder.Sql(@"ALTER TABLE public.unloading_details_managua ADD COLUMN IF NOT EXISTS ""PreparedPallets"" numeric(2) NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"ALTER TABLE public.unloading_details_managua ADD COLUMN IF NOT EXISTS warehouse_assignments_managua_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua ADD COLUMN IF NOT EXISTS category_product_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua ADD COLUMN IF NOT EXISTS created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP;");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua ADD COLUMN IF NOT EXISTS current_bultos integer NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua ADD COLUMN IF NOT EXISTS current_weight_kg numeric(18,4) NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua ADD COLUMN IF NOT EXISTS deleted_at timestamp with time zone NULL;");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua ADD COLUMN IF NOT EXISTS entrance_ducats_managua_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.stocks_managua ADD COLUMN IF NOT EXISTS racks_managua_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.step_execution_logs_managua ADD COLUMN IF NOT EXISTS ""DeletedAt"" timestamp with time zone NULL;");

            migrationBuilder.Sql(@"ALTER TABLE public.step_execution_logs_managua ADD COLUMN IF NOT EXISTS processed_by_user_id character varying(450) NOT NULL DEFAULT '';");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'record_entrances_managua'
                          AND column_name = 'status'
                    ) THEN
                        ALTER TABLE public.record_entrances_managua ALTER COLUMN status TYPE integer USING status::integer;
                        ALTER TABLE public.record_entrances_managua ALTER COLUMN status SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'record_entrances_managua'
                          AND column_name = 'current_step_id'
                    ) THEN
                        ALTER TABLE public.record_entrances_managua ALTER COLUMN current_step_id TYPE integer USING current_step_id::integer;
                        ALTER TABLE public.record_entrances_managua ALTER COLUMN current_step_id SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'record_entrances_managua'
                          AND column_name = 'closed_at'
                    ) THEN
                        ALTER TABLE public.record_entrances_managua ALTER COLUMN closed_at TYPE timestamp with time zone USING closed_at::timestamp with time zone;
                        ALTER TABLE public.record_entrances_managua ALTER COLUMN closed_at SET DEFAULT '0001-01-01 00:00:00+00';
                        UPDATE public.record_entrances_managua SET closed_at = '0001-01-01 00:00:00+00' WHERE closed_at IS NULL;
                        ALTER TABLE public.record_entrances_managua ALTER COLUMN closed_at SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua ADD COLUMN IF NOT EXISTS is_consolidated boolean NOT NULL DEFAULT false;");

            migrationBuilder.Sql(@"ALTER TABLE public.record_entrances_managua ADD COLUMN IF NOT EXISTS service_order_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'transportista'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN transportista TYPE character varying(150) USING transportista::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN transportista SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'trailer_chassis'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN trailer_chassis TYPE character varying(50) USING trailer_chassis::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN trailer_chassis SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'plate_number'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN plate_number TYPE character varying(30) USING plate_number::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN plate_number SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'driver_name'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN driver_name TYPE character varying(200) USING driver_name::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN driver_name SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'driver_license'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN driver_license TYPE character varying(50) USING driver_license::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN driver_license SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'country_of_origin'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN country_of_origin TYPE character varying(100) USING country_of_origin::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN country_of_origin SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'consignee'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN consignee TYPE character varying(200) USING consignee::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN consignee SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'aduana'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN aduana TYPE character varying(150) USING aduana::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN aduana SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'reception_details_managua'
                          AND column_name = 'medio'
                    ) THEN
                        ALTER TABLE public.reception_details_managua ALTER COLUMN medio TYPE character varying(100) USING medio::character varying;
                        ALTER TABLE public.reception_details_managua ALTER COLUMN medio SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.reception_details_managua ADD COLUMN IF NOT EXISTS reception_details_managua_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.reception_details_managua ADD COLUMN IF NOT EXISTS created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP;");

            migrationBuilder.Sql(@"ALTER TABLE public.reception_details_managua ADD COLUMN IF NOT EXISTS deleted_at timestamp with time zone NULL;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'racks_managua'
                          AND column_name = 'cost_per_position'
                    ) THEN
                        ALTER TABLE public.racks_managua ALTER COLUMN cost_per_position TYPE numeric(12,4) USING cost_per_position::numeric;
                        ALTER TABLE public.racks_managua ALTER COLUMN cost_per_position SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'racks_managua'
                          AND column_name = 'code'
                    ) THEN
                        ALTER TABLE public.racks_managua ALTER COLUMN code TYPE character varying(50) USING code::character varying;
                        ALTER TABLE public.racks_managua ALTER COLUMN code SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.racks_managua ADD COLUMN IF NOT EXISTS is_available boolean NOT NULL DEFAULT true;");

            migrationBuilder.Sql(@"ALTER TABLE public.racks_managua ADD COLUMN IF NOT EXISTS max_height_metres numeric(10,2) NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"ALTER TABLE public.racks_managua ADD COLUMN IF NOT EXISTS max_weight_kg numeric(12,2) NOT NULL DEFAULT 0;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'manifest_cancellations_managua'
                          AND column_name = 'warehouse_chief_signature'
                    ) THEN
                        ALTER TABLE public.manifest_cancellations_managua ALTER COLUMN warehouse_chief_signature TYPE character varying(250) USING warehouse_chief_signature::character varying;
                        ALTER TABLE public.manifest_cancellations_managua ALTER COLUMN warehouse_chief_signature SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'manifest_cancellations_managua'
                          AND column_name = 'manifest_number'
                    ) THEN
                        ALTER TABLE public.manifest_cancellations_managua ALTER COLUMN manifest_number TYPE character varying(100) USING manifest_number::character varying;
                        ALTER TABLE public.manifest_cancellations_managua ALTER COLUMN manifest_number SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'manifest_cancellations_managua'
                          AND column_name = 'customs_officer_signature'
                    ) THEN
                        ALTER TABLE public.manifest_cancellations_managua ALTER COLUMN customs_officer_signature TYPE character varying(250) USING customs_officer_signature::character varying;
                        ALTER TABLE public.manifest_cancellations_managua ALTER COLUMN customs_officer_signature SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'manifest_cancellations_managua'
                          AND column_name = 'ContainerDimension'
                    ) THEN
                        ALTER TABLE public.manifest_cancellations_managua ALTER COLUMN ""ContainerDimension"" TYPE text USING ""ContainerDimension""::text;
                        ALTER TABLE public.manifest_cancellations_managua ALTER COLUMN ""ContainerDimension"" SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.manifest_cancellations_managua ADD COLUMN IF NOT EXISTS manifest_cancellation_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.manifest_cancellations_managua ADD COLUMN IF NOT EXISTS created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP;");

            migrationBuilder.Sql(@"ALTER TABLE public.manifest_cancellations_managua ADD COLUMN IF NOT EXISTS deleted_at timestamp with time zone NULL;");

            migrationBuilder.Sql(@"ALTER TABLE public.manifest_cancellations_managua ADD COLUMN IF NOT EXISTS personal_type character varying(500) NOT NULL DEFAULT '';");

            migrationBuilder.Sql(@"ALTER TABLE public.manifest_cancellations_managua ADD COLUMN IF NOT EXISTS service_orders_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'entrance_ducats_managua'
                          AND column_name = 'ducat_number'
                    ) THEN
                        ALTER TABLE public.entrance_ducats_managua ALTER COLUMN ducat_number TYPE character varying(100) USING ducat_number::character varying;
                        ALTER TABLE public.entrance_ducats_managua ALTER COLUMN ducat_number SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.entrance_ducats_managua ADD COLUMN IF NOT EXISTS created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'ducat_registry_details_managua'
                          AND column_name = 'total_weight'
                    ) THEN
                        ALTER TABLE public.ducat_registry_details_managua ALTER COLUMN total_weight TYPE numeric(18,4) USING total_weight::numeric;
                        ALTER TABLE public.ducat_registry_details_managua ALTER COLUMN total_weight SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'ducat_registry_details_managua'
                          AND column_name = 'destination_area_observation'
                    ) THEN
                        ALTER TABLE public.ducat_registry_details_managua ALTER COLUMN destination_area_observation TYPE character varying(500) USING destination_area_observation::character varying;
                        ALTER TABLE public.ducat_registry_details_managua ALTER COLUMN destination_area_observation SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_details_managua ADD COLUMN IF NOT EXISTS category_product_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_details_managua ADD COLUMN IF NOT EXISTS created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_details_managua ADD COLUMN IF NOT EXISTS entrance_ducat_managua_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_details_managua ADD COLUMN IF NOT EXISTS remitente character varying(200) NOT NULL DEFAULT '';");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'discrepancies_managua'
                          AND column_name = 'discrepancy_type'
                    ) THEN
                        ALTER TABLE public.discrepancies_managua ALTER COLUMN discrepancy_type TYPE character varying(50) USING discrepancy_type::character varying;
                        ALTER TABLE public.discrepancies_managua ALTER COLUMN discrepancy_type SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_schema = 'public'
                          AND table_name = 'discrepancies_managua'
                          AND column_name = 'description'
                    ) THEN
                        ALTER TABLE public.discrepancies_managua ALTER COLUMN description TYPE character varying(1000) USING description::character varying;
                        ALTER TABLE public.discrepancies_managua ALTER COLUMN description SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"ALTER TABLE public.discrepancies_managua ADD COLUMN IF NOT EXISTS ""IsDamage"" boolean NOT NULL DEFAULT false;");

            migrationBuilder.Sql(@"ALTER TABLE public.discrepancies_managua ADD COLUMN IF NOT EXISTS created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP;");

            migrationBuilder.Sql(@"ALTER TABLE public.discrepancies_managua ADD COLUMN IF NOT EXISTS deleted_at timestamp with time zone NULL;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_managua ADD COLUMN IF NOT EXISTS ducat_registtry_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_managua ADD COLUMN IF NOT EXISTS created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_managua ADD COLUMN IF NOT EXISTS deleted_at timestamp with time zone NULL;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_managua ADD COLUMN IF NOT EXISTS general_observations character varying(1000) NULL;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_managua ADD COLUMN IF NOT EXISTS is_in_transit boolean NOT NULL DEFAULT false;");

            migrationBuilder.Sql(@"ALTER TABLE public.ducat_registry_managua ADD COLUMN IF NOT EXISTS registered_by_user_id character varying(450) NOT NULL DEFAULT '';");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'PK_warehouse_receipts_managua'
                    ) THEN
                        ALTER TABLE public.warehouse_receipts_managua
                        ADD CONSTRAINT ""PK_warehouse_receipts_managua"" PRIMARY KEY (id);
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'PK_warehouse_assignments_managua'
                    ) THEN
                        ALTER TABLE public.warehouse_assignments_managua
                        ADD CONSTRAINT ""PK_warehouse_assignments_managua"" PRIMARY KEY (id);
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'PK_unloading_details_managua'
                    ) THEN
                        ALTER TABLE public.unloading_details_managua
                        ADD CONSTRAINT ""PK_unloading_details_managua"" PRIMARY KEY (unloading_details_managua_id);
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'PK_reception_details_managua'
                    ) THEN
                        ALTER TABLE public.reception_details_managua
                        ADD CONSTRAINT ""PK_reception_details_managua"" PRIMARY KEY (reception_details_managua_id);
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'PK_manifest_cancellations_managua'
                    ) THEN
                        ALTER TABLE public.manifest_cancellations_managua
                        ADD CONSTRAINT ""PK_manifest_cancellations_managua"" PRIMARY KEY (manifest_cancellation_id);
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'PK_ducat_registry_managua'
                    ) THEN
                        ALTER TABLE public.ducat_registry_managua
                        ADD CONSTRAINT ""PK_ducat_registry_managua"" PRIMARY KEY (ducat_registtry_id);
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.tables
                        WHERE table_schema = 'public'
                          AND table_name = 'unloading_crew_assignments_managua'
                    ) THEN
                        CREATE TABLE public.unloading_crew_assignments_managua (
                            ""Id"" uuid NOT NULL,
                            unloading_details_managua_id uuid NOT NULL,
                            assigned_at timestamp with time zone NOT NULL,
                            persona_count integer NOT NULL,
                            tercerizada boolean NOT NULL,
                            ""DeletedAt"" timestamp with time zone NULL,
                            CONSTRAINT ""PK_unloading_crew_assignments_managua"" PRIMARY KEY (""Id""),
                            CONSTRAINT ""FK_unloading_crew_assignments_managua_unloading_details_managu~"" FOREIGN KEY (unloading_details_managua_id) REFERENCES public.unloading_details_managua (unloading_details_managua_id) ON DELETE RESTRICT
                        );
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.tables
                        WHERE table_schema = 'public'
                          AND table_name = 'UnloadingMachineryAssignmentsManagua'
                    ) THEN
                        CREATE TABLE public.""UnloadingMachineryAssignmentsManagua"" (
                            id uuid NOT NULL,
                            unloading_details_managua_id uuid NOT NULL,
                            machinery_code uuid NOT NULL,
                            machinery_type uuid NOT NULL,
                            start_time timestamp with time zone NOT NULL,
                            end_time timestamp with time zone NOT NULL,
                            assigned_by_user_id character varying(450) NOT NULL,
                            ""DeletedAt"" timestamp with time zone NULL,
                            CONSTRAINT ""PK_UnloadingMachineryAssignmentsManagua"" PRIMARY KEY (id),
                            CONSTRAINT ""FK_UnloadingMachineryAssignmentsManagua_unloading_details_mana~"" FOREIGN KEY (unloading_details_managua_id) REFERENCES public.unloading_details_managua (unloading_details_managua_id) ON DELETE RESTRICT
                        );
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_zones_managua_warehouse_id"" ON public.zones_managua (warehouse_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ""IX_warehouse_receipts_managua_record_entrance_managua_id"" ON public.warehouse_receipts_managua (record_entrance_managua_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ""IX_warehouse_assignments_managua_record_entrance_managua_id"" ON public.warehouse_assignments_managua (record_entrance_managua_id);");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_warehouse_assignments_managua_zone_id"" ON public.warehouse_assignments_managua (zone_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ""IX_unloading_details_managua_record_entrance_managua_id"" ON public.unloading_details_managua (record_entrance_managua_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ""IX_unloading_details_managua_warehouse_assignments_managua_id"" ON public.unloading_details_managua (warehouse_assignments_managua_id);");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_stocks_managua_category_product_id"" ON public.stocks_managua (category_product_id);");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_stocks_managua_entrance_ducats_managua_id"" ON public.stocks_managua (entrance_ducats_managua_id);");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_stocks_managua_racks_managua_id"" ON public.stocks_managua (racks_managua_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ""IX_reception_details_managua_record_entrance_managua_id"" ON public.reception_details_managua (record_entrance_managua_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ""IX_manifest_cancellations_managua_record_entrance_managua_id"" ON public.manifest_cancellations_managua (record_entrance_managua_id);");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_manifest_cancellations_managua_service_orders_id"" ON public.manifest_cancellations_managua (service_orders_id);");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_ducat_registry_details_managua_category_product_id"" ON public.ducat_registry_details_managua (category_product_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ""IX_ducat_registry_details_managua_entrance_ducat_managua_id"" ON public.ducat_registry_details_managua (entrance_ducat_managua_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ix_discrepancy_id ON public.discrepancies_managua (discrepancy_id);");

            migrationBuilder.Sql(@"CREATE UNIQUE INDEX IF NOT EXISTS ""IX_ducat_registry_managua_record_entrance_managua_id"" ON public.ducat_registry_managua (record_entrance_managua_id);");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_unloading_crew_assignments_managua_unloading_details_managu~"" ON public.unloading_crew_assignments_managua (unloading_details_managua_id);");

            migrationBuilder.Sql(@"CREATE INDEX IF NOT EXISTS ""IX_UnloadingMachineryAssignmentsManagua_unloading_details_mana~"" ON public.""UnloadingMachineryAssignmentsManagua"" (unloading_details_managua_id);");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_discrepancies_managua_entrance_ducats_managua_entrance_duca~'
                    ) THEN
                        ALTER TABLE public.discrepancies_managua
                        ADD CONSTRAINT ""FK_discrepancies_managua_entrance_ducats_managua_entrance_duca~""
                        FOREIGN KEY (entrance_ducats_id)
                        REFERENCES public.entrance_ducats_managua (entrance_ducat_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_ducat_registry_details_managua_category_products_category_p~'
                    ) THEN
                        ALTER TABLE public.ducat_registry_details_managua
                        ADD CONSTRAINT ""FK_ducat_registry_details_managua_category_products_category_p~""
                        FOREIGN KEY (category_product_id)
                        REFERENCES public.category_products (category_product_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_ducat_registry_details_managua_ducat_registry_managua_recor~'
                    ) THEN
                        ALTER TABLE public.ducat_registry_details_managua
                        ADD CONSTRAINT ""FK_ducat_registry_details_managua_ducat_registry_managua_recor~""
                        FOREIGN KEY (record_entrance_id)
                        REFERENCES public.ducat_registry_managua (ducat_registtry_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_ducat_registry_details_managua_entrance_ducats_managua_entr~'
                    ) THEN
                        ALTER TABLE public.ducat_registry_details_managua
                        ADD CONSTRAINT ""FK_ducat_registry_details_managua_entrance_ducats_managua_entr~""
                        FOREIGN KEY (entrance_ducat_managua_id)
                        REFERENCES public.entrance_ducats_managua (entrance_ducat_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_ducat_registry_managua_record_entrances_managua_record_entr~'
                    ) THEN
                        ALTER TABLE public.ducat_registry_managua
                        ADD CONSTRAINT ""FK_ducat_registry_managua_record_entrances_managua_record_entr~""
                        FOREIGN KEY (record_entrance_managua_id)
                        REFERENCES public.record_entrances_managua (record_entrance_managua_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_entrance_ducats_managua_record_entrances_managua_record_ent~'
                    ) THEN
                        ALTER TABLE public.entrance_ducats_managua
                        ADD CONSTRAINT ""FK_entrance_ducats_managua_record_entrances_managua_record_ent~""
                        FOREIGN KEY (record_entrance_managua_id)
                        REFERENCES public.record_entrances_managua (record_entrance_managua_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_manifest_cancellations_managua_service_orders_service_order~'
                    ) THEN
                        ALTER TABLE public.manifest_cancellations_managua
                        ADD CONSTRAINT ""FK_manifest_cancellations_managua_service_orders_service_order~""
                        FOREIGN KEY (service_orders_id)
                        REFERENCES public.service_orders (os_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_racks_managua_zones_managua_zone_id'
                    ) THEN
                        ALTER TABLE public.racks_managua
                        ADD CONSTRAINT ""FK_racks_managua_zones_managua_zone_id""
                        FOREIGN KEY (zone_id)
                        REFERENCES public.zones_managua (id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_reception_details_managua_record_entrances_managua_record_e~'
                    ) THEN
                        ALTER TABLE public.reception_details_managua
                        ADD CONSTRAINT ""FK_reception_details_managua_record_entrances_managua_record_e~""
                        FOREIGN KEY (record_entrance_managua_id)
                        REFERENCES public.record_entrances_managua (record_entrance_managua_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_record_entrances_managua_warehouses_warehouse_id'
                    ) THEN
                        ALTER TABLE public.record_entrances_managua
                        ADD CONSTRAINT ""FK_record_entrances_managua_warehouses_warehouse_id""
                        FOREIGN KEY (warehouse_id)
                        REFERENCES public.warehouses (warehouse_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_step_execution_logs_managua_record_entrances_managua_record~'
                    ) THEN
                        ALTER TABLE public.step_execution_logs_managua
                        ADD CONSTRAINT ""FK_step_execution_logs_managua_record_entrances_managua_record~""
                        FOREIGN KEY (record_entrance_id)
                        REFERENCES public.record_entrances_managua (record_entrance_managua_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_step_execution_logs_managua_workflow_step_definitions_workf~'
                    ) THEN
                        ALTER TABLE public.step_execution_logs_managua
                        ADD CONSTRAINT ""FK_step_execution_logs_managua_workflow_step_definitions_workf~""
                        FOREIGN KEY (workflow_step_definition_id)
                        REFERENCES public.workflow_step_definitions (id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_stocks_managua_category_products_category_product_id'
                    ) THEN
                        ALTER TABLE public.stocks_managua
                        ADD CONSTRAINT ""FK_stocks_managua_category_products_category_product_id""
                        FOREIGN KEY (category_product_id)
                        REFERENCES public.category_products (category_product_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_stocks_managua_entrance_ducats_managua_entrance_ducats_mana~'
                    ) THEN
                        ALTER TABLE public.stocks_managua
                        ADD CONSTRAINT ""FK_stocks_managua_entrance_ducats_managua_entrance_ducats_mana~""
                        FOREIGN KEY (entrance_ducats_managua_id)
                        REFERENCES public.entrance_ducats_managua (entrance_ducat_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_stocks_managua_racks_managua_racks_managua_id'
                    ) THEN
                        ALTER TABLE public.stocks_managua
                        ADD CONSTRAINT ""FK_stocks_managua_racks_managua_racks_managua_id""
                        FOREIGN KEY (racks_managua_id)
                        REFERENCES public.racks_managua (racks_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_stocks_managua_zones_managua_zone_managua_id'
                    ) THEN
                        ALTER TABLE public.stocks_managua
                        ADD CONSTRAINT ""FK_stocks_managua_zones_managua_zone_managua_id""
                        FOREIGN KEY (zone_managua_id)
                        REFERENCES public.zones_managua (id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_unloading_details_managua_warehouse_assignments_managua_war~'
                    ) THEN
                        ALTER TABLE public.unloading_details_managua
                        ADD CONSTRAINT ""FK_unloading_details_managua_warehouse_assignments_managua_war~""
                        FOREIGN KEY (warehouse_assignments_managua_id)
                        REFERENCES public.warehouse_assignments_managua (id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_warehouse_assignments_managua_racks_managua_rack_id'
                    ) THEN
                        ALTER TABLE public.warehouse_assignments_managua
                        ADD CONSTRAINT ""FK_warehouse_assignments_managua_racks_managua_rack_id""
                        FOREIGN KEY (rack_id)
                        REFERENCES public.racks_managua (racks_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_warehouse_assignments_managua_record_entrances_managua_reco~'
                    ) THEN
                        ALTER TABLE public.warehouse_assignments_managua
                        ADD CONSTRAINT ""FK_warehouse_assignments_managua_record_entrances_managua_reco~""
                        FOREIGN KEY (record_entrance_managua_id)
                        REFERENCES public.record_entrances_managua (record_entrance_managua_id)
                        ON DELETE CASCADE;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_warehouse_assignments_managua_warehouses_warehouse_id'
                    ) THEN
                        ALTER TABLE public.warehouse_assignments_managua
                        ADD CONSTRAINT ""FK_warehouse_assignments_managua_warehouses_warehouse_id""
                        FOREIGN KEY (warehouse_id)
                        REFERENCES public.warehouses (warehouse_id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_constraint WHERE conname = 'FK_warehouse_assignments_managua_zones_managua_zone_id'
                    ) THEN
                        ALTER TABLE public.warehouse_assignments_managua
                        ADD CONSTRAINT ""FK_warehouse_assignments_managua_zones_managua_zone_id""
                        FOREIGN KEY (zone_id)
                        REFERENCES public.zones_managua (id)
                        ON DELETE RESTRICT;
                    END IF;
                END $$;");
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
                name: "DeletedAt",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropColumn(
                name: "assigned_by_user_id",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropColumn(
                name: "unloading_details_managua_id",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "PreparedPallets",
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
                name: "DeletedAt",
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
                name: "UnloadingStartTime",
                schema: "public",
                table: "unloading_details_managua",
                newName: "unloading_start_time");

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

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "public",
                table: "record_entrances_managua",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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
