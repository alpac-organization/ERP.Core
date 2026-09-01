using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWarehouseMachineryAndAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // === 1. CAMBIOS EN WAREHOUSE MACHINERIES (ENUMS) ===
            migrationBuilder.Sql(@"
                ALTER TABLE warehouse_machinery ALTER COLUMN fuel_type DROP DEFAULT;
                ALTER TABLE warehouse_machinery 
                ALTER COLUMN fuel_type TYPE fuel_type_enum 
                USING CASE fuel_type
                    WHEN 1 THEN 'electric'::fuel_type_enum
                    WHEN 2 THEN 'lpg'::fuel_type_enum
                    WHEN 3 THEN 'diesel'::fuel_type_enum
                    WHEN 4 THEN 'gasoline'::fuel_type_enum
                    WHEN 5 THEN 'manual'::fuel_type_enum
                    ELSE 'other'::fuel_type_enum
                END;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE warehouse_machinery ALTER COLUMN status DROP DEFAULT;
                ALTER TABLE warehouse_machinery 
                ALTER COLUMN status TYPE machinery_status_enum 
                USING CASE status
                    WHEN 1 THEN 'available'::machinery_status_enum
                    WHEN 2 THEN 'in_use'::machinery_status_enum
                    WHEN 3 THEN 'in_maintenance'::machinery_status_enum
                    WHEN 4 THEN 'out_of_service'::machinery_status_enum
                    ELSE 'available'::machinery_status_enum
                END;
            ");

            // === 2. CAMBIOS EN WAREHOUSE ASSIGNMENTS (DUCAS) ===
            migrationBuilder.AddColumn<Guid>(
                name: "EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments",
                type: "uuid",
                nullable: true);

            // Eliminar índice único existente
            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_record_entrance_id",
                schema: "public",
                table: "warehouse_assignments");

            // Índice normal
            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_record_entrance_id",
                schema: "public",
                table: "warehouse_assignments",
                column: "record_entrance_id");

            // Índices parciales únicos (reglas de negocio)
            migrationBuilder.Sql(@"
                CREATE UNIQUE INDEX ""UX_warehouse_assignments_record_declaration""
                ON public.warehouse_assignments(record_entrance_id)
                WHERE ""EntranceDucatId"" IS NULL;
            ");

            migrationBuilder.Sql(@"
                CREATE UNIQUE INDEX ""UX_warehouse_assignments_entrance_ducat""
                ON public.warehouse_assignments(""EntranceDucatId"")
                WHERE ""EntranceDucatId"" IS NOT NULL;
            ");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_entrance_ducats_EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments",
                column: "EntranceDucatId",
                principalSchema: "public",
                principalTable: "entrance_ducats",
                principalColumn: "entrance_ducat_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_entrance_ducats_EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropColumn(
                name: "EntranceDucatId",
                schema: "public",
                table: "warehouse_assignments");
        }
    }
}
