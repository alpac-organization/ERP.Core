using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCentroCostoEnSolicitudesCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "cost_center_id",
                schema: "public",
                table: "purchase_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_cost_center_id",
                schema: "public",
                table: "purchase_requests",
                column: "cost_center_id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_requests_cost_centers_cost_center_id",
                schema: "public",
                table: "purchase_requests",
                column: "cost_center_id",
                principalSchema: "public",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_requests_cost_centers_cost_center_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropIndex(
                name: "IX_purchase_requests_cost_center_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropColumn(
                name: "cost_center_id",
                schema: "public",
                table: "purchase_requests");
        }
    }
}
