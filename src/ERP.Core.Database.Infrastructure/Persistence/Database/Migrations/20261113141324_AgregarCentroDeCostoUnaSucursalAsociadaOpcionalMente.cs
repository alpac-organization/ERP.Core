using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCentroDeCostoUnaSucursalAsociadaOpcionalMente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "cost_centers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cost_centers_branch_id",
                schema: "public",
                table: "cost_centers",
                column: "branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cost_centers_branches_branch_id",
                schema: "public",
                table: "cost_centers",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cost_centers_branches_branch_id",
                schema: "public",
                table: "cost_centers");

            migrationBuilder.DropIndex(
                name: "IX_cost_centers_branch_id",
                schema: "public",
                table: "cost_centers");

            migrationBuilder.DropColumn(
                name: "branch_id",
                schema: "public",
                table: "cost_centers");
        }
    }
}
