using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EliminarRelacionDeWarehouseConSucursales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropIndex(
                name: "IX_warehouses_BranchId",
                schema: "public",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "public",
                table: "warehouses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                schema: "public",
                table: "warehouses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_BranchId",
                schema: "public",
                table: "warehouses",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouses_branches_BranchId",
                schema: "public",
                table: "warehouses",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id");
        }
    }
}
