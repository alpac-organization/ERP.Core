using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ReparacionMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "warehouse_receipts_managua",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "warehouse_assignments_managua",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                newName: "unloading_machinery_assignment_ id");

            migrationBuilder.RenameColumn(
                name: "UnloadingStartTime",
                schema: "public",
                table: "unloading_details_managua",
                newName: "unloading_start_time");

            migrationBuilder.RenameColumn(
                name: "PreparedPallets",
                schema: "public",
                table: "unloading_details_managua",
                newName: "prepared_pallets");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "unloading_details_managua",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "step_execution_logs_managua",
                newName: "deleted_at");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "warehouse_receipts_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "warehouse_assignments_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "unloading_details_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "step_execution_logs_managua",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "warehouse_receipts_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "warehouse_assignments_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "unloading_details_managua");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "step_execution_logs_managua");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "warehouse_receipts_managua",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "warehouse_assignments_managua",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "unloading_machinery_assignment_ id",
                schema: "public",
                table: "UnloadingMachineryAssignmentsManagua",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "unloading_start_time",
                schema: "public",
                table: "unloading_details_managua",
                newName: "UnloadingStartTime");

            migrationBuilder.RenameColumn(
                name: "prepared_pallets",
                schema: "public",
                table: "unloading_details_managua",
                newName: "PreparedPallets");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "unloading_details_managua",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "step_execution_logs_managua",
                newName: "DeletedAt");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
