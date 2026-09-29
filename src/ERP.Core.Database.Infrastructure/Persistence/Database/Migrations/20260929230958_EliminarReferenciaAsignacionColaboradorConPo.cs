using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EliminarReferenciaAsignacionColaboradorConPo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_collaborators_operational_orders_OperationalOrde~",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropIndex(
                name: "IX_assignment_collaborators_OperationalOrderId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropColumn(
                name: "OperationalOrderId",
                schema: "public",
                table: "assignment_collaborators");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OperationalOrderId",
                schema: "public",
                table: "assignment_collaborators",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_assignment_collaborators_OperationalOrderId",
                schema: "public",
                table: "assignment_collaborators",
                column: "OperationalOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_collaborators_operational_orders_OperationalOrde~",
                schema: "public",
                table: "assignment_collaborators",
                column: "OperationalOrderId",
                principalSchema: "public",
                principalTable: "operational_orders",
                principalColumn: "operational_order_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
