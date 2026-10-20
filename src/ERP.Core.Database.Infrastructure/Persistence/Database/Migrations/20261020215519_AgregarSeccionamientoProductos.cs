using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSeccionamientoProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CostCenterId",
                schema: "public",
                table: "inventory_outputs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Observations",
                schema: "public",
                table: "inventory_outputs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReasonsInventoryRemovalId",
                schema: "public",
                table: "inventory_outputs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SupplyRequestId",
                schema: "public",
                table: "inventory_outputs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_products_branch_id",
                schema: "public",
                table: "products",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_outputs_CostCenterId",
                schema: "public",
                table: "inventory_outputs",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_outputs_ReasonsInventoryRemovalId",
                schema: "public",
                table: "inventory_outputs",
                column: "ReasonsInventoryRemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_outputs_SupplyRequestId",
                schema: "public",
                table: "inventory_outputs",
                column: "SupplyRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_outputs_cost_centers_CostCenterId",
                schema: "public",
                table: "inventory_outputs",
                column: "CostCenterId",
                principalSchema: "public",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_outputs_reasons_inventory_removals_ReasonsInvento~",
                schema: "public",
                table: "inventory_outputs",
                column: "ReasonsInventoryRemovalId",
                principalSchema: "public",
                principalTable: "reasons_inventory_removals",
                principalColumn: "reason_inventory_removal_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_outputs_supply_requests_SupplyRequestId",
                schema: "public",
                table: "inventory_outputs",
                column: "SupplyRequestId",
                principalSchema: "public",
                principalTable: "supply_requests",
                principalColumn: "supply_request_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_branches_branch_id",
                schema: "public",
                table: "products",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_outputs_cost_centers_CostCenterId",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_outputs_reasons_inventory_removals_ReasonsInvento~",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_outputs_supply_requests_SupplyRequestId",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropForeignKey(
                name: "FK_products_branches_branch_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_branch_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_inventory_outputs_CostCenterId",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropIndex(
                name: "IX_inventory_outputs_ReasonsInventoryRemovalId",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropIndex(
                name: "IX_inventory_outputs_SupplyRequestId",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropColumn(
                name: "branch_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropColumn(
                name: "Observations",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropColumn(
                name: "ReasonsInventoryRemovalId",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.DropColumn(
                name: "SupplyRequestId",
                schema: "public",
                table: "inventory_outputs");
        }
    }
}
