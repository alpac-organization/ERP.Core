using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCofigoRecepcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operational_orders_warehouses_WarehouseId",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                schema: "public",
                table: "operational_orders",
                newName: "warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_operational_orders_WarehouseId",
                schema: "public",
                table: "operational_orders",
                newName: "IX_operational_orders_warehouse_id");

            migrationBuilder.AddColumn<string>(
                name: "reception_code",
                schema: "public",
                table: "reception_entrance",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_operational_orders_warehouses_warehouse_id",
                schema: "public",
                table: "operational_orders",
                column: "warehouse_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operational_orders_warehouses_warehouse_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "reception_code",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.RenameColumn(
                name: "warehouse_id",
                schema: "public",
                table: "operational_orders",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_operational_orders_warehouse_id",
                schema: "public",
                table: "operational_orders",
                newName: "IX_operational_orders_WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_operational_orders_warehouses_WarehouseId",
                schema: "public",
                table: "operational_orders",
                column: "WarehouseId",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id");
        }
    }
}
