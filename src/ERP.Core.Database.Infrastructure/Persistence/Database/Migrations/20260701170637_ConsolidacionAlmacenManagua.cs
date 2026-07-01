using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ConsolidacionAlmacenManagua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                schema: "public",
                table: "warehouses",
                newName: "branch_id");

            migrationBuilder.RenameColumn(
                name: "total_wight_capacity",
                schema: "public",
                table: "warehouses",
                newName: "unusable_area");

            migrationBuilder.RenameIndex(
                name: "ix_warehuose_id",
                schema: "public",
                table: "warehouses",
                newName: "ix_warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_BranchId",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_branch_id");

            migrationBuilder.RenameColumn(
                name: "service_order_id",
                schema: "public",
                table: "service_orders",
                newName: "os_id");

            migrationBuilder.RenameIndex(
                name: "ix_service_order_id",
                schema: "public",
                table: "service_orders",
                newName: "ix_service_orders_id)");

            migrationBuilder.AddColumn<decimal>(
                name: "max_height",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "min_height",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "net_storage_area",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "parking_spaces_count",
                schema: "public",
                table: "warehouses",
                type: "numeric(5,1)",
                precision: 5,
                scale: 1,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "rampas_count",
                schema: "public",
                table: "warehouses",
                type: "numeric(5,1)",
                precision: 5,
                scale: 1,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "total_area",
                schema: "public",
                table: "warehouses",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCreatedFromPortal",
                schema: "public",
                table: "service_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "code",
                schema: "public",
                table: "service_orders",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "customer_id",
                schema: "public",
                table: "service_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "observations",
                schema: "public",
                table: "service_orders",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "service_orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "dni_ruc",
                schema: "public",
                table: "customers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            // zones_managua ya existe (creada en AgregarTablasAlmacenManagua);
            // solo se agrega la nueva columna WarehousesId y su FK.
            migrationBuilder.AddColumn<Guid>(
                name: "WarehousesId",
                schema: "public",
                table: "zones_managua",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                column: "parent_warehouse_id");

            migrationBuilder.CreateIndex(
                name: "ix_os_code",
                schema: "public",
                table: "service_orders",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_orders_branch_id",
                schema: "public",
                table: "service_orders",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_service_orders_customer_id",
                schema: "public",
                table: "service_orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_zones_managua_WarehousesId",
                schema: "public",
                table: "zones_managua",
                column: "WarehousesId");

            migrationBuilder.AddForeignKey(
                name: "FK_service_orders_branches_branch_id",
                schema: "public",
                table: "service_orders",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_service_orders_customers_customer_id",
                schema: "public",
                table: "service_orders",
                column: "customer_id",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_branches_branch_id",
                schema: "public",
                table: "warehouses",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses",
                column: "parent_warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_zones_managua_warehouses_WarehousesId",
                schema: "public",
                table: "zones_managua",
                column: "WarehousesId",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_orders_branches_branch_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_service_orders_customers_customer_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_branches_branch_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_zones_managua_warehouses_WarehousesId",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropIndex(
                name: "IX_warehouses_parent_warehouse_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropIndex(
                name: "ix_os_code",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropIndex(
                name: "IX_service_orders_branch_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropIndex(
                name: "IX_service_orders_customer_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropIndex(
                name: "IX_zones_managua_WarehousesId",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropColumn(
                name: "WarehousesId",
                schema: "public",
                table: "zones_managua");

            migrationBuilder.DropColumn(
                name: "max_height",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "min_height",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "net_storage_area",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "parent_warehouse_id",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "parking_spaces_count",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "rampas_count",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "total_area",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "warehouse_type",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "IsCreatedFromPortal",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "branch_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "code",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "customer_id",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "observations",
                schema: "public",
                table: "service_orders");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "service_orders");

            migrationBuilder.RenameColumn(
                name: "branch_id",
                schema: "public",
                table: "warehouses",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "unusable_area",
                schema: "public",
                table: "warehouses",
                newName: "total_wight_capacity");

            migrationBuilder.RenameIndex(
                name: "IX_warehouses_branch_id",
                schema: "public",
                table: "warehouses",
                newName: "IX_warehouses_BranchId");

            migrationBuilder.RenameIndex(
                name: "ix_warehouse_id",
                schema: "public",
                table: "warehouses",
                newName: "ix_warehuose_id");

            migrationBuilder.RenameColumn(
                name: "os_id",
                schema: "public",
                table: "service_orders",
                newName: "service_order_id");

            migrationBuilder.RenameIndex(
                name: "ix_service_orders_id)",
                schema: "public",
                table: "service_orders",
                newName: "ix_service_order_id");

            migrationBuilder.AlterColumn<string>(
                name: "dni_ruc",
                schema: "public",
                table: "customers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}