using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FuelRequestSupportOutputs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "supply_request_id",
                schema: "public",
                table: "supply_requests",
                newName: "base_supply_request_id");

            migrationBuilder.RenameColumn(
                name: "supply_request_id",
                schema: "public",
                table: "fuel_requests",
                newName: "base_supply_request_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "supply_request_id",
                schema: "public",
                table: "inventory_outputs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "fuel_request_id",
                schema: "public",
                table: "inventory_outputs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_outputs_fuel_request_id",
                schema: "public",
                table: "inventory_outputs",
                column: "fuel_request_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_outputs_fuel_requests_fuel_request_id",
                schema: "public",
                table: "inventory_outputs",
                column: "fuel_request_id",
                principalSchema: "public",
                principalTable: "fuel_requests",
                principalColumn: "base_supply_request_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_outputs_fuel_requests_fuel_request_id",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropIndex(
                name: "IX_inventory_outputs_fuel_request_id",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropColumn(
                name: "fuel_request_id",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.RenameColumn(
                name: "base_supply_request_id",
                schema: "public",
                table: "supply_requests",
                newName: "supply_request_id");

            migrationBuilder.RenameColumn(
                name: "base_supply_request_id",
                schema: "public",
                table: "fuel_requests",
                newName: "supply_request_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "supply_request_id",
                schema: "public",
                table: "inventory_outputs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
