using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarIndiceTablaCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboundAppointments_customers_CustomerId",
                schema: "public",
                table: "InboundAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboundAppointments",
                schema: "public",
                table: "InboundAppointments");

            migrationBuilder.RenameTable(
                name: "InboundAppointments",
                schema: "public",
                newName: "InboundAppointment",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_InboundAppointments_CustomerId",
                schema: "public",
                table: "InboundAppointment",
                newName: "IX_InboundAppointment_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboundAppointment",
                schema: "public",
                table: "InboundAppointment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "ux_customer_dni_ruc",
                schema: "public",
                table: "customers",
                column: "dni_ruc",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InboundAppointment_customers_CustomerId",
                schema: "public",
                table: "InboundAppointment",
                column: "CustomerId",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboundAppointment_customers_CustomerId",
                schema: "public",
                table: "InboundAppointment");

            migrationBuilder.DropIndex(
                name: "ux_customer_dni_ruc",
                schema: "public",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboundAppointment",
                schema: "public",
                table: "InboundAppointment");

            migrationBuilder.RenameTable(
                name: "InboundAppointment",
                schema: "public",
                newName: "InboundAppointments",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_InboundAppointment_CustomerId",
                schema: "public",
                table: "InboundAppointments",
                newName: "IX_InboundAppointments_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboundAppointments",
                schema: "public",
                table: "InboundAppointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InboundAppointments_customers_CustomerId",
                schema: "public",
                table: "InboundAppointments",
                column: "CustomerId",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
