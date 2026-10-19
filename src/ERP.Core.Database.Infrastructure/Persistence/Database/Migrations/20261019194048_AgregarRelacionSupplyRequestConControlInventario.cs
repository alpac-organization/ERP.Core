using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionSupplyRequestConControlInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supply_requests_branches_BranchId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_requests_cost_centers_CostCenterId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_requests_operational_orders_OperationalOrderId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_requests_users_UserId",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropIndex(
                name: "IX_supply_requests_BranchId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropIndex(
                name: "IX_supply_requests_CostCenterId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropIndex(
                name: "IX_supply_requests_OperationalOrderId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropIndex(
                name: "IX_supply_requests_UserId",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropColumn(
                name: "BranchId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropColumn(
                name: "CostCenterId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropColumn(
                name: "OperationalOrderId1",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "supply_requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BranchId1",
                schema: "public",
                table: "supply_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CostCenterId1",
                schema: "public",
                table: "supply_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OperationalOrderId1",
                schema: "public",
                table: "supply_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "supply_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_supply_requests_BranchId1",
                schema: "public",
                table: "supply_requests",
                column: "BranchId1");

            migrationBuilder.CreateIndex(
                name: "IX_supply_requests_CostCenterId1",
                schema: "public",
                table: "supply_requests",
                column: "CostCenterId1");

            migrationBuilder.CreateIndex(
                name: "IX_supply_requests_OperationalOrderId1",
                schema: "public",
                table: "supply_requests",
                column: "OperationalOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_supply_requests_UserId",
                schema: "public",
                table: "supply_requests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_supply_requests_branches_BranchId1",
                schema: "public",
                table: "supply_requests",
                column: "BranchId1",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_supply_requests_cost_centers_CostCenterId1",
                schema: "public",
                table: "supply_requests",
                column: "CostCenterId1",
                principalSchema: "public",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id");

            migrationBuilder.AddForeignKey(
                name: "FK_supply_requests_operational_orders_OperationalOrderId1",
                schema: "public",
                table: "supply_requests",
                column: "OperationalOrderId1",
                principalSchema: "public",
                principalTable: "operational_orders",
                principalColumn: "operational_order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_supply_requests_users_UserId",
                schema: "public",
                table: "supply_requests",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id");
        }
    }
}
